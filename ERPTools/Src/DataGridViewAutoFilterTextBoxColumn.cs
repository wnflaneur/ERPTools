//---------------------------------------------------------------------
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace DataGridViewAutoFilter
{
    /// <summary>
    /// 表示 DataGridViewTextBoxColumn，其下拉筛选器列表可从标题单元格访问。 
    /// </summary>
    public class DataGridViewAutoFilterTextBoxColumn : DataGridViewTextBoxColumn
    {
        /// <summary>
        /// 初始化 DataGridView 自动文本框组类的新实例。
        /// </summary>
        public DataGridViewAutoFilterTextBoxColumn() : base()
        {
            base.DefaultHeaderCellType = typeof(DataGridViewAutoFilterColumnHeaderCell);
            base.SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        #region public properties that hide inherited, non-virtual properties: DefaultHeaderCellType and SortMode

        /// <summary>
        /// 返回自动筛选标题单元格类型。此属性隐藏从
        /// DataGridViewBand 类。继承的属性设置在
        /// DataGridViewAutoFilterTextTextBoxColumn 构造函数。
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Type DefaultHeaderCellType
        {
            get
            {
                return typeof(DataGridViewAutoFilterColumnHeaderCell);
            }
        }

        /// <summary>
        /// 获取或设置列的排序模式，并防止其设置为"自动"，这将干扰下拉按钮的正常运行。此属性隐藏非虚拟
        /// DataGridViewColumn.排序模式属性来自设计器。继承的属性在 DataGridView 自动文本框Colum构造函数构造函数中设置。
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        [DefaultValue(DataGridViewColumnSortMode.Programmatic)]
        public new DataGridViewColumnSortMode SortMode
        {
            get
            {
                return base.SortMode;
            }
            set
            {
                if (value == DataGridViewColumnSortMode.Automatic)
                {
                    throw new InvalidOperationException(
                        "A SortMode value of Automatic is incompatible with " +
                        "the DataGridViewAutoFilterColumnHeaderCell type. " +
                        "Use the AutomaticSortingEnabled property instead.");
                }
                else
                {
                    base.SortMode = value;
                }
            }
        }

        #endregion

        #region public properties: FilteringEnabled, AutomaticSortingEnabled, DropDownListBoxMaxLines

        /// <summary>
        /// 获取或设置一个值，指示是否为此列启用筛选。
        /// </summary>
        [DefaultValue(true)]
        public Boolean FilteringEnabled
        {
            get
            {
                // 返回标题单元格值。
                return ((DataGridViewAutoFilterColumnHeaderCell)HeaderCell)
                    .FilteringEnabled;
            }
            set
            {
                // 设置标题单元格属性。
                ((DataGridViewAutoFilterColumnHeaderCell)HeaderCell)
                    .FilteringEnabled = value;
            }
        }

        /// <summary>
        /// 获取或设置一个值，指示是否为此列启用自动排序。
        /// </summary>
        [DefaultValue(true)]
        public Boolean AutomaticSortingEnabled
        {
            get
            {
                // 返回标题单元格值。
                return ((DataGridViewAutoFilterColumnHeaderCell)HeaderCell)
                    .AutomaticSortingEnabled;
            }
            set
            {
                // 设置标题单元格属性。
                ((DataGridViewAutoFilterColumnHeaderCell)HeaderCell)
                    .AutomaticSortingEnabled = value;
            }
        }

        #endregion public properties
    }

}
