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
        /// �����б�ɸѡ��ֵ��ǰ��ӵ������Ч��
        /// </summary>
        private String selectedFilterValue = String.Empty;

        /// <summary>
        /// ָʾ DataGridView ��ǰ�Ƿ���ӵ����ɸѡ��
        /// </summary>
        private Boolean filtered;

        /// <summary>
        /// ��ʼ�� DataGridViewColumnHeadErCell �����ʵ��������������ֵ����Ϊָ�� DataGridViewColumnHeadErCell ������ֵ��
        /// </summary>
        /// <param name="oldHeaderCell">DataGridViewColumnHeadErCell �ɴ� �и�������ֵ��</param>
        public DataGridViewAutoFilterColumnHeaderCell(DataGridViewColumnHeaderCell oldHeaderCell)
        {
            ContextMenuStrip = oldHeaderCell.ContextMenuStrip;
            ErrorText = oldHeaderCell.ErrorText;
            Tag = oldHeaderCell.Tag;
            ToolTipText = oldHeaderCell.ToolTipText;
            Value = oldHeaderCell.Value;
            ValueType = oldHeaderCell.ValueType;

            // ����ǰδ���� Style ����ʱ��ʹ�� HasStyle ���ⴴ������ʽ����
            if (oldHeaderCell.HasStyle)
            {
                Style = oldHeaderCell.Style;
            }
            //����ɵ�Ԫ�����Զ�ɸѡ����Ԫ���븴�ƴ����͵����ԡ� ��ʹ Clone �����ܹ����ô˹��캯����
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
        /// �����˵�Ԫ��ľ�ȷ������
        /// </summary>
        /// <returns>��ʾ��¡�� DataGridView �Զ�ɸѡ��ͷϸ���Ķ���</returns>
        public override object Clone()
        {
            return new DataGridViewAutoFilterColumnHeaderCell(this);
        }

        /// <summary>
        /// �� DataGridView ���Ե�ֵ��������ʱ���ã��Ա�ִ����Ҫ����ӵ�пؼ����еĳ�ʼ����
        /// </summary>
        protected override void OnDataGridViewChanged()
        {
            //���ڴ��� DataGridView ʱ������
            if (DataGridView == null)
            {
                return;
            }

            //���öԲ�����Ч������Щ�е��н��������ɸѡ��
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

                //ȷ���� SortMode ����ֵ����"�Զ�"����ɷ�ֹ�û�����������ťʱ��������
                if (OwningColumn.SortMode == DataGridViewColumnSortMode.Automatic)
                {
                    try
                    {
                        OwningColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                    catch { }
                }
            }
            // �����������ӵ� DataGridView �¼���
            HandleDataGridViewEvents();

            //��ʼ��������ť�߽磬�Ա��κγ�ʼ���Զ���������Ӧ��ť��ȡ�
            SetDropDownButtonBounds();

            //���û����ϵ� OnDataGridViewChanged ������������ DataGridViewChanged �¼���
            base.OnDataGridViewChanged();
        }
        #region DataGridView events: HandleDataGridViewEvents, DataGridView event handlers, ResetDropDown, ResetFilter

        /// <summary>
        /// ����� DataGridView �¼���Ӵ��������Ҫ��Ϊ��ʹ������ť�߽�ʧЧ�����������б����� DataGridView �еĸ�����Ҫʱ���û����ɸѡ��ֵ��
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

            //Ϊ ColumnSortModeChanged �¼����һ����������Է�ֹ�� SortMode ��������������Ϊ"�Զ�"��
            DataGridView.ColumnSortModeChanged += new DataGridViewColumnEventHandler(DataGridView_ColumnSortModeChanged);
        }

        /// <summary>
        /// ���û�ˮƽ����ʱ����������ť�߽���Ч��
        /// </summary>
        /// <param name="sender">�����¼��Ķ���</param>
        /// <param name="e">�����¼����ݵ� ScrollEventArgs</param>
        private void DataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                ResetDropDown();
            }
        }

        /// <summary>
        /// ������ʾ��������ʱ����������ť�߽���Ч��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            ResetDropDown();
        }

        /// <summary>
        /// �� DataGridView �ؼ��е��п�ȷ�������ʱ����������ť�߽���Ч��
        /// �ؼ����κ��еĿ�ȸ��Ķ�����Ӱ��������ťλ�ã�
        /// ����ȡ���ڵ�ǰˮƽ����λ���Լ����ĵ����ǵ�ǰ�е���໹���Ҳࡣ 
        /// ����������¶�������ʹ��ť��Ч��
        /// </summary>
        /// <param name="sender">�����¼��Ķ���</param>
        /// <param name="e">A DataGridViewColumnEventArgs that contains the event data.</param>
        private void DataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            ResetDropDown();
        }

        /// <summary>
        /// ���б���ĸ߶ȸ���ʱ����������ť�߽���Ч��
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void DataGridView_ColumnHeadersHeightChanged(object sender, EventArgs e)
        {
            ResetDropDown();
        }

        /// <summary>
        /// �� DataGridView �Ĵ�С��������ʱ����������ť�߽���Ч���������Է�ֹ�ؼ����ұ�Ե�����ƶ��ҿؼ�������ǰ�����ҹ���ʱ�����Ļ������⡣
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void DataGridView_SizeChanged(object sender, EventArgs e)
        {
            ResetDropDown();
        }

        /// <summary>
        /// ʹ������ť�߽���Ч�������ʾ����ɸѡ���б�����������ɸѡ���б����ɸѡ���ѱ�ɾ���������û����ɸѡ��ֵ����ǰ�������Ҳࡣ
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
        /// ��֤����Դ�Ƿ�����Ҫ��ʹ������ť�߽���Ч�������ʾ����ɸѡ���б�����������ɸѡ���б����ɸѡ���ѱ�ɾ���������û����ɸѡ��ֵ��
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void DataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            ResetDropDown();
        }

        /// <summary>
        /// ʹ������ť�߽���Ч�������ʾɸѡ���б������ظ��б�
        /// </summary>
        private void ResetDropDown()
        {
            InvalidateDropDownButtonBounds();
        }


        /// <summary>
        /// ��������ģʽ����Ϊ"�Զ�"ʱ�����쳣��
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">A DataGridViewColumnEventArgs that contains the event data.</param>
        private void DataGridView_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column == OwningColumn &&
                e.Column.SortMode == DataGridViewColumnSortMode.Automatic)
            {
                throw new InvalidOperationException(
                    @"�Զ�����ģʽֵ�� DataGridView �Զ������������Ͳ����ݡ����Ϊʹ���Զ������������ԡ�");
            }
        }

        #endregion DataGridView events

        /// <summary>
        /// �����б��ⵥԪ�񣬰���������ť��
        /// </summary>
        /// <param name="graphics">���ڻ��� DataGridViewCell ��ͼ�Ρ�</param>
        /// <param name="clipBounds">��ʾ��Ҫ���»��Ƶ� DataGridView ����ľ��Ρ�</param>
        /// <param name="cellBounds">�������ڻ��Ƶ���������鿴��Ԫ�߽�ľ��Ρ�</param>
        /// <param name="rowIndex">���ڻ��Ƶĵ�Ԫ�����������</param>
        /// <param name="cellState">DataGridViewElement ��λֵ������ָ����Ԫ���״̬��</param>
        /// <param name="value">���ڻ��Ƶ���������鿴��Ԫ������.</param>
        /// <param name="formattedValue">���ڻ��Ƶ� DataGridViewCell �ĸ�ʽ������.</param>
        /// <param name="errorText">�뵥Ԫ������Ĵ�����Ϣ��</param>
        /// <param name="cellStyle">�����йص�Ԫ��ĸ�ʽ����ʽ��Ϣ�� DataGridViewCellStyle.</param>
        /// <param name="advancedBorderStyle">����������ͼ���г��߽���ʽ�����а������ڻ��Ƶĵ�Ԫ��ı߿���ʽ��</param>
        /// <param name="paintParts">DataGridViewPaintParts ֵ��λ����ϣ�ָ����Ҫ���Ƶ�Ԫ�����Щ���֡�</param>
        protected override void Paint(
            Graphics graphics, Rectangle clipBounds, Rectangle cellBounds,
            int rowIndex, DataGridViewElementStates cellState,
            object value, object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // ʹ�û���������Ĭ����ۡ�
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                cellState, value, formattedValue,
                errorText, cellStyle, advancedBorderStyle, paintParts);

            //������ɸѡ�����ݱ����ǻ��������һ����ʱ�ż�����
            if (!FilteringEnabled ||
                (paintParts & DataGridViewPaintParts.ContentBackground) == 0)
            {
                return;
            }

            // ������ǰ��ť�߽硣
            Rectangle buttonBounds = DropDownButtonBounds;

            // ������ť"�߽�"�㹻���Խ��л���ʱ���ż�����
            if (buttonBounds.Width < 1 || buttonBounds.Height < 1) return;

            //����������Ӿ���ʽ��
            //���ֶ����ư�ť��ʹ���Ӿ���ʽ��ʹ����ȷ��״̬������ȡ����ɸѡ���б��Ƿ���ʾ��
            //�Լ��Ƿ��й�������Ч��ǰ�С�
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
                //ȷ������״̬���Ա���ȷ���ư�ť��ƫ�����¼�ͷ��
                Int32 pressedOffset = 0;
                PushButtonState state = PushButtonState.Normal;
                ButtonRenderer.DrawButton(graphics, buttonBounds, state);

                //���������Ч��ɸѡ�����뽫���¼�ͷ����Ϊδ���������Ρ����û����Ч�˾����뽫���¼�ͷ����Ϊ��������Ρ�
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
        /// ������굥�������ⵥԪ����ʾ�����б���ʵ������ӵ���н�������
        /// </summary>
        /// <param name="e">A DataGridViewCellMouseEventArgs that contains the event data.</param>
        protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
        {

            //�������ⵥԪ��ĵ�ǰ��С��λ�ã�����������Ļ�������κβ��֡�
            Rectangle cellBounds = DataGridView
                .GetCellDisplayRectangle(e.ColumnIndex, -1, false);

            //�����в����ֶ�������С��������겻���е�����С����ʱ�ż�����
            if (OwningColumn.Resizable == DataGridViewTriState.True &&
                ((DataGridView.RightToLeft == RightToLeft.No &&
                cellBounds.Width - e.X < 6) || e.X < 6))
            {
                return;
            }

            //�������� RightToLeft�����򽫴洢����Ļ�����Ĳ��ֵĿ�ȡ�
            Int32 scrollingOffset = 0;
            if (DataGridView.RightToLeft == RightToLeft.No &&
                DataGridView.FirstDisplayedScrollingColumnIndex ==
                ColumnIndex)
            {
                scrollingOffset =
                    DataGridView.FirstDisplayedScrollingColumnHiddenWidth;
            }

            //���������ɸѡ��������굥��������������ť��Χ�ڣ�����ʾ�����б�
            //����������������ҵ���������������ť�߽�֮�⣬��ӵ��������
            //�������������ڵ�Ԫ��߽�ģ������Ҫ��Ԫ��λ�ú͹���ƫ����ȷ���ͻ������ꡣ
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
        /// ����Զ���������Ϊ true���򰴵�ǰ�ж� DataGridView ��������
        /// </summary>
        private void SortByColumn()
        {
            Debug.Assert(DataGridView != null && OwningColumn != null, "DataGridView or OwningColumn is null");

            // ��������Դ֧������ʱ������
            IBindingList sortList = DataGridView.DataSource as IBindingList;
            if (sortList == null ||
                !sortList.SupportsSorting ||
                !AutomaticSortingEnabled)
            {
                return;
            }

            // ȷ�������򣬲���ӵ��������
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
        /// �������ɸѡ����Ҫ���¼��㰴ť�߽磬��������ť�� Rectangle.empty.
        /// </summary>
        private Rectangle dropDownButtonBoundsValue = Rectangle.Empty;

        /// <summary>
        /// ������ť����εĽ��ޣ��������ɸѡ����Ϊ"��"���������ɸѡ�ұ߽�Ϊ�գ������¼��㰴ť�߽硣
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
        /// ��������ť�߽�ֵ����Ϊ���Ρ����ʾӦ���¼��㰴ť�߽硣
        /// </summary>
        private void InvalidateDropDownButtonBounds()
        {
            if (!dropDownButtonBoundsValue.IsEmpty)
            {
                dropDownButtonBoundsValue = Rectangle.Empty;
            }
        }

        /// <summary>
        /// ���ݵ�ǰ��Ԫ��߽�͵��б����ı�����ѡ��Ԫ��߶�����������ť�߽�ֵ��λ�úʹ�С��
        /// </summary>
        private void SetDropDownButtonBounds()
        {
            // ������Ԫ����ʾ���Σ���������������ť��λ�á�
            Rectangle cellBounds =
                DataGridView.GetCellDisplayRectangle(
                ColumnIndex, -1, false);

            // ��ʼ�������Դ洢��ť��Ե���ȣ���������߶��������ʼֵ��
            Int32 buttonEdgeLength = InheritedStyle.Font.Height + 5;

            // ���㵥Ԫ��߿�����ĸ߶ȡ�
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

            // ����ť��Ե��������Ϊ�б���ĸ߶ȼ�ȥ�߿�����߶ȡ�
            if (buttonEdgeLength >
                DataGridView.ColumnHeadersHeight -
                borderAndPaddingHeight)
            {
                buttonEdgeLength =
                    DataGridView.ColumnHeadersHeight -
                    borderAndPaddingHeight;
            }

            // ����ť��Ե����Լ��Ϊ��Ԫ���ȥ 3 �Ŀ�ȡ�
            if (buttonEdgeLength > cellBounds.Width - 3)
            {
                buttonEdgeLength = cellBounds.Width - 3;
            }

            // ����������ť��λ�ã������Ƿ������Ӿ���ʽ���е�����
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

            // ʹ�ü���ֵ����������ť�߽�ֵ������Ӧ�ص�����Ԫ����䡣
            dropDownButtonBoundsValue = new Rectangle(left, top,
                buttonEdgeLength, buttonEdgeLength);
            AdjustPadding(buttonEdgeLength + leftOffset);
        }

        /// <summary>
        /// ������Ԫ������԰�������ť��ȼӿ���⡣
        /// </summary>
        /// <param name="newDropDownButtonPaddingOffset">�µ�������ť��ȡ�</param>
        private void AdjustPadding(Int32 newDropDownButtonPaddingOffset)
        {
            // ȷ�����������͵�ǰ������֮��Ĳ�ֵ
            Int32 widthChange = newDropDownButtonPaddingOffset -
                currentDropDownButtonPaddingOffset;

            // ��������Ҫ���ģ���洢��ֵ�����и��ġ�
            if (widthChange != 0)
            {
                // ��������ť��ƫ���������ֿ��洢���Է��ͻ�����Ҫ�������䡣
                currentDropDownButtonPaddingOffset =
                    newDropDownButtonPaddingOffset;

                // ʹ�õ��������µ���䣬Ȼ������ӵ���Ԫ������� Style.pad ����ֵ�С�
                Padding dropDownPadding = new Padding(0, 0, widthChange, 0);
                Style.Padding = Padding.Add(
                    InheritedStyle.Padding, dropDownPadding);
            }
        }

        /// <summary>
        /// ������ť�ĵ�ǰ��ȡ����ֶ����ڵ�����Ԫ����䡣
        /// </summary>
        private Int32 currentDropDownButtonPaddingOffset;

        #endregion button bounds

        #region public properties: FilteringEnabled, AutomaticSortingEnabled, DropDownListBoxMaxLines

        /// <summary>
        /// ָʾ�Ƿ�Ϊӵ��������ɸѡ��
        /// </summary>
        private Boolean filteringEnabledValue = true;

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ�����ɸѡ��
        /// </summary>
        [DefaultValue(true)]
        public Boolean FilteringEnabled
        {
            get
            {
                // ��� ��û�� DataGridView ����� ���� DataSource ������δ���ã�������ɸѡ����ֵ��
                if (DataGridView == null ||
                    DataGridView.DataSource == null)
                {
                    return filteringEnabledValue;
                }

                return filteringEnabledValue;
                    
            }
            set
            {
                // �������ɸѡ����ɾ����������ʹ��ť�߽���Ч��
                if (!value)
                {
                    AdjustPadding(0);
                    InvalidateDropDownButtonBounds();
                }

                filteringEnabledValue = value;
            }
        }

        /// <summary>
        /// ָʾ�Ƿ������Զ�����
        /// </summary>
        private Boolean automaticSortingEnabledValue = true;

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ�Ϊӵ���������Զ�����
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

