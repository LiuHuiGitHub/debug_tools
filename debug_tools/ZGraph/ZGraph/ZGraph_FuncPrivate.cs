using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


namespace Pengpai.UI
{
    public partial class ZGraph : UserControl
    {
        /***************************************
         *  模块：私有函数模块
         *  设计人：xf_z1988
         *  修改人：Pengpai
         *  原始文章在博客园的位置：
         *  http://www.cnblogs.com/xf_z1988/archive/2010/05/11/CSharp_WinForm_Waveform.html 
         *  升级文章在博客园的位置：
         *  http://www.cnblogs.com/pengpai/archive/2013/05/19/3086778.html
         *  原作者联系方式：zhengxuanfan@Gmail.com
         *  修改者联系方式：250421696@qq.com
         * ************************************/
        #region ** 私有方法 在文件里边读取一组数据_getPoint(list：int,count：int):List<Point> **

        /// <summary>
        /// 在文件里边读取一组数据
        /// </summary>
        /// <param name="list">波形序号</param>
        /// <param name="count">读取第几块内容</param>
        /// <returns></returns>
        private List<Point> _getPoint(int list, int count)
        {
            FileStream fs = new FileStream(_filePath[list], FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            List<Point> point = new List<Point>();

            long len = fs.Length;                                      //获取点长度
            long fileSeek = (long)(count * 0x8000);                    //分段读取数据，每一段0x8000个数据

            fs.Seek(fileSeek, SeekOrigin.Begin);                       //设置偏移量
            int lenEnd = (int)((len - fileSeek) / 8);                  //获取从偏移量位置到文件结束可以表示多少个点，每一个坐标点占用八个字节
            if (lenEnd > 0x1000)                                       //每一块最多处理0x1000个点
            {
                lenEnd = 0x1000;
            }
            for (int i = 0; i < lenEnd; i++)
            {
                Point pot = new Point(br.ReadInt32(), br.ReadInt32()); //把读取的数据压入列表里边返回出去
                point.Add(pot);
            }
            br.Close();
            fs.Close();
            return point;
        }
        #endregion

        #region **私有方法 计算一个浮点数的权值 _getQuan(m:float):float **
        /// <summary>
        /// 计算一个浮点数的权值
        /// 如234.53返回100
        /// </summary>
        /// <param name="m">要计算权值的浮点数</param>
        /// <returns>权值</returns>
        private float _getQuan(float m)
        {
            float quan = 1f;        //临时，权值
            m = (m < 0) ? -m : m;   //取绝对值
            if (m == 0)
            {
                return 1f;          //默认0的权值为1
            }
            else if (m < 1)
            {
                do
                {
                    quan /= 10f;
                }
                while ((m = m * 10f) < 1);
                return quan;
            }
            else
            {
                while ((m /= 10f) >= 1)
                {
                    quan *= 10f;
                }
                return quan;
            }
        }
        #endregion

        #region **私有方法 根据溢出坐标范围的浮点数，改变X轴的坐标标定权值和坐标标定值 _changXBegionOrEndGO(m:float,isL:bool):void **
        /// <summary>
        /// 根据溢出坐标范围的浮点数，改变X轴的坐标标定权值和坐标标定值
        /// </summary>
        /// <param name="m">溢出坐标范围的浮点数</param>
        /// <param name="isL">是否从左边溢出</param>
        private void _changXBegionOrEndGO(float m, bool isL)
        {
            float quan = _getQuan(m);   //获得该溢出数的权值
            if (isL)
            {
                //如果值是从左边溢出
                #region **修改权值存入标定权值,控制权差在10倍以内**
                if (quan < _fXQuanEndGO)
                {
                    _fXQuanBeginGO = _fXQuanEndGO / 10f;
                }
                else if (quan > _fXQuanEndGO)
                {
                    _fXQuanBeginGO = quan;
                    _fXQuanEndGO = _fXQuanBeginGO / 10f;
                }
                else
                {
                    _fXQuanBeginGO = _fXQuanEndGO;
                }
                #endregion
                #region **根据新的权值修改坐标标定值**
                if (m <= _fXQuanBeginGO && m >= -_fXQuanBeginGO)
                {
                    _fXBeginGO = -_fXQuanBeginGO;
                }
                else
                {
                    _fXBeginGO = ((int)(m / _fXQuanBeginGO) - 1) * _fXQuanBeginGO;
                }
                #endregion
            }
            else
            {
                //如果值是从右边溢出
                #region **修改权值存入标定权值，控制权差在10倍以内**
                if (quan < _fXQuanBeginGO)
                {
                    _fXQuanEndGO = _fXQuanBeginGO / 10f;
                }
                else if (quan > _fXQuanBeginGO)
                {
                    _fXQuanEndGO = quan;
                    _fXQuanBeginGO = _fXQuanEndGO / 10f;
                }
                else
                {
                    _fXQuanEndGO = _fXQuanBeginGO;
                }
                #endregion
                #region **根据新的权值修改坐标标定值**
                if (m <= _fXQuanEndGO && m >= _fXQuanBeginGO)
                {
                    _fXEndGO = _fXQuanEndGO;
                }
                else
                {
                    _fXEndGO = ((int)(m / _fXQuanEndGO) + 1) * _fXQuanEndGO;
                }
                #endregion
            }
        }
        #endregion

        #region **私有方法 根据溢出坐标范围的浮点数，改变Y轴的坐标标定权值和坐标标定值 _changYBegionOrEndOGO(m:float, isL:bool):void **
        /// <summary>
        /// 根据溢出坐标范围的浮点数，改变Y轴的坐标标定权值和坐标标定值
        /// </summary>
        /// <param name="m">溢出坐标范围的浮点数</param>
        /// <param name="isL">是否从下边溢出</param>
        private void _changYBegionOrEndGO(float m, bool isL)
        {
            float quan = _getQuan(m);   //获得该溢出数的权值
            if (isL)
            {
                //如果值是从左边溢出
                #region **修改权值存入标定权值,控制权差在10倍以内**
                if (quan < _fYQuanEndGO)
                {
                    _fYQuanBeginGO = _fYQuanEndGO / 10f;
                }
                else if (quan > _fYQuanEndGO)
                {
                    _fYQuanBeginGO = quan;
                    _fYQuanEndGO = _fYQuanBeginGO / 10f;
                }
                else
                {
                    _fYQuanBeginGO = _fYQuanEndGO;
                }
                #endregion
                #region **根据新的权值修改坐标标定值**
                if (m <= _fYQuanBeginGO && m >= -_fYQuanBeginGO)
                {
                    _fYBeginGO = -_fYQuanBeginGO;
                }
                else
                {
                    _fYBeginGO = ((int)(m / _fYQuanBeginGO) - 1) * _fYQuanBeginGO;
                }
                #endregion
            }
            else
            {
                //如果值是从右边溢出
                #region **修改权值存入标定权值，控制权差在10倍以内**
                if (quan < _fYQuanBeginGO)
                {
                    _fYQuanEndGO = _fYQuanBeginGO / 10f;
                }
                else if (quan > _fYQuanBeginGO)
                {
                    _fYQuanEndGO = quan;
                    _fYQuanBeginGO = _fYQuanEndGO / 10f;
                }
                else
                {
                    _fYQuanEndGO = _fYQuanBeginGO;
                }
                #endregion
                #region **根据新的权值修改坐标标定值**
                if (m <= _fYQuanEndGO && m >= _fYQuanBeginGO)
                {
                    _fYEndGO = _fYQuanEndGO;
                }
                else
                {
                    _fYEndGO = ((int)(m / _fYQuanEndGO) + 1) * _fYQuanEndGO;
                }
                #endregion
            }
        }
        #endregion

        #region **私有方法 遍历要画的数据集合，并转换为坐标值 _changeToDrawPoints(index:int, listDrawPoints:ref List<PointF>, width:int, height:int):bool **
        /// <summary>
        /// 遍历要画的数据集合，并转换为坐标值
        /// </summary>
        /// <param name="index">要遍历的数据集合的编号</param>
        /// <param name="listDrawPoints">转后后的坐标集合</param>
        /// <param name="width">画布像素宽度</param>
        /// <param name="height">画布像素高度</param>
        /// <returns></returns>
        private bool _changeToDrawPoints(int index,  List<PointF> listDrawPoints, int width, int height)
        {
            PointF currentPointF = new PointF(0, 0);
            List<Point> dotPoint = new List<Point>();
            //坐标起始和结束值之差小于精度范围则返回false
            if ((_fXEnd - _fXBegin) < _fAccuracy || (_fYEnd - _fYBegin) < _fAccuracy)
            {
                return false;
            }

            if (_haveFile[index])
            {
                FileStream fs = new FileStream(_filePath[index], FileMode.Open, FileAccess.Read);
                long fileLen = fs.Length;
                fs.Close();

                for (int i = 0; i <= fileLen / 0x8000; i++)
                {
                    dotPoint = _getPoint(index, i);
                    for (int j = 0; j < dotPoint.Count; j++)
                    {
                        currentPointF.X = (dotPoint[j].X - _fXBegin) * (width - 1) / (_fXEnd - _fXBegin);
                        currentPointF.Y = (dotPoint[j].Y - _fYBegin) * (height - 1) / (_fYEnd - _fYBegin);

                        listDrawPoints.Add(currentPointF);
                    }
                }
            }
            if (_listX[index] != null)
            {
                int length = _listX[index].Count;
                //遍历并转换为坐标值
                for (int i = 0; i < length; i++)
                {
                    //非数字则跳过
                    if (float.IsNaN(_listX[index][i]) || float.IsNaN(_listY[index][i]))
                    {
                        continue;
                    }
                    //转换为像素坐标
                    currentPointF.X = (_listX[index][i] - _fXBegin) * (width - 1) / (_fXEnd - _fXBegin);
                    currentPointF.Y = (_listY[index][i] - _fYBegin) * (height - 1) / (_fYEnd - _fYBegin);
                    //装载坐标
                    listDrawPoints.Add(currentPointF);
                }
            }

            //无数据则返回false
            if (listDrawPoints.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region **私有方法 波形显示中矩形区域的坐标转换为数据值 _changeXYPointsToNum(xB:float, xE:float, yB:float, yE:float, outxB: float, outxE:ref float, outyB:ref float, outyE:ref float):void **
        /// <summary>
        /// 波形显示中矩形区域的坐标转换为数据值
        /// </summary>
        /// <param name="xB">矩形区域左上角X轴坐标</param>
        /// <param name="xE">矩形区域右下角X轴坐标</param>
        /// <param name="yB">矩形区域左上角Y轴坐标</param>
        /// <param name="yE">矩形区域右下角Y轴坐标</param>
        /// <param name="outxB">转换后的左上角X轴数据值</param>
        /// <param name="outxE">转换后的右下角X轴数据值</param>
        /// <param name="outyB">转换后的左上角Y轴数据值</param>
        /// <param name="outyE">转换后的右下角Y轴数据值</param>
        private void _changeXYPointsToNum(float xB, float xE, float yB, float yE,
            ref float outxB, ref float outxE, ref float outyB, ref float outyE)
        {
            float currentB, currentE;
            currentB = xB / (pictureBoxGraph.Width - 1) * (_fXEnd - _fXBegin) + _fXBegin;
            currentE = xE / (pictureBoxGraph.Width - 1) * (_fXEnd - _fXBegin) + _fXBegin;
            outxB = currentB;
            outxE = currentE;
            currentB = _fYEnd - yB / (pictureBoxGraph.Height - 1) * (_fYEnd - _fYBegin);
            currentE = _fYEnd - yE / (pictureBoxGraph.Height - 1) * (_fYEnd - _fYBegin);
            outyE = currentB;
            outyB = currentE;
        }
        /// <summary>
        /// 波形显示中一个点的坐标转换为数据值
        /// </summary>
        /// <param name="x">要转换的点的X轴坐标</param>
        /// <param name="y">要转换的点的Y轴坐标</param>
        /// <param name="outX">转换后的X轴坐标</param>
        /// <param name="outY">转换后的Y轴坐标</param>
        private void _changeXYPointsToNum(float x, float y, ref float outX, ref float outY)
        {
            outX = x / (pictureBoxGraph.Width - 1) * (_fXEnd - _fXBegin) + _fXBegin;
            outY = _fYEnd - y / (pictureBoxGraph.Height - 1) * (_fYEnd - _fYBegin);
        }
        #endregion


        #region ** 局部放大功能 **
        /// <summary>
        /// 局部放大功能
        /// </summary>
        private void _Magnify()
        {
            _isAutoModeXY = false;                              //标记，取消自动调整大小模式
            坐标自动调整ToolStripMenuItem.Checked = false;
            //转换坐标为实际值，更新波形显示控件坐标值
            if (_fXEnd - _fXBegin < 1.0f || _fYEnd - _fYBegin < 1.0f)
            {
                return;
            }                                         //防止放大到数据溢出的程度
            _changeXYPointsToNum(pictureBoxBigXY.Location.X, pictureBoxBigXY.Location.X + pictureBoxBigXY.Width,
                pictureBoxBigXY.Location.Y, pictureBoxBigXY.Location.Y + pictureBoxBigXY.Height,
                ref _fXBegin, ref _fXEnd, ref _fYBegin, ref _fYEnd);
            pictureBoxGraph.Refresh();                          //更新显示
            panelItemsIN.Refresh();                             //刷新按钮显示
        }
        #endregion

        #region **私有方法 放缩功能的实现 _Reduce(x:int,y:int,k:double):void **

        /// <summary>
        /// 局部放缩功能
        /// </summary>
        /// <param name="x">基准点的X轴坐标</param>
        /// <param name="y">基准点的Y轴坐标</param>
        /// <param name="k">放缩倍数，当k大于0.5时为缩小波形</param>
        private void _Reduce(int x, int y, double k)
        {
            pictureBoxBigXY.Visible = false;                    //隐藏[波形放大框]
            _isAutoModeXY = false;                              //标记，取消自动调整大小模式
            坐标自动调整ToolStripMenuItem.Checked = false;
            //转换坐标为实际值，更新波形显示控件坐标值
            if (_fXEnd - _fXBegin > 100000f || _fYEnd - _fYBegin > 100000 )   
                return;                                         //防止放大到数据溢出的程度
            //放缩系数K,当k大于0.5时为缩小波形,k为0到0.5时为放大波形
            _changeXYPointsToNum(x - (int)(k * pictureBoxGraph.Size.Width), x + (int)(k * pictureBoxGraph.Size.Width),
                y - (int)(k * pictureBoxGraph.Size.Height), y + (int)(k * pictureBoxGraph.Size.Height),
                ref _fXBegin, ref _fXEnd, ref _fYBegin, ref _fYEnd);
            pictureBoxGraph.Refresh();                          //更新显示
            panelItemsIN.Refresh();                             //刷新按钮显示
        }
        #endregion

        #region **私有方法 转换图形的起止坐标 ReChange(X:int, Y:int):void **

        /// <summary>
        ///  转换图形的起止坐标
        /// </summary>
        /// <param name="X">横坐标偏移量</param>
        /// <param name="Y">纵坐标偏移量</param>
        private void ReChange(int X, int Y)
        {
            pictureBoxBigXY.Visible = false;                    //隐藏[波形放大框]
            _isDefaultMoveModeXY = false;                       //标记，禁用自动移动模式
            _isAutoModeXY = false;                              //标记，取消自动调整大小模式
            坐标自动调整ToolStripMenuItem.Checked = false;
            //转换坐标为实际值，更新波形显示控件坐标值                             
            _changeXYPointsToNum(X, X + pictureBoxGraph.Size.Width - 1,
                Y, Y + pictureBoxGraph.Size.Height - 1,
                ref _fXBegin, ref _fXEnd, ref _fYBegin, ref _fYEnd);
            pictureBoxGraph.Refresh();                          //更新显示
            panelItemsIN.Refresh();                             //刷新按钮显示
        }
        #endregion

        #region **私有方法 截图功能的实现 CutMap():void **

        /// <summary>
        /// 截图功能
        /// </summary>
        private void CutPic()
        {
            Bitmap bit = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(bit);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;     //设置图像质量
            g.CopyFromScreen(pictureBoxLeft.PointToScreen(Point.Empty), Point.Empty, this.Size);//截图范围
            string str = DateTime.Now.ToString("HH_mm_ss") + ".png";//设置路径
            bit.Save(str);                                          //保存图形
            pictureBoxGraph.Refresh();                              //更新显示
            panelItemsIN.Refresh();                                 //刷新按钮显示
        }
        #endregion

        #region **读取文件里边的数据并显示鼠标所在位置曲线的是极坐标 ShowCoordinate(e:MouseEventArgs):void**
        /// <summary>
        /// 读取文件里边的数据并显示鼠标所在位置曲线的坐标
        /// </summary>
        /// <param name="e">鼠标事件相关的参数</param>
        private void ShowCoordinate(MouseEventArgs e)
        {
            bool haveDot = false;
            float mouseX = 0, mouseY = 0;                                            //储存鼠标的转换坐标值
            float fileX = 0, fileY = 0;
            float fileX1 = 0, fileY1 = 0;
            _changeXYPointsToNum(e.Location.X, e.Location.Y, ref mouseX, ref mouseY);
            double minXY = Math.Sqrt(mouseX * mouseX + mouseY * mouseY);             //储存鼠标点与曲线坐标最近的距离
            pictureBoxDrag.Show();   
            for (int k = 0; k < _listX.Count; k++)                                   //遍历所有的波形曲线
            {
                if (_haveFile[k])                                                    //先读取文件里边的数值然后再读取列表里边的数据
                {
                    FileStream fs = new FileStream(_filePath[k], FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    long len = (long)(fs.Length / 8);                                //获取点长度
                    for (long i = 0; i < len - 1; i++)
                    {
                        fileX = br.ReadInt32();                                      //读取文件里边的数据
                        fileY = br.ReadInt32();
                        if (fileX > mouseX)                                          //如果判断其中x坐标比鼠标的转换坐标还大，说明已经找到相近的点
                        {
                            fileX1 = br.ReadInt32();
                            fileY1 = br.ReadInt32();
                            br.Close();
                            fs.Close();
                            haveDot = true;                                          //表示已经找到符合条件的点，可以进行相关的处理了
                            break;
                        }
                    }
                    if (haveDot)
                    {
                        float cuvX = (fileX - _fXBegin) * (pictureBoxGraph.Width - 1) / (_fXEnd - _fXBegin); //把得到的两个点左边转换为图形的实际坐标
                        float cuvY = pictureBoxGraph.Height - (fileY - _fYBegin) * (pictureBoxGraph.Height - 1) / (_fYEnd - _fYBegin);
                        float cuvX1 = (fileX1 - _fXBegin) * (pictureBoxGraph.Width - 1) / (_fXEnd - _fXBegin);
                        float cuvY1 = pictureBoxGraph.Height - (fileY1 - _fYBegin) * (pictureBoxGraph.Height - 1) / (_fYEnd - _fYBegin);
                        double diatance = Math.Sqrt((e.Location.X - cuvX) * (e.Location.X - cuvX) + (e.Location.Y - cuvY) * (e.Location.Y - cuvY));//判断这个点与鼠标点是否相差的太远
                        double diatance1 = Math.Sqrt((e.Location.X - cuvX) * (e.Location.X - cuvX) + (e.Location.Y - cuvY) * (e.Location.Y - cuvY));
                         if ((diatance <= 10) || (diatance1 <= 10))                  //判断鼠标点击区域是否落在曲线上
                        {
                            if (diatance <= diatance1)                               //判断哪个点更近，然后把那个点坐标显示出来
                            {
                                _showNum.X = (int)(cuvX + pictureBoxGraph.Location.X - 3);
                                _showNum.Y = (int)(cuvY + pictureBoxGraph.Location.Y - 3);
                                labelShowNum.Text = "(" + fileX.ToString() + "," + fileY.ToString() + ")";
                            }
                            else
                            {
                                _showNum.X = (int)(cuvX1 + pictureBoxGraph.Location.X - 3);
                                _showNum.Y = (int)(cuvY1 + pictureBoxGraph.Location.Y - 3);
                                labelShowNum.Text = "(" + fileX1.ToString() + "," + fileY1.ToString() + ")";
                            }
                            pictureBoxDrag.Location = new Point(_showNum.X, _showNum.Y);
                         
                            labelShowNum.Location = new Point(50, 35);               //在窗口的左上角显示坐标值
                            labelShowNum.Show();
                            haveDot = false;
                            Refresh();
                            return;                                                  //跳出函数
                        }
                    }
                }
                if (_listX[k] != null)                                               //获取列表里边的数据
                {
                    int count;
                    try
                    {
                        count = _listX[0].Count - 1;
                    }
                    catch
                    {
                        return;
                    }
                    int minI = count;
                    //遍历坐标，确定鼠标点击的区域横坐标在曲线的某两个点之间
                    for (int i = 0; i < _listX[k].Count - 1; i++)
                    {
                        if (mouseX - _listX[k][i] >= 0 && mouseX - _listX[k][i + 1] <= 0)//鼠标位置在某两个值之间
                        {
                            minI = i;
                            break;
                        }
                        else
                            minI = count;
                    }

                    if (minI != count)                                                   //如果标号有变化，则说明鼠标有点在曲线的横坐标范围内
                    {
                        float cuvX = (_listX[k][minI] - _fXBegin) * (pictureBoxGraph.Width - 1) / (_fXEnd - _fXBegin);
                        float cuvY = pictureBoxGraph.Height - (_listY[k][minI] - _fYBegin) * (pictureBoxGraph.Height - 1) / (_fYEnd - _fYBegin);
                        float cuvX1 = (_listX[k][minI] - _fXBegin) * (pictureBoxGraph.Width - 1) / (_fXEnd - _fXBegin);
                        float cuvY1 = pictureBoxGraph.Height - (_listY[k][minI] - _fYBegin) * (pictureBoxGraph.Height - 1) / (_fYEnd - _fYBegin);
                        double diatance = Math.Sqrt((e.Location.X - cuvX) * (e.Location.X - cuvX) + (e.Location.Y - cuvY) * (e.Location.Y - cuvY));
                        double diatance1 = Math.Sqrt((e.Location.X - cuvX1) * (e.Location.X - cuvX1) + (e.Location.Y - cuvY1) * (e.Location.Y - cuvY1));
                       
                        if ((diatance <= 10) || (diatance1 <= 10))                        //判断鼠标点击区域是否落在曲线上
                        {
                            if (diatance <= diatance1)
                            {
                                _showNum.X = (int)(cuvX + pictureBoxGraph.Location.X - 3);
                                _showNum.Y = (int)(cuvY + pictureBoxGraph.Location.Y - 3);
                            }
                            else
                            {
                                _showNum.X = (int)(cuvX1 + pictureBoxGraph.Location.X - 3);
                                _showNum.Y = (int)(cuvY1 + pictureBoxGraph.Location.Y - 3);
                            }
                            pictureBoxDrag.Location = new Point(_showNum.X, _showNum.Y);  

                            labelShowNum.Text = "(" + _listX[k][minI].ToString() + "," + _listY[k][minI].ToString() + ")";
                            labelShowNum.Location = new Point(50, 35);                   //在窗口的左上角显示坐标值
                            labelShowNum.Show();
                            Refresh();
                            return;
                        }                        
                    }
                }

            }
        }
        #endregion        
    }
}
