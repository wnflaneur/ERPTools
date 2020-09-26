using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Collections;
using System.Reflection;

namespace DataGridViewAutoFilter
{

    public delegate void UserScrHandler(int colindex);

    public class ColEvent 
    {
        public static event UserScrHandler UserScrEvent;

        public static void run(int index) 
        {
            UserScrEvent(index);
        }
    }

    public class DataGridViewAutoFilterColumnHeaderCell : DataGridViewColumnHeaderCell
    {

        /// <summary>
        /// 下拉列表筛选器值当前对拥有列生效。
        /// </summary>
        private String selectedFilterValue = String.Empty;

        /// <summary>
        /// 指示 DataGridView 当前是否由拥有列筛选。
        /// </summary>
        private Boolean filtered;

        /// <summary>
        /// 初始化 DataGridViewColumnHeadErCell 类的新实例，并将其属性值设置为指定 DataGridViewColumnHeadErCell 的属性值。
        /// </summary>
        /// <param name="oldHeaderCell">DataGridViewColumnHeadErCell 可从 中复制属性值。</param>
        public DataGridViewAutoFilterColumnHeaderCell(DataGridViewColumnHeaderCell oldHeaderCell)
        {
            ContextMenuStrip = oldHeaderCell.ContextMenuStrip;
            ErrorText = oldHeaderCell.ErrorText;
            Tag = oldHeaderCell.Tag;
            ToolTipText = oldHeaderCell.ToolTipText;
            Value = oldHeaderCell.Value;
            ValueType = oldHeaderCell.ValueType;

            // 在以前未设置 Style 属性时，使用 HasStyle 避免创建新样式对象。
            if (oldHeaderCell.HasStyle)
            {
                Style = oldHeaderCell.Style;
            }
            //如果旧单元格是自动筛选器单元格，请复制此类型的属性。 这使 Clone 方法能够重用此构造函数。
            DataGridViewAutoFilterColumnHeaderCell filterCell =
                oldHeaderCell as DataGridViewAutoFilterColumnHeaderCell;
            if (filterCell != null)
            {
                FilteringEnabled = filterCell.FilteringEnabled;
                AutomaticSortingEnabled = filterCell.AutomaticSortingEnabled;
                currentDropDownButtonPaddingOffset =
                    filterCell.currentDropDownButtonPaddingOffset;
            }
        }
        /// <summary>
        /// 创建此单元格的精确副本。
        /// </summary>
        /// <returns>表示克隆的 DataGridView 自动筛选器头细胞的对象。</returns>
        public override object Clone()
        {
            return new DataGridViewAutoFilterColumnHeaderCell(this);
        }

        /// <summary>
        /// 当 DataGridView 属性的值发生更改时调用，以便执行需要访问拥有控件和列的初始化。
        /// </summary>
        protected override void OnDataGridViewChanged()
        {
            //仅在存在 DataGridView 时继续。
            if (DataGridView == null)
            {
                return;
            }

            //禁用对不能有效利用这些列的列进行排序和筛选。
            if (OwningColumn != null)
            {
                if (OwningColumn is DataGridViewImageColumn ||
                (OwningColumn is DataGridViewButtonColumn &&
                ((DataGridViewButtonColumn)OwningColumn).UseColumnTextForButtonValue) ||
                (OwningColumn is DataGridViewLinkColumn &&
                ((DataGridViewLinkColumn)OwningColumn).UseColumnTextForLinkValue))
                {
                    AutomaticSortingEnabled = false;
                    FilteringEnabled = false;
                }

                //确保列 SortMode 属性值不是"自动"。这可防止用户单击下拉按钮时进行排序。
                if (OwningColumn.SortMode == DataGridViewColumnSortMode.Automatic)
                {
                    try
                    {
                        OwningColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                    catch { }
                }
            }
            // 将处理程序添加到 DataGridView 事件。
            HandleDataGridViewEvents();

            //初始化下拉按钮边界，以便任何初始列自动调整将适应按钮宽度。
            SetDropDownButtonBounds();

            //调用基类上的 OnDataGridViewChanged 方法，以引发 DataGridViewChanged 事件。
            base.OnDataGridViewChanged();
        }
        #region DataGridView events: HandleDataGridViewEvents, DataGridView event handlers, ResetDropDown, ResetFilter

        /// <summary>
        /// 向各种 DataGridView 事件添加处理程序，主要是为了使下拉按钮边界失效，隐藏下拉列表，并在 DataGridView 中的更改需要时重置缓存的筛选器值。
        /// </summary>
        private void HandleDataGridViewEvents()
        {
            DataGridView.Scroll += new ScrollEventHandler(DataGridView_Scroll);
            DataGridView.ColumnDisplayIndexChanged += new DataGridViewColumnEventHandler(DataGridView_ColumnDisplayIndexChanged);
            DataGridView.ColumnWidthChanged += new DataGridViewColumnEventHandler(DataGridView_ColumnWidthChanged);
            DataGridView.ColumnHeadersHeightChanged += new EventHandler(DataGridView_ColumnHeadersHeightChanged);
            DataGridView.SizeChanged += new EventHandler(DataGridView_SizeChanged);
            DataGridView.DataSourceChanged += new EventHandler(DataGridView_DataSourceChanged);
            DataGridView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(DataGridView_DataBindingComplete);

            //为 ColumnSortModeChanged 事件添加一个处理程序，以防止列 SortMode 属性无意中设置为"自动"。
            DataGridView.ColumnSortModeChanged += new DataGridViewColumnEventHandler(DataGridView_ColumnSortModeChanged);
        }

        /// <summary>
        /// 当用户水平滚动时，将下拉按钮边界无效。
        /// </summary>
        /// <param name="sender">引发事件的对象。</param>
        /// <param name="e">包含事件数据的 ScrollEventArgs</param>
        private void DataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                ResetDropDown();
            }
        }

