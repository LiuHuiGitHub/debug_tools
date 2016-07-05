using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using Dongzr.MidiLite;

namespace debug_tools
{
    public partial class debug_from : Form
    {
        private List<VariableControl> variavle = new List<VariableControl>();
        private bool cycleLookFlag = false;

        public debug_from(List<VariableControl.mapClass> list)
        {
            InitializeComponent();
            InitializeZGraph();
            VariableInit(list);
        }

        #region Variable
        /// <summary>
        /// 初始化VariableControl成员
        /// </summary>
        /// <param name="list"></param>
        private void VariableInit(List<VariableControl.mapClass> list)
        {
            int index = 0;
            variavle.Add(variableControl0);
            variavle.Add(variableControl1);
            variavle.Add(variableControl2);
            variavle.Add(variableControl3);
            foreach (VariableControl v in variavle)
            {
                v.Init(list);
                v.SetVariableColor(lineList[index].color);
                index++;
            }
        }

        /// <summary>
        /// 显示收到的变量大小、刷新波形
        /// </summary>
        /// <param name="bytes"></param>
        public void ShowVariableValue(byte[] bytes)
        {
            byte[] flag;
            uint[] value = new uint[] { 0, 0, 0, 0 };
            ushort[] size = new ushort[] { 0, 0, 0, 0 };
            string str = "";
            int index = 0;
            flag = CalcReadValue(bytes, ref value, ref size);
            str += DateTime.Now.ToString("HH:mm:ss") + ":" + DateTime.Now.Millisecond.ToString("D3");
            for (int i = 0; i < 4; i++)
            {
                if (flag[i] != 0)
                {
                    byte[] ArrayValue = new byte[size[i]];
                    Array.Copy(bytes, index, ArrayValue, 0, size[i]);
                    variavle[i].VariableValue = ArrayValue;

                    str += "  ";
                    str += variavle[i].VariableName + ":";
                    for (ushort j = 0; j < size[i]; j++)
                    {
                        str += bytes[index++].ToString("X2") + " ";
                    }
                }
            }
            textBoxShow.AppendText(str + "\r\n");
            zGraphShowBytes(flag, value, size);
        }

        public void ShowMessage(string msg)
        {
            textBoxShow.AppendText(msg + "\r\n");
        }

