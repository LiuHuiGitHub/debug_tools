using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace debug_tools
{
    public partial class VariableControl : UserControl
    {
        public class mapClass
        {
            public string variable;
            public uint addr;
            public ushort size;
            public string type;
        }

        private uint u32_addr = 0;
        private ushort u16_size = 0;
        private string str_name = "";

        private List<mapClass> mapList = new List<mapClass>();

        public VariableControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lock变量空间
        /// </summary>
        public void Lock()
        {
            comboBoxVariable.Enabled = false;
            textBoxAddr.Enabled = false;
            textBoxLength.Enabled = false;
            textBoxType.Enabled = false;
            checkBoxEnable.Enabled = false;
        }

        /// <summary>
        /// Lock变量控件
        /// </summary>
        public void Unlock()
        {
            comboBoxVariable.Enabled = true;
            textBoxAddr.Enabled = true;
            textBoxLength.Enabled = true;
            textBoxType.Enabled = true;
            checkBoxEnable.Enabled = true;
        }

        /// <summary>
        /// 设置变量颜色
        /// </summary>
        /// <param name="color"></param>
        public void SetVariableColor(Color color)
        {
            comboBoxVariable.ForeColor = color;
        }

        /// <summary>
        /// 初始化变量列表
        /// </summary>
        /// <param name="list"></param>
        public void Init(List<mapClass> list)
        {
            mapList = list;
            foreach (mapClass map in mapList)
            {
                comboBoxVariable.Items.Add(map.variable);
            }
            comboBoxVariable.SelectedItem = 0;
        }

        /// <summary>
        /// 变量控件是否处于选中状态
        /// </summary>
        public bool VariableEnable
        {
            get
            {
                if (checkBoxEnable.Checked == false)
                {
                    return false;
                }
                try
                {
                    u32_addr = Convert.ToUInt32(textBoxAddr.Text.Replace("0X", ""), 16);
                    u16_size = Convert.ToUInt16(textBoxLength.Text.Replace("0X", ""), 16);
                    str_name = comboBoxVariable.Text;
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public byte[] VariableValue
        {
            get
            {
                try
                {
                    string str = textBoxValue.Text;
                    str = str.Replace(" ", "");     //将原string中的空格删除
                    str = str.Replace("0x", "");
                    str = str.Replace("0X", "");
                    str = str.Replace(",", "");
                    if (str.Length % 2 != 0)
                    {
                        str += " ";
                    }
                    if(str.Length != VariableSize*2)
                    {
                        MessageBox.Show("变量值长度错误！"
                            , "错误"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Warning);
                        return new byte[0];
                    }
                    byte[] hexArray = new byte[str.Length / 2];
                    for (int i = 0; i < hexArray.Length; i++)
                    {
                        hexArray[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
                    }
                    return hexArray;
                }
                catch
                {
                    MessageBox.Show("变量值错误！"
                        , "错误"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                    return new byte[0];
                }
            }
            set
            {
                string strings = "";
                for (int i = 0; i < value.Length; i++)
                {
                    strings += value[i].ToString("X2") + " ";
                }
                textBoxValue.Text = strings;
            }
        }

        /// <summary>
        /// 变量名称
        /// </summary>
        public string VariableName
        {
            get
            {
                return str_name;
            }
        }

        /// <summary>
        /// 变量地址
        /// </summary>
        public uint VariableAddr
        {
            get
            {
                return u32_addr;
            }
        }

        /// <summary>
        /// 变量大小
        /// </summary>
        public ushort VariableSize
        {
            get
            {
                return u16_size;
            }
        }

        /// <summary>
        /// 选择变量改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxAddr.Text = "0x" + mapList[comboBoxVariable.SelectedIndex].addr.ToString("X");
            textBoxLength.Text = "0x" + mapList[comboBoxVariable.SelectedIndex].size.ToString("X");
            textBoxType.Text = mapList[comboBoxVariable.SelectedIndex].type;
            checkBoxEnable.Checked = true;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8  /* 允许使用退格符 */
             && !Char.IsDigit(e.KeyChar)
             && e.KeyChar != 'x'
             && e.KeyChar != 'X'
             && e.KeyChar != ' '
             && !(((int)e.KeyChar >= 'A' && (int)e.KeyChar <= 'F'))
             && !(((int)e.KeyChar >= 'a' && (int)e.KeyChar <= 'f'))
             )
            {
                e.Handled = true;
            }
        }
    }
}
