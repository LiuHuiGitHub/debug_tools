using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace debug_tools
{
    public partial class mainForm : Form
    {
        const byte c_readCmd = 0xFF;
        const byte c_writeCmd = 0xFE;

        public mainForm()
        {
            InitializeComponent();
            SerialPortComInit();
        }

        /// <summary>
        /// 串口相关函数
        /// </summary>
        #region SerialPort

        private SerialPort Comm = new SerialPort();

        /// <summary>
        /// 串口正在接收标志
        /// </summary>
        private bool b_ReceiveFlag = false;

        /// <summary>
        /// 初始化串口号和波特率
        /// </summary>
        private void SerialPortComInit()
        {
            comboBoxCom.Items.AddRange(SerialPort.GetPortNames());
            if(comboBoxCom.Items.Count != 0)
            {
                comboBoxCom.SelectedIndex = 0;
            }

            comboBoxBaud.Items.Add("4800");
            comboBoxBaud.Items.Add("9600");
            comboBoxBaud.Items.Add("19200");
            comboBoxBaud.Items.Add("115200");

            comboBoxBaud.SelectedIndex = 3;
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns></returns>
        private bool SerialPortOpen()
        {
            if (Comm.IsOpen)
            {
                SerialPortClose();
            }
            if (comboBoxCom.Text == "")
            {
                return false;
            }
            try
            {
                Comm.PortName = comboBoxCom.Text;
                Comm.BaudRate = int.Parse(comboBoxBaud.Text);
                Comm.Parity = Parity.None;
                Comm.StopBits = StopBits.One;
                Comm.DataBits = 8;

                Comm.WriteTimeout = 100;
                Comm.ReadTimeout = 100;
                Comm.NewLine = "\r\n";      //新行的文本，用于WriteLine方法中由系统附加在text后 

                Comm.DataReceived += CommDataReceiveHandler;

                Comm.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        private void SerialPortClose()
        {
            Comm.DataReceived -= CommDataReceiveHandler;    //反注册事件，避免下次再执行进来
            int i = Environment.TickCount;
            while (Environment.TickCount - i < 2000 && b_ReceiveFlag)
            {
                Application.DoEvents();
            }
            if (Comm.IsOpen)
            {
                Comm.Close();
            }
        }
        byte[] bytes;

        /// <summary>
        /// 串口接收中断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CommDataReceiveHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string strings = "";
            b_ReceiveFlag = true;      //开始读 
            int rxLen = Comm.BytesToRead;
            if (rxLen > 0)
            {
                byte[] tmpBuf = new byte[rxLen];
                ComRxClass s_comRxBuff = new ComRxClass();
                Comm.Read(tmpBuf, 0, rxLen);
                s_comRxBuff.getArray(tmpBuf, rxLen);
                if (s_comRxBuff.Checked())
                {
                    if(s_comRxBuff.value == 0)
                    {
                        if (s_comRxBuff.cmd == c_readCmd && s_comRxBuff.expand)
                        {
                            //匿名委托，用于this.Invoke调用
                            EventHandler TextBoxUpdate = delegate
                            {
                                bytes = new byte[s_comRxBuff.std.len - 2];
                                Array.Copy(s_comRxBuff.std.dat, bytes, bytes.Length);
                                //执行你的更新ui操作
                                showVariableValue(bytes);
                            };
                            this.Invoke(TextBoxUpdate);
                        }
                        else if(s_comRxBuff.cmd == c_writeCmd)
                        {
                            strings = "写入完成！";
                        }
                    }
                    else
                    {
                        strings = "通信错误！";
                    }
                }
                else
                {
                    strings = "接收错误！";
                }
            }
            if(strings != "")
            {
                //匿名委托，用于this.Invoke调用
                EventHandler TextBoxUpdate = delegate
                {
                    showMessage(strings);
                };
                this.Invoke(TextBoxUpdate);
            }
            b_ReceiveFlag = false;      //结束读
        }

        /// <summary>
        /// 串口发送数据
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="num"></param>
        private void CommTransmitDataReadValue(byte[] bytes, int num)
        {
            ComStdClass s_comTxBuff = new ComStdClass(c_readCmd, bytes, (byte)(num * 6));

            s_comTxBuff.trig = true;
            try
            {
                Comm.Write(s_comTxBuff.toArray(), 0, s_comTxBuff.Length);
            }
            catch
            {
                //匿名委托，用于this.Invoke调用
                EventHandler TextBoxUpdate = delegate
                {
                    //执行你的更新ui操作
                    showMessage("发送错误！");
                };
                this.Invoke(TextBoxUpdate);
            }
        }

        /// <summary>
        /// 串口发送数据
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="num"></param>
        private void CommTransmitDataWriteValue(uint addr, byte[] bytes)
        {
            ComStdClass s_comTxBuff = new ComStdClass(c_writeCmd, addr, bytes);

            s_comTxBuff.trig = true;
            try
            {
                Comm.Write(s_comTxBuff.toArray(), 0, s_comTxBuff.Length);
            }
            catch
            {
                //匿名委托，用于this.Invoke调用
                EventHandler TextBoxUpdate = delegate
                {
                    //执行你的更新ui操作
                    showMessage("发送错误！");
                };
                this.Invoke(TextBoxUpdate);
            }
        }
        #endregion

        /// <summary>
        /// 毫秒延时函数
        /// </summary>
        /// <param name="milliSecond"></param>
        public static void delay_ms(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 读取的map文件成员列表
        /// </summary>
        public List<VariableControl.mapClass> mapList = new List<VariableControl.mapClass>();

        /// <summary>
        /// 打开并解析IAR_STM8的MAP文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool OpenMapFileForIarStm8(string file)
        {
            bool flag = false;
            bool begin = false;
            string stringsLast = "";
            StreamReader myStream = null;
            try
            {
                myStream = new StreamReader(file);
                string content = myStream.ReadToEnd();
                string[] str = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                foreach (string strings in str)
                {
                    if (begin == true)
                    {
                        string[] strArray = System.Text.RegularExpressions.Regex.Split((stringsLast + strings).Replace("\r\n", ""), @"\s+");
                        if (strings == "")                  //变量结束
                        {
                            break;
                        }
                        else if (strArray.Length == 1)      //变量名过长，继续读下一行
                        {
                            stringsLast = strings;
                        }
                        else
                        {
                            stringsLast = "";
                            VariableControl.mapClass mapItem = new VariableControl.mapClass();
                            mapItem.variable = strArray[0];
                            mapItem.addr = Convert.ToUInt32(strArray[1].Replace("0X", ""), 16);
                            mapItem.type = strArray[3];
                            try
                            {
                                mapItem.size = Convert.ToUInt16(strArray[2].Replace("0X", ""), 16);
                            }
                            catch
                            {
                                mapItem.size = 0;
                                mapItem.type = strArray[2];
                            }
                            mapList.Add(mapItem);
                        }
                    }
                    else if (strings.Replace(" ", "") == "EntryAddressSizeTypeObject")
                    {
                        flag = true;
                    }
                    else if (flag)
                    {
                        begin = true;
                    }
                }
                myStream.Close();
            }
            catch
            {
                return false;
            }
            if (begin == false)
            {
                return false;
            }
            this.Text = "STM8  " + System.IO.Path.GetFileName(file);
            return true;
        }

        /// <summary>
        /// 打开并解析KEIL_C51的MAP文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool OpenMapFileForKeilC51(string file)
        {
            bool begin = false;
            StreamReader myStream = null;
            try
            {
                myStream = new StreamReader(file);
                string content = myStream.ReadToEnd();
                string[] str = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                foreach (string strings in str)
                {
                    if (begin == true)
                    {
                        string[] strArray = System.Text.RegularExpressions.Regex.Split((strings).Replace("\r\n", ""), @"\s+");
                        if(strArray.Length != 6)
                        {
                            continue;
                        }
                        if((strArray[2] != "SYMBOL" && strArray[2] != "PUBLIC")
                            ||( strArray[3] != "DATA" && strArray[3] != "XDATA" && strArray[3] != "BIT"))
                        {
                            continue;
                        }
                        
                        VariableControl.mapClass mapItem = new VariableControl.mapClass();
                        mapItem.variable = strArray[5];
                        mapItem.type = strArray[4];

                        if (mapItem.type == "BYTE")
                        {
                            mapItem.size = 1;
                        }
                        else if (mapItem.type == "WORD")
                        {
                            mapItem.size = 2;
                        }
                        else if (mapItem.type == "DWORD")
                        {
                            mapItem.size = 4;
                        }
                        else if (mapItem.type == "BIT")
                        {
                            mapItem.size = 1;
                        }
                        else
                        {
                            mapItem.size = 0;
                        }
                        if(mapItem.type == "BIT")
                        {
                            string[] strArray1 = strArray[1].Split('.');    //以‘.’分割string
                            mapItem.addr = Convert.ToUInt32(strArray1[0].Replace("H", ""), 16);
                            if (strArray1.Length == 1)
                            {
                                mapItem.addr |= (0 + 1) << 28;        //位寻址变量BIT位放到32为地址的最高位
                            }
                            else
                            {
                                mapItem.addr |= (uint.Parse(strArray1[1]) + 1) << 28;        //位寻址变量BIT位放到32为地址的最高位
                            }
                        }
                        else
                        {
                            mapItem.addr = Convert.ToUInt32(strArray[1].Replace("H", ""), 16);
                        }
                        mapList.Add(mapItem);
                    }
                    else if (strings.Replace(" ", "") == "VALUEREPCLASSTYPESYMBOLNAME")
                    {
                        begin = true;
                    }
                }
                myStream.Close();
            }
            catch
            {
                return false;
            }
            if (begin == false)
            {
                return false;
            }
            this.Text = "C51  " + System.IO.Path.GetFileName(file);
            return true;
        }

        /// <summary>
        /// 打开map文件并处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMapFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fp_openFile = new OpenFileDialog();
            fp_openFile.Title = "打开map文件";
            fp_openFile.Filter = "map (*.map)|*.map|所有文件 (*.*)|*.*";
            if (fp_openFile.ShowDialog() == DialogResult.OK)
            {
                if(OpenMapFileForIarStm8(fp_openFile.FileName) == true
                    || OpenMapFileForKeilC51(fp_openFile.FileName) == true)
                {
                    OpenDebugFrom();
                }
                else
                {
                    MessageBox.Show("map文件解析错误！");
                }
            }
        }

        public delegate void ShowVariableValue(byte[] bytes);
        public delegate void ShowMessage(string msg);
        private event ShowVariableValue showVariableValue;
        private event ShowMessage showMessage;

        /// <summary>
        /// 打开Debug窗口
        /// </summary>
        private void OpenDebugFrom()
        {
            debug_from form = new debug_from(mapList);
            if (SerialPortOpen() == false)
            {
                MessageBox.Show("打开错误，请检查接线并重新打开！"
                        , "错误"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                return;
            }

            /*使用事件委托传参*/
            form.TransmitDataReadVariable += new EventHandler(
                (sender, e) =>
                {
                    debug_from.ReadEventArgs readCmd = (debug_from.ReadEventArgs)e;
                    CommTransmitDataReadValue(readCmd.readList, readCmd.readNum);
                }
                );
            form.TransmitDataWriteVariable += new EventHandler(
                (sender, e) =>
                {
                    debug_from.WriteEventArgs writeCmd = (debug_from.WriteEventArgs)e;
                    CommTransmitDataWriteValue(writeCmd.addr, writeCmd.value);
                }
                );
            form.FormClosed += new FormClosedEventHandler(
                (sender, e) =>
                {
                    showVariableValue -= new ShowVariableValue(form.ShowVariableValue);
                    showMessage -= new ShowMessage(form.ShowMessage);
                    SerialPortClose();
                }
                );
            
            showVariableValue += new ShowVariableValue(form.ShowVariableValue);
            showMessage += new ShowMessage(form.ShowMessage);
            form.Text = this.Text;
            form.ShowDialog();
        }

        /// <summary>
        /// 时间显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            labelDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