        /// <summary>
        /// 写变量
        /// </summary>
        /// <param name="v"></param>
        void WriteVariable(VariableControl v)
        {
            if (v.VariableEnable == false)
            {
                string strings = "未选择该变量" + v.VariableName + "!";
                MessageBox.Show(strings
                    , "警告"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
            }
            else if (cycleLookFlag == true)
            {
                MessageBox.Show("请先暂停查看！"
                    , "警告"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
            }
            else
            {
                e_writeCmd.addr = v.VariableAddr;
                e_writeCmd.value = v.VariableValue;

                if (e_writeCmd.value.Length == 0)
                {
                    return;
                }
                string strings = "";
                strings += "变量： " + v.VariableName + "\r\n";
                strings += "数值： ";
                for (int i = 0; i < v.VariableValue.Length; i++)//逐字节变为16进制字符，并以space隔开
                {
                    strings += v.VariableValue[i].ToString("X2") + " ";
                }
                DialogResult dr = MessageBox.Show(strings
                    , "确认写入？"
                    , MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Warning);

                if (dr == DialogResult.OK)
                {
                    TransmitDataWriteVariable(this, e_writeCmd);
                }
            }
        }
        #endregion

        #region ZGRAPH
        private float x = 0;

        class LineClass
        {
            public List<float> x = new List<float>();
            public List<float> y = new List<float>();
            public Color color;
            public LineClass(Color c)
            {
                color = c;
            }
            public LineClass()
            {
                color = Color.Red;
            }
        };

        List<LineClass> lineList = new List<LineClass>();

        /// <summary>
        /// 初始化波形显示控件
        /// </summary>
        private void InitializeZGraph()
        {
            //zGraph.m_SyStitle = "debug_tools";
            zGraph.m_ShowNumForeClor = Color.White;
            zGraph.m_ShowNumBackColor = Color.Black;

            lineList = new List<LineClass>();

            lineList.Add(new LineClass(Color.Red));
            lineList.Add(new LineClass(Color.Blue));
            lineList.Add(new LineClass(Color.Yellow));
            lineList.Add(new LineClass(Color.Green));

            ResetZGraph();

            zGraph.buttonClearModeXY.Click += new EventHandler(
                (sender, e) => { ResetZGraph(); }
                );
        }

        /// <summary>
        /// 清除当前显示的波形
        /// </summary>
        private void ClearZGraph()
        {
            x = 0;

            zGraph.f_ClearAllPix();

            foreach (LineClass line in lineList)
            {
                line.x.Clear();
                line.y.Clear();
                zGraph.f_AddPix(line.x, line.y, line.color, 4);
            }
        }

        /// <summary>
        /// 复位波形显示
        /// </summary>
        private void ResetZGraph()
        {
            ClearZGraph();
            zGraph.f_reXY();
        }

        /// <summary>
        /// 计算收到的变量值
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="value"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private byte[] CalcReadValue(byte[] bytes, ref uint[] value, ref ushort[] size)
        {
            int index = 0;
            byte[] readValueFlag = new byte[] { 0, 0, 0, 0 };//0显示也不画线，1只显示，2既显示又画线
            if (bytes.Length != 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    int j = 0;
                    if (variavle[i].VariableEnable == true)
                    {
                        size[i] = variavle[i].VariableSize;
                        while (j < size[i])
                        {
                            if (size[i] > 0 && size[i] <= 4)
                            {
                                value[i] <<= 8;
                                value[i] |= bytes[index++];
                                readValueFlag[i] = 2;
                            }
                            else
                            {
                                readValueFlag[i] = 1;
                            }
                            j++;
                        }
                    }
                }
            }
            return readValueFlag;
        }

        /// <summary>
        /// 将收到的变量值显示
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="value"></param>
        /// <param name="size"></param>
        private void zGraphShowBytes(byte[] flag, uint[] value, ushort[] size)
        {
            int index = 0;
            foreach (LineClass line in lineList)
            {
                if (flag[index] == 2 && size[index] > 0 && size[index] <= 4)
                {
                    line.x.Add(x);
                    line.y.Add(value[index]);
                }
                index++;
            }
            x++;
            zGraph.f_Refresh();
        }
        #endregion

        public event EventHandler TransmitDataReadVariable;
        public event EventHandler TransmitDataWriteVariable;


        public class ReadEventArgs : EventArgs
        {
            /// <summary>
            /// 待发送读变量的命令
            /// </summary>
            public byte[] readList;
            /// <summary>
            /// 待发送读变量的数目
            /// </summary>
            public int readNum;
        }
        public class WriteEventArgs : EventArgs
        {
            /// <summary>
            /// 待写入的地址
            /// </summary>
            public uint addr;
            /// <summary>
            /// 待写入的数值
            /// </summary>
            public byte[] value;
        }

        private WriteEventArgs e_writeCmd = new WriteEventArgs();
        private ReadEventArgs e_readCmd = new ReadEventArgs();

        /// <summary>
        /// 查看变量按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLook_Click(object sender, EventArgs e)
        {

            e_readCmd.readList = new byte[24];
            e_readCmd.readNum = 0;
            foreach (VariableControl v in variavle)
            {
                if (v.VariableEnable == true)
                {
                    e_readCmd.readList[e_readCmd.readNum * 6 + 0] = (byte)(v.VariableAddr >> 24);
                    e_readCmd.readList[e_readCmd.readNum * 6 + 1] = (byte)(v.VariableAddr >> 16);
                    e_readCmd.readList[e_readCmd.readNum * 6 + 2] = (byte)(v.VariableAddr >> 8);
                    e_readCmd.readList[e_readCmd.readNum * 6 + 3] = (byte)(v.VariableAddr >> 0);
                    e_readCmd.readList[e_readCmd.readNum * 6 + 4] = (byte)(v.VariableSize >> 8);
                    e_readCmd.readList[e_readCmd.readNum * 6 + 5] = (byte)(v.VariableSize >> 0);
                    e_readCmd.readNum++;
                }
            }
            if (e_readCmd.readNum == 0)
            {
                MessageBox.Show("未选择变量！"
                    , "错误"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (cycleLookFlag == true)
                {
                    cycleLookFlag = false;
                    foreach (VariableControl v in variavle)
                    {
                        v.Unlock();
                    }
                    textBoxCycle.Enabled = true;
                    buttonLook.Text = "查看";
                    mmTimerStop();
                }
                else
                {
                    if (textBoxCycle.Text == "0")
                    {
                        TransmitDataReadVariable(this, e_readCmd);
                    }
                    else
                    {
                        int time = Convert.ToInt32(textBoxCycle.Text);
                        if (time >= 10)
                        {
                            foreach (VariableControl v in variavle)
                            {
                                v.Lock();
                            }
                            textBoxCycle.Enabled = false;
                            mmTimerStart(time);
                            buttonLook.Text = "暂停";
                        }
                        else
                        {
                            MessageBox.Show("最小发送间隔为10ms！"
                                , "错误"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Warning);
                        }
                        cycleLookFlag = true;
                    }
                }
            }
            catch
            {

            }
        }


        #region mmTimer

        private MmTimer mmTimer = new MmTimer();

        /// <summary>
        /// 启动多媒体定时器
        /// </summary>
        /// <param name="interval"></param>
        private void mmTimerStart(int interval)
        {
            mmTimer = new MmTimer();
            mmTimer.Mode = MmTimerMode.Periodic;
            mmTimer.Interval = interval;
            mmTimer.Tick += mmTimer_tick;
            mmTimer.Start();
        }

        /// <summary>
        /// 停止多媒体定时器
        /// </summary>
        private void mmTimerStop()
        {
            if (mmTimer.IsRunning)
            {
                mmTimer.Tick -= mmTimer_tick;
                mmTimer.Stop();
                mmTimer.Dispose();
            }
        }

        /// <summary>
        /// 多媒体定时器定时中断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mmTimer_tick(object sender, EventArgs e)
        {
            TransmitDataReadVariable(this, e_readCmd);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void debug_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cycleLookFlag == true)
            {
                MessageBox.Show("请先暂停查看！"
                    , "警告"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                mmTimerStop();
            }
        }

        /// <summary>
        /// 剪切到剪贴板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemClip_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBoxShow.Text);
            textBoxShow.Text = "";
        }

        /// <summary>
        /// 复制到剪贴板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBoxShow.Text);
        }

        /// <summary>
        /// 清除文本显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            textBoxShow.Text = "";
        }


        private void ToolStripMenuItemWrite0_Click(object sender, EventArgs e)
        {
            WriteVariable(variableControl0);
        }

        private void ToolStripMenuItemWrite1_Click(object sender, EventArgs e)
        {
            WriteVariable(variableControl1);
        }

        private void ToolStripMenuItemWrite2_Click(object sender, EventArgs e)
        {
            WriteVariable(variableControl2);
        }

        private void ToolStripMenuItemWrite3_Click(object sender, EventArgs e)
        {
            WriteVariable(variableControl3);
        }
    }
}
