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
    /// ��ʾ DataGridViewTextBoxColumn��������ɸѡ���б�ɴӱ��ⵥԪ����ʡ� 
    /// </summary>
    public class DataGridViewAutoFilterTextBoxColumn : DataGridViewTextBoxColumn
    {
        /// <summary>
        /// ��ʼ�� DataGridView �Զ��ı����������ʵ����
        /// </summary>
        public DataGridViewAutoFilterTextBoxColumn() : base()
        {
            base.DefaultHeaderCellType = typeof(DataGridViewAutoFilterColumnHeaderCell);
            base.SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        #region public properties that hide inherited, non-virtual properties: DefaultHeaderCellType and SortMode

        /// <summary>
        /// �����Զ�ɸѡ���ⵥԪ�����͡����������ش�
        /// DataGridViewBand �ࡣ�̳е�����������
        /// DataGridViewAutoFilterTextTextBoxColumn ���캯����
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
        /// ��ȡ�������е�����ģʽ������ֹ������Ϊ"�Զ�"���⽫����������ť���������С����������ط�����
        /// DataGridViewColumn.����ģʽ����������������̳е������� DataGridView �Զ��ı���Colum���캯�����캯�������á�
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
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ�Ϊ��������ɸѡ��
        /// </summary>
        [DefaultValue(true)]
        public Boolean FilteringEnabled
        {
            get
            {
                // ���ر��ⵥԪ��ֵ��
                return ((DataGridViewAutoFilterColumnHeaderCell)HeaderCell)
                    .FilteringEnabled;
            }
            set
            {
                // ���ñ��ⵥԪ�����ԡ�
                ((DataGridViewAutoFilterColumnHeaderCell)HeaderCell)
                    .FilteringEnabled = value;
            }
        }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ�Ϊ���������Զ�����
        /// </summary>
        [DefaultValue(true)]
        public Boolean AutomaticSortingEnabled
        {
            get
            {
                // ���ر��ⵥԪ��ֵ��
                return ((DataGridViewAutoFilterColumnHeaderCell)HeaderCell)
                    .AutomaticSortingEnabled;
            }
            set
            {
                // ���ñ��ⵥԪ�����ԡ�
                ((DataGridViewAutoFilterColumnHeaderCell)HeaderCell)
                    .AutomaticSortingEnabled = value;
            }
        }

        #endregion public properties
    }

}