        /// <summary>
        /// 当列显示索引更改时，将下拉按钮边界无效。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            ResetDropDown();
        }

        /// <summary>
        /// 当 DataGridView 控件中的列宽度发生更改时，将下拉按钮边界无效。
        /// 控件的任何列的宽度更改都可能影响下拉按钮位置，
        /// 具体取决于当前水平滚动位置以及更改的列是当前列的左侧还是右侧。 
        /// 在所有情况下都更容易使按钮无效。
        /// </summary>
        /// <param name="sender">引发事件的对象。</param>
        /// <param name="e">A DataGridViewColumnEventArgs that contains the event data.</param>
        private void DataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            ResetDropDown();
        }

        /// <summary>
        /// 当列标题的高度更改时，将下拉按钮边界无效。
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void DataGridView_ColumnHeadersHeightChanged(object sender, EventArgs e)
        {
            ResetDropDown();
        }

        /// <summary>
        /// 当 DataGridView 的大小发生更改时，将下拉按钮边界无效。这样可以防止控件的右边缘向右移动且控件内容以前已向右滚动时发生的绘制问题。
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void DataGridView_SizeChanged(object sender, EventArgs e)
        {
            ResetDropDown();
        }

        /// <summary>
        /// 使下拉按钮边界无效，如果显示下拉筛选器列表，则隐藏下拉筛选器列表，如果筛选器已被删除，则重置缓存的筛选器值。以前滚动到右侧。
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">A DataGridViewBindingCompleteEventArgs that contains the event data.</param>
        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset)
            {
                ResetDropDown();
            }
        }

        /// <summary>
        /// 验证数据源是否满足要求，使下拉按钮边界无效，如果显示下拉筛选器列表，则隐藏下拉筛选器列表，如果筛选器已被删除，则重置缓存的筛选器值。
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void DataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            ResetDropDown();
        }

        /// <summary>
        /// 使下拉按钮边界无效，如果显示筛选器列表，则隐藏该列表。
        /// </summary>
        private void ResetDropDown()
        {
            InvalidateDropDownButtonBounds();
        }


        /// <summary>
        /// 当列排序模式更改为"自动"时引发异常。
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">A DataGridViewColumnEventArgs that contains the event data.</param>
        private void DataGridView_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column == OwningColumn &&
                e.Column.SortMode == DataGridViewColumnSortMode.Automatic)
            {
                throw new InvalidOperationException(
                    @"自动排序模式值与 DataGridView 自动过滤器组类型不兼容。请改为使用自动排序启用属性。");
            }
        }

        #endregion DataGridView events

        /// <summary>
        /// 绘制列标题单元格，包括下拉按钮。
        /// </summary>
        /// <param name="graphics">用于绘制 DataGridViewCell 的图形。</param>
        /// <param name="clipBounds">表示需要重新绘制的 DataGridView 区域的矩形。</param>
        /// <param name="cellBounds">包含正在绘制的数据网格查看单元边界的矩形。</param>
        /// <param name="rowIndex">正在绘制的单元格的行索引。</param>
        /// <param name="cellState">DataGridViewElement 的位值，用于指定单元格的状态。</param>
        /// <param name="value">正在绘制的数据网格查看单元的数据.</param>
        /// <param name="formattedValue">正在绘制的 DataGridViewCell 的格式化数据.</param>
        /// <param name="errorText">与单元格关联的错误消息。</param>
        /// <param name="cellStyle">包含有关单元格的格式和样式信息的 DataGridViewCellStyle.</param>
        /// <param name="advancedBorderStyle">数据网格视图、行车边界样式，其中包含正在绘制的单元格的边框样式。</param>
        /// <param name="paintParts">DataGridViewPaintParts 值的位向组合，指定需要绘制单元格的哪些部分。</param>
        protected override void Paint(
            Graphics graphics, Rectangle clipBounds, Rectangle cellBounds,
            int rowIndex, DataGridViewElementStates cellState,
            object value, object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // 使用基方法绘制默认外观。
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                cellState, value, formattedValue,
                errorText, cellStyle, advancedBorderStyle, paintParts);

            //仅启用筛选且内容背景是绘制请求的一部分时才继续。
            if (!FilteringEnabled ||
                (paintParts & DataGridViewPaintParts.ContentBackground) == 0)
            {
                return;
            }

            // 检索当前按钮边界。
            Rectangle buttonBounds = DropDownButtonBounds;

            // 仅当按钮"边界"足够大以进行绘制时，才继续。
            if (buttonBounds.Width < 1 || buttonBounds.Height < 1) return;

            //如果启用了视觉样式，
            //则手动绘制按钮或使用视觉样式，使用正确的状态，具体取决于筛选器列表是否显示，
            //以及是否有过滤器有效当前列。
            if (Application.RenderWithVisualStyles)
            {
                ComboBoxState state = ComboBoxState.Normal;

                if (filtered)
                {
                    state = ComboBoxState.Hot;
                }
                ComboBoxRenderer.DrawDropDownButton(
                    graphics, buttonBounds, state);
            }
            else
            {
                //确定按下状态，以便正确绘制按钮并偏移向下箭头。
                Int32 pressedOffset = 0;
                PushButtonState state = PushButtonState.Normal;
                ButtonRenderer.DrawButton(graphics, buttonBounds, state);

                //如果列有有效的筛选器，请将向下箭头绘制为未填充的三角形。如果没有有效滤镜，请将向下箭头绘制为填充三角形。
                if (filtered)
                {
                    graphics.DrawPolygon(SystemPens.ControlText, new Point[] {
                        new Point(
                            buttonBounds.Width / 2 +
                                buttonBounds.Left - 1 + pressedOffset,
                            buttonBounds.Height * 3 / 4 +
                                buttonBounds.Top - 1 + pressedOffset),
                        new Point(
                            buttonBounds.Width / 4 +
                                buttonBounds.Left + pressedOffset,
                            buttonBounds.Height / 2 +
                                buttonBounds.Top - 1 + pressedOffset),
                        new Point(
                            buttonBounds.Width * 3 / 4 +
                                buttonBounds.Left - 1 + pressedOffset,
                            buttonBounds.Height / 2 +
                                buttonBounds.Top - 1 + pressedOffset)
                    });
                }
                else
                {
                    graphics.FillPolygon(SystemBrushes.ControlText, new Point[] {
                        new Point(
                            buttonBounds.Width / 2 +
                                buttonBounds.Left - 1 + pressedOffset,
                            buttonBounds.Height * 3 / 4 +
                                buttonBounds.Top - 1 + pressedOffset),
                        new Point(
                            buttonBounds.Width / 4 +
                                buttonBounds.Left + pressedOffset,
                            buttonBounds.Height / 2 +
                                buttonBounds.Top - 1 + pressedOffset),
                        new Point(
                            buttonBounds.Width * 3 / 4 +
                                buttonBounds.Left - 1 + pressedOffset,
                            buttonBounds.Height / 2 +
                                buttonBounds.Top - 1 + pressedOffset)
                    });
                }
            }

        }

        /// <summary>
        /// 处理鼠标单击到标题单元格，显示下拉列表或按适当情况对拥有列进行排序。
        /// </summary>
        /// <param name="e">A DataGridViewCellMouseEventArgs that contains the event data.</param>
        protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
        {

            //检索标题单元格的当前大小和位置，不包括从屏幕滚动的任何部分。
            Rectangle cellBounds = DataGridView
                .GetCellDisplayRectangle(e.ColumnIndex, -1, false);

            //仅当列不可手动调整大小或鼠标坐标不在列调整大小区域时才继续。
            if (OwningColumn.Resizable == DataGridViewTriState.True &&
                ((DataGridView.RightToLeft == RightToLeft.No &&
                cellBounds.Width - e.X < 6) || e.X < 6))
            {
                return;
            }

            //除非启用 RightToLeft，否则将存储从屏幕滚动的部分的宽度。
            Int32 scrollingOffset = 0;
            if (DataGridView.RightToLeft == RightToLeft.No &&
                DataGridView.FirstDisplayedScrollingColumnIndex ==
                ColumnIndex)
            {
                scrollingOffset =
                    DataGridView.FirstDisplayedScrollingColumnHiddenWidth;
            }

            //如果启用了筛选，并且鼠标单击发生在下拉按钮范围内，则显示下拉列表。
            //否则，如果启用排序并且单击发生在下拉按钮边界之外，则按拥有列排序。
            //鼠标坐标是相对于单元格边界的，因此需要单元格位置和滚动偏移来确定客户端坐标。
            if (FilteringEnabled &&
                DropDownButtonBounds.Contains(
                e.X + cellBounds.Left - scrollingOffset, e.Y + cellBounds.Top))
            {
                ColEvent.run(e.ColumnIndex);
            }
            else if (AutomaticSortingEnabled &&
                DataGridView.SelectionMode !=
                DataGridViewSelectionMode.ColumnHeaderSelect)
            {
                SortByColumn();
            }

            base.OnMouseDown(e);
        }

        /// <summary>
        /// 如果自动排序启用为 true，则按当前列对 DataGridView 进行排序。
        /// </summary>
        private void SortByColumn()
        {
            Debug.Assert(DataGridView != null && OwningColumn != null, "DataGridView or OwningColumn is null");

            // 仅在数据源支持排序时继续。
            IBindingList sortList = DataGridView.DataSource as IBindingList;
            if (sortList == null ||
                !sortList.SupportsSorting ||
                !AutomaticSortingEnabled)
            {
                return;
            }

            // 确定排序方向，并按拥有列排序。
            ListSortDirection direction = ListSortDirection.Ascending;
            if (DataGridView.SortedColumn == OwningColumn &&
                DataGridView.SortOrder == SortOrder.Ascending)
            {
                direction = ListSortDirection.Descending;
            }
            DataGridView.Sort(OwningColumn, direction);
        }




        #region button bounds: DropDownButtonBounds, InvalidateDropDownButtonBounds, SetDropDownButtonBounds, AdjustPadding

        /// <summary>
        /// 如果禁用筛选或需要重新计算按钮边界，则下拉按钮或 Rectangle.empty.
        /// </summary>
        private Rectangle dropDownButtonBoundsValue = Rectangle.Empty;

        /// <summary>
        /// 下拉按钮或矩形的界限，如果禁用筛选，则为"空"。如果启用筛选且边界为空，则重新计算按钮边界。
        /// </summary>
        protected Rectangle DropDownButtonBounds
        {
            get
            {
                if (!FilteringEnabled)
                {
                    return Rectangle.Empty;
                }
                if (dropDownButtonBoundsValue == Rectangle.Empty)
                {
                    SetDropDownButtonBounds();
                }
                return dropDownButtonBoundsValue;
            }
        }

        /// <summary>
        /// 将下拉按钮边界值设置为矩形。这表示应重新计算按钮边界。
        /// </summary>
        private void InvalidateDropDownButtonBounds()
        {
            if (!dropDownButtonBoundsValue.IsEmpty)
            {
                dropDownButtonBoundsValue = Rectangle.Empty;
            }
        }

        /// <summary>
        /// 根据当前单元格边界和单行标题文本的首选单元格高度设置下拉按钮边界值的位置和大小。
        /// </summary>
        private void SetDropDownButtonBounds()
        {
            // 检索单元格显示矩形，用于设置下拉按钮的位置。
            Rectangle cellBounds =
                DataGridView.GetCellDisplayRectangle(
                ColumnIndex, -1, false);

            // 初始化变量以存储按钮边缘长度，根据字体高度设置其初始值。
            Int32 buttonEdgeLength = InheritedStyle.Font.Height + 5;

            // 计算单元格边框和填充的高度。
            Rectangle borderRect = BorderWidths(
                DataGridView.AdjustColumnHeaderBorderStyle(
                DataGridView.AdvancedColumnHeadersBorderStyle,
                new DataGridViewAdvancedBorderStyle(), false, false));
            Int32 borderAndPaddingHeight = 2 +
                borderRect.Top + borderRect.Height +
                InheritedStyle.Padding.Vertical;
            Boolean visualStylesEnabled =
                Application.RenderWithVisualStyles &&
                DataGridView.EnableHeadersVisualStyles;
            if (visualStylesEnabled)
            {
                borderAndPaddingHeight += 3;
            }

            // 将按钮边缘长度限制为列标题的高度减去边框和填充高度。
            if (buttonEdgeLength >
                DataGridView.ColumnHeadersHeight -
                borderAndPaddingHeight)
            {
                buttonEdgeLength =
                    DataGridView.ColumnHeadersHeight -
                    borderAndPaddingHeight;
            }

            // 将按钮边缘长度约束为单元格减去 3 的宽度。
            if (buttonEdgeLength > cellBounds.Width - 3)
            {
                buttonEdgeLength = cellBounds.Width - 3;
            }

            // 计算下拉按钮的位置，根据是否启用视觉样式进行调整。
            Int32 topOffset = visualStylesEnabled ? 4 : 1;
            Int32 top = cellBounds.Bottom - buttonEdgeLength - topOffset;
            Int32 leftOffset = visualStylesEnabled ? 3 : 1;
            Int32 left = 0;
            if (DataGridView.RightToLeft == RightToLeft.No)
            {
                left = cellBounds.Right - buttonEdgeLength - leftOffset;
            }
            else
            {
                left = cellBounds.Left + leftOffset;
            }

            // 使用计算值设置下拉按钮边界值，并相应地调整单元格填充。
            dropDownButtonBoundsValue = new Rectangle(left, top,
                buttonEdgeLength, buttonEdgeLength);
            AdjustPadding(buttonEdgeLength + leftOffset);
        }

        /// <summary>
        /// 调整单元格填充以按下拉按钮宽度加宽标题。
        /// </summary>
        /// <param name="newDropDownButtonPaddingOffset">新的下拉按钮宽度。</param>
        private void AdjustPadding(Int32 newDropDownButtonPaddingOffset)
        {
            // 确定新填充调整和当前填充调整之间的差值
            Int32 widthChange = newDropDownButtonPaddingOffset -
                currentDropDownButtonPaddingOffset;

            // 如果填充需要更改，请存储新值并进行更改。
            if (widthChange != 0)
            {
                // 将下拉按钮的偏移量与填充分开存储，以防客户端需要额外的填充。
                currentDropDownButtonPaddingOffset =
                    newDropDownButtonPaddingOffset;

                // 使用调整金额创建新的填充，然后将其添加到单元格的现有 Style.pad 属性值中。
                Padding dropDownPadding = new Padding(0, 0, widthChange, 0);
                Style.Padding = Padding.Add(
                    InheritedStyle.Padding, dropDownPadding);
            }
        }

        /// <summary>
        /// 下拉按钮的当前宽度。此字段用于调整单元格填充。
        /// </summary>
        private Int32 currentDropDownButtonPaddingOffset;

        #endregion button bounds

        #region public properties: FilteringEnabled, AutomaticSortingEnabled, DropDownListBoxMaxLines

        /// <summary>
        /// 指示是否为拥有列启用筛选。
        /// </summary>
        private Boolean filteringEnabledValue = true;

        /// <summary>
        /// 获取或设置一个值，指示是否启用筛选。
        /// </summary>
        [DefaultValue(true)]
        public Boolean FilteringEnabled
        {
            get
            {
                // 如果 （没有 DataGridView 或如果 （其 DataSource 属性尚未设置），返回筛选启用值。
                if (DataGridView == null ||
                    DataGridView.DataSource == null)
                {
                    return filteringEnabledValue;
                }

                return filteringEnabledValue;
                    
            }
            set
            {
                // 如果禁用筛选，请删除填充调整并使按钮边界无效。
                if (!value)
                {
                    AdjustPadding(0);
                    InvalidateDropDownButtonBounds();
                }

                filteringEnabledValue = value;
            }
        }

        /// <summary>
        /// 指示是否启用自动排序。
        /// </summary>
        private Boolean automaticSortingEnabledValue = true;

        /// <summary>
        /// 获取或设置一个值，指示是否为拥有列启用自动排序。
        /// </summary>
        [DefaultValue(true)]
        public Boolean AutomaticSortingEnabled
        {
            get
            {
                return automaticSortingEnabledValue;
            }
            set
            {
                automaticSortingEnabledValue = value;
                if (OwningColumn != null)
                {
                    if (value)
                    {
                        OwningColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                    else
                    {
                        OwningColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
        }
        #endregion public properties
    }

}

