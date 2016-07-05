using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;


namespace Pengpai.UI
{
    public partial class ZGraph : UserControl
    {
        /***************************************
         *  模块：工具栏及右键弹出菜单模块
         *  设计人：xf_z1988
         *  修改人：Pengpai
         *  原始文章在博客园的位置：
         *  http://www.cnblogs.com/xf_z1988/archive/2010/05/11/CSharp_WinForm_Waveform.html 
         *  升级文章在博客园的位置：
         *  http://www.cnblogs.com/pengpai/archive/2013/05/19/3086778.html
         *  原作者联系方式：zhengxuanfan@Gmail.com
         *  修改者联系方式：250421696@qq.com
         * ************************************/
        #region **私有方法** 工具栏按钮**
        #region **按钮 显示网格按钮**
        // 按钮 显示网格按钮 单击
        private void buttonLinesShowXY_Click(object sender, EventArgs e)
        {
            buttonLinesShowXY.Enabled = false;              //禁用按钮
            buttonLinesShowXY.Parent.Focus();               //取消焦点
            if (_isLinesShowXY)                             //标记是否可显示网络
            {
                _isLinesShowXY = false;                     //标记
                网格显示ToolStripMenuItem.Checked = false;
            }
            else
            {
                _isLinesShowXY = true;                      //标记
                网格显示ToolStripMenuItem.Checked = true;
            }
            pictureBoxDrag.Hide();
            labelShowNum.Hide();
            pictureBoxGraph.Refresh();                      //刷新界面
            panelItemsIN.Refresh();                         //刷新按钮显示
            buttonLinesShowXY.Enabled = true;               //启用按钮
        }
        // 显示网格按钮 鼠标经过
        private void buttonLinesShowXY_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panelControlItem.Location.X - 100;
            po.Y = panelControlItem.Location.Y + buttonLinesShowXY.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "网格显示";            //更新标签说明文字
            labelItemShuoMing.Visible = true;               //显示标签说明
        }
        // 显示网络按钮 鼠标离开
        private void buttonLinesShowXY_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }
        // 显示网络按钮 绘图
        private void buttonLinesShowXY_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            Color colorD = new Color();
            if (!_isLinesShowXY)
            {
                buttonLinesShowXY.ForeColor = ControlButtonForeColorH;    //未选中时边框颜色
                colorD = ControlButtonForeColorH;
            }
            else
            {
                buttonLinesShowXY.ForeColor = ControlButtonForeColorL;    //选中时边框颜色
                colorD = ControlButtonForeColorL;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 30),
                Color.FromArgb(100, colorD), colorD))
            using (Pen pe = new Pen(brush, 1f))
            {
                pe.Color = colorD;
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                Grap.DrawLine(pe, 5, 27, 29, 27);           //画X轴
                Grap.DrawLine(pe, 5, 27, 5, 2);             //画Y轴
                pe.Brush = brush;
                pe.StartCap = LineCap.Flat;
                pe.EndCap = LineCap.Flat;
                for (int i = 11; i < 26; i += 5)
                {
                    Grap.DrawLine(pe, 6, i, 25, i);         //水平线
                    Grap.DrawLine(pe, i, 6, i, 26);         //垂直线
                }
            }

        }
        #endregion


        #region ** 放缩选取按钮 **
        // 放大选取按钮 单击
        private void buttonBigModeXY_Click(object sender, EventArgs e)
        {
            buttonBigModeXY.Enabled = false;                //禁用按钮
            buttonBigModeXY.Parent.Focus();                 //取消焦点
            if (_isShowBigSmallModeXY)                      //标记是否可显示放大按钮
            {
                //_isShowBigSmallModeXY = false;              //标记
                //放大选取框功能ToolStripMenuItem.Checked = false;
                //pictureBoxGraph.Cursor = Cursors.Arrow;     //箭头光标
                //pictureBoxBigXY.Visible = false;            //隐藏[波形放大框]
            }
            else
            {
                _isShowBigSmallModeXY = true;               //标记
                _isShowNumModeXY = false;                   //禁止显示坐标值
                _isAutoModeXY = false;                      //禁用自动切换坐标功能
                _isMoveModeXY = false;                      //禁用拖拽功能
                _isDefaultMoveModeXY = false;
                放大选取框功能ToolStripMenuItem.Checked = true;
                pictureBoxGraph.Cursor = Cursors.Cross;     //十字光标
            }
            pictureBoxDrag.Hide();
            labelShowNum.Hide();
            pictureBoxGraph.Refresh();                      //刷新界面
            panelItemsIN.Refresh();                         //刷新按钮显示
            buttonBigModeXY.Enabled = true;                 //启用按钮
        }
        // 放大选取按钮 鼠标经过
        private void buttonBigModeXY_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panelControlItem.Location.X - 100;
            po.Y = panelControlItem.Location.Y + buttonBigModeXY.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "放大选取框功能";      //更新标签说明文字
            labelItemShuoMing.Visible = true;               //显示标签说明
        }
        // 放大选取按钮 鼠标离开
        private void buttonBigModeXY_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }
        // 放大选取按钮 绘图
        private void buttonBigModeXY_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            Color colorD = new Color();
            if (!_isShowBigSmallModeXY)
            {
                buttonBigModeXY.ForeColor = ControlButtonForeColorH;    //未选中时边框颜色
                colorD = ControlButtonForeColorH;
            }
            else
            {
                buttonBigModeXY.ForeColor = ControlButtonForeColorL;    //选中时边框颜色
                colorD = ControlButtonForeColorL;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 30),
                Color.FromArgb(100, colorD), colorD))
            using (Pen pe = new Pen(brush, 1f))
            {
                pe.Color = colorD;
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                Grap.DrawLine(pe, 5, 27, 29, 27);           //画X轴
                Grap.DrawLine(pe, 5, 27, 5, 2);             //画Y轴
                //画矩形框
                pe.Brush = brush;
                pe.StartCap = LineCap.Flat;
                pe.EndCap = LineCap.Flat;
                pe.DashStyle = DashStyle.Dot;
                Grap.DrawRectangle(pe, 7, 7, 18, 18);
                //画边角
                pe.DashStyle = DashStyle.Solid;
                Grap.DrawLine(pe, 7, 7, 7, 12);
                Grap.DrawLine(pe, 7, 7, 12, 7);
                Grap.DrawLine(pe, 7, 25, 12, 25);
                Grap.DrawLine(pe, 7, 25, 7, 20);
                Grap.DrawLine(pe, 25, 7, 20, 7);
                Grap.DrawLine(pe, 25, 7, 25, 12);
                Grap.DrawLine(pe, 25, 25, 20, 25);
                Grap.DrawLine(pe, 25, 25, 25, 20);
                //画放大镜
                Grap.DrawEllipse(pe, 10, 10, 11, 11);
                pe.Width = 4;
                Grap.DrawLine(pe, 19, 19, 22, 22);

            }
        }
        #endregion


        #region ** 自动调整大小按钮 **
        // 自动调整大小按钮
        private void buttonAutoModeXY_Click(object sender, EventArgs e)
        {
            buttonAutoModeXY.Enabled = false;               //禁用按钮
            buttonAutoModeXY.Parent.Focus();                //取消焦点
            pictureBoxGraph.Cursor = Cursors.Arrow;         //箭头光标
            //重新初始化坐标值和坐标标定值
            _fXBegin = _fXBeginGO = _fXBeginSYS;
            _fYBegin = _fYBeginGO = _fYBeginSYS;
            _fXEnd = _fXEndGO = _fXEndSYS;
            _fYEnd = _fYEndGO = _fYEndSYS;
            _fXQuanBeginGO = _getQuan(_fXBeginGO);
            _fXQuanEndGO = _getQuan(_fXEndGO);
            _fYQuanBeginGO = _getQuan(_fYBeginGO);
            _fYQuanEndGO = _getQuan(_fYEndGO);
            if (_isAutoModeXY)                              //标记坐标是否自动调整
            {
                //_isAutoModeXY = false;                      //标记
                //坐标自动调整ToolStripMenuItem.Checked = false;
            }
            else
            {
                _isShowBigSmallModeXY = false;                  //标记，当前不允许放大选取框显示
                pictureBoxBigXY.Visible = false;                //隐藏[波形放大框]
                _isDefaultMoveModeXY = false;
                _isShowNumModeXY = false;
                放大选取框功能ToolStripMenuItem.Checked = false;
                _isAutoModeXY = true;                       //标记
                坐标自动调整ToolStripMenuItem.Checked = true;
            }
            pictureBoxDrag.Hide();
            labelShowNum.Hide();
            pictureBoxGraph.Refresh();                      //刷新界面
            panelItemsIN.Refresh();                         //刷新按钮显示
            buttonAutoModeXY.Enabled = true;                //启用按钮
        }
        // 自动调整大小按钮 鼠标经过
        private void buttonAutoModeXY_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panelControlItem.Location.X - 100;
            po.Y = panelControlItem.Location.Y + buttonAutoModeXY.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "坐标自动调整";        //更新标签说明文字
            labelItemShuoMing.Visible = true;               //显示标签说明
        }
        // 自动调整大小按钮 鼠标离开
        private void buttonAutoModeXY_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }
        // 自动调整大小按钮 绘图
        private void buttonAutoModeXY_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            Color colorD = new Color();
            if (!_isAutoModeXY)
            {
                buttonAutoModeXY.ForeColor = ControlButtonForeColorH;       //未选中时边框颜色
                colorD = ControlButtonForeColorH;
            }
            else
            {
                buttonAutoModeXY.ForeColor = ControlButtonForeColorL;       //选中时边框颜色
                colorD = ControlButtonForeColorL;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 29),
                Color.FromArgb(200, colorD), colorD))
            using (Pen pe = new Pen(brush, 1f))
            using (Font fo = new Font("宋体", 7))
            {
                pe.Color = colorD;
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                Grap.DrawLine(pe, 5, 27, 29, 27);           //画X轴
                Grap.DrawLine(pe, 5, 27, 5, 2);             //画Y轴
                //画文字
                Grap.DrawString("Auto", fo, brush, 6, 15);
                Grap.DrawString("Y", fo, brush, 7, 3);
                Grap.DrawString("X", fo, brush, 20, 6);

            }
        }
        #endregion


        #region ** 按默认坐标范围平移 **
        // 恢复默认坐标范围
        private void buttonReXY_Click(object sender, EventArgs e)
        {
            buttonReXY.Enabled = false;                     //禁用按钮
            buttonReXY.Parent.Focus();                      //取消焦点

            //初始化坐标值和坐标标定值
            _fXBegin = _fXBeginGO = _fXBeginSYS;
            _fYBegin = _fYBeginGO = _fYBeginSYS;
            _fXEnd = _fXEndGO = _fXEndSYS;
            _fYEnd = _fYEndGO = _fYEndSYS;
            _fXQuanBeginGO = _getQuan(_fXBeginGO);
            _fXQuanEndGO = _getQuan(_fXEndGO);
            _fYQuanBeginGO = _getQuan(_fYBeginGO);
            _fYQuanEndGO = _getQuan(_fYEndGO);

            if (_isDefaultMoveModeXY)
            {
                //_isDefaultMoveModeXY = false;
            }
            else
            {
                _isAutoModeXY = false;                          //标记，取消自动调整大小模式
                pictureBoxBigXY.Visible = false;                //隐藏[波形放大框]
                _isShowNumModeXY = false;
                _isMoveModeXY = false;
                _isShowBigSmallModeXY = false;
                坐标自动调整ToolStripMenuItem.Checked = false;
                _isDefaultMoveModeXY = true;
            }

            pictureBoxDrag.Hide();
            labelShowNum.Hide();
            pictureBoxGraph.Refresh();                      //刷新界面
            panelItemsIN.Refresh();                         //刷新按钮显示
            buttonReXY.Enabled = true;
            ;                    //启用按钮
        }
        // 恢复默认坐标范围 鼠标经过
        private void buttonReXY_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panelControlItem.Location.X - 100;
            po.Y = panelControlItem.Location.Y + buttonReXY.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "按默认坐标范围平移";        //更新标签说明文字
            labelItemShuoMing.Visible = true;               //显示标签说明
        }
        // 恢复默认坐标范围 鼠标离开
        private void buttonReXY_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }
        // 恢复默认坐标范围 绘图
        private void buttonReXY_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            Color colorD = new Color();

            if (!_isDefaultMoveModeXY)
            {
                buttonReXY.ForeColor = ControlButtonForeColorH;
                colorD = ControlButtonForeColorH;
                默认坐标范围ToolStripMenuItem.Checked = false;
            }
            else
            {
                buttonReXY.ForeColor = ControlButtonForeColorL;
                colorD = ControlButtonForeColorL;
                默认坐标范围ToolStripMenuItem.Checked = true;
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 29),
                Color.FromArgb(200, colorD), colorD))
            using (Pen pe = new Pen(brush, 1f))
            using (Font fo = new Font("宋体", 7))
            using (Font foR = new Font("宋体", 9))
            {
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                Grap.DrawLine(pe, 5, 27, 29, 27);           //画X轴
                Grap.DrawLine(pe, 5, 27, 5, 2);             //画Y轴
                //画文字
                Grap.DrawString("Re", foR, brush, 6, 14);
                Grap.DrawString("y", fo, brush, 7, 3);
                Grap.DrawString("x", fo, brush, 20, 6);

            }
        }
        #endregion


        #region ** 拖动波形 **
        private void buttonMoveModeXY_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panelControlItem.Location.X - 100;
            po.Y = panelControlItem.Location.Y + buttonMoveModeXY.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "拖动波形";        //更新标签说明文字
            labelItemShuoMing.Visible = true;
        }

        private void buttonMoveModeXY_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }

        private void buttonMoveModeXY_Click(object sender, EventArgs e)
        {
            buttonMoveModeXY.Enabled = false;               //禁用按钮
            buttonMoveModeXY.Parent.Focus();                //取消焦点
            if (_isMoveModeXY)                              //标记坐标是否自动调整
            {
                //_isMoveModeXY = false;
                //pictureBoxGraph.Cursor = Cursors.Arrow;         //箭头光标
                //波形拖动toolStripMenuItem1.Checked = false;
            }
            else
            {
                _isAutoModeXY = false;                          //标记，取消自动调整大小模式
                _isShowBigSmallModeXY = false;                  //标记，当前不允许放大选取框显示
                _isShowNumModeXY = false;                       //
                _isDefaultMoveModeXY = false;
                _isMoveModeXY = true;
                pictureBoxGraph.Cursor = Cursors.SizeAll;         //光标
                波形拖动toolStripMenuItem1.Checked = true;
            }
            pictureBoxDrag.Hide();
            labelShowNum.Hide();
            pictureBoxGraph.Refresh();                      //刷新界面
            panelItemsIN.Refresh();                         //刷新按钮显示
            buttonMoveModeXY.Enabled = true;                //启用按钮
        }
        private void buttonMoveModeXY_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            Color colorD = new Color();

            if (!_isMoveModeXY)
            {
                buttonMoveModeXY.ForeColor = ControlButtonForeColorH;       //未选中时边框颜色
                colorD = ControlButtonForeColorH;
                波形拖动toolStripMenuItem1.Checked = false;
            }
            else
            {
                buttonMoveModeXY.ForeColor = ControlButtonForeColorL;       //选中时边框颜色
                colorD = ControlButtonForeColorL;
                波形拖动toolStripMenuItem1.Checked = true;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 29),
                Color.FromArgb(200, colorD), colorD))
            using (Pen pe = new Pen(brush, 1f))
            using (Font fo = new Font("宋体", 7))
            {
                pe.Color = colorD;
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                Grap.DrawLine(pe, 5, 27, 29, 27);           //画X轴
                Grap.DrawLine(pe, 5, 27, 5, 2);             //画Y轴
                //画文字
                Grap.DrawString("Drag", fo, brush, 6, 15);
                Grap.DrawString("Y", fo, brush, 7, 3);
                Grap.DrawString("X", fo, brush, 20, 6);

            }
        }
        #endregion


        #region ** 显示曲线坐标 **
        private void buttonShowNumModeXY_Click(object sender, EventArgs e)
        {
            buttonShowNumModeXY.Enabled = false;               //禁用按钮
            buttonShowNumModeXY.Parent.Focus();                //取消焦点
            if (_isShowNumModeXY)                              //标记坐标是否自动调整
            {
                //_isShowNumModeXY = false;
                //pictureBoxGraph.Cursor = Cursors.Arrow;         //箭头光标
            }
            else
            {
                _isAutoModeXY = false;                             //标记，取消自动调整大小模式
                _isShowBigSmallModeXY = false;                     //标记，当前不允许放大选取框显示
                _isMoveModeXY = false;                             //不能拖拽
                _isShowNumModeXY = true;
                pictureBoxGraph.Cursor = Cursors.Hand;         //光标

            }
            pictureBoxDrag.Hide();
            labelShowNum.Hide();
            pictureBoxGraph.Refresh();                         //刷新界面
            panelItemsIN.Refresh();                            //刷新按钮显示
            buttonShowNumModeXY.Enabled = true;                //启用按钮


        }

        private void buttonShowNumModeXY_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panelControlItem.Location.X - 100;
            po.Y = panelControlItem.Location.Y + buttonShowNumModeXY.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "显示曲线坐标";        //更新标签说明文字
            labelItemShuoMing.Visible = true;
        }

        private void buttonShowNumModeXY_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }

        private void buttonShowNumModeXY_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            Color colorD = new Color();
            Point[] curve = new Point[3];
            curve[0].X = 5;
            curve[0].Y = 27;
            curve[1].X = 15;
            curve[1].Y = 17;
            curve[2].X = 25;
            curve[2].Y = 27;

            if (!_isShowNumModeXY)
            {
                buttonShowNumModeXY.ForeColor = ControlButtonForeColorH;       //未选中时边框颜色
                colorD = ControlButtonForeColorH;
            }
            else
            {
                buttonShowNumModeXY.ForeColor = ControlButtonForeColorL;       //选中时边框颜色
                colorD = ControlButtonForeColorL;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 29),
                Color.FromArgb(200, colorD), colorD))
            using (Pen pe = new Pen(brush, 1f))
            using (Font fo = new Font("宋体", 7))
            {
                pe.Color = colorD;
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                Grap.DrawLine(pe, 5, 27, 29, 27);           //画X轴
                Grap.DrawLine(pe, 5, 27, 5, 2);             //画Y轴
                //画文字
                Grap.DrawCurve(pe, curve);
                Grap.DrawString("(x,y)", fo, brush, 6, 6);
                Grap.DrawRectangle(pe, 11, 17, 4, 4);

            }
        }
        #endregion


        #region ** 截图 **
        private void buttonCutMapModeXY_Click(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;                //隐藏标签说明
            buttonCutMapModeXY.Enabled = false;               //禁用按钮
            buttonCutMapModeXY.Parent.Focus();                //取消焦点
            _isShowBigSmallModeXY = false;                    //标记，当前不允许放大选取框显示

            pictureBoxDrag.Hide();
            labelShowNum.Hide();
            pictureBoxGraph.Refresh();                      //刷新界面
            panelItemsIN.Refresh();                         //刷新按钮显示
            buttonCutMapModeXY.Enabled = true;              //启用按钮
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }
        private void buttonCutMapModeXY_MouseUp(object sender, MouseEventArgs e)
        {
            CutPic();                                       //截图
            MessageBox.Show("截图成功，文件保存在程序根目录下", "信息");
        }

        private void buttonCutMapModeXY_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panelControlItem.Location.X - 100;
            po.Y = panelControlItem.Location.Y + buttonCutMapModeXY.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "截图";                //更新标签说明文字
            labelItemShuoMing.Visible = true;               //显示标签说明
        }

        private void buttonCutMapModeXY_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;              //隐藏标签说明
        }

        private void buttonCutMapModeXY_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            buttonReXY.ForeColor = ControlButtonForeColorH;       //未选中边框颜色
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 29),
                ControlButtonForeColorH, ControlButtonForeColorH))
            using (Pen pe = new Pen(brush, 1f))
            using (Font fo = new Font("宋体", 7))
            using (Font foR = new Font("宋体", 9))
            {
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                Grap.DrawLine(pe, 5, 27, 29, 27);           //画X轴
                Grap.DrawLine(pe, 5, 27, 5, 2);             //画Y轴

                Grap.DrawRectangle(pe, 7, 7, 13, 13);
                Grap.DrawLine(pe, 18, 22, 26, 22);
                Grap.DrawLine(pe, 22, 18, 22, 26);
            }
        }
        #endregion


        #region ** 清屏 **
        private void buttonClearModeXY_Click(object sender, EventArgs e)
        {
            buttonClearModeXY.Enabled = false;                //禁用按钮
            buttonClearModeXY.Parent.Focus();                 //取消焦点
            _isAutoModeXY = false;                            //标记，取消自动调整大小模式
            _isShowBigSmallModeXY = false;                    //标记，当前不允许放大选取框显示
            _isMoveModeXY = false;                            //不能拖拽
            
            f_ClearAllPix();                                  //清屏

            _fXBegin = _fXBeginGO = _fXBeginSYS;
            _fYBegin = _fYBeginGO = _fYBeginSYS;
            _fXEnd = _fXEndGO = _fXEndSYS;
            _fYEnd = _fYEndGO = _fYEndSYS;
            _fXQuanBeginGO = _getQuan(_fXBeginGO);
            _fXQuanEndGO = _getQuan(_fXEndGO);
            _fYQuanBeginGO = _getQuan(_fYBeginGO);
            _fYQuanEndGO = _getQuan(_fYEndGO);

            pictureBoxGraph.Refresh();                      //刷新界面
            panelItemsIN.Refresh();                         //刷新按钮显示
            buttonClearModeXY.Enabled = true;
        }
        private void buttonClearModeXY_MouseEnter(object sender, EventArgs e)
        {
            Point po = new Point();
            po.X = panelControlItem.Location.X - 100;
            po.Y = panelControlItem.Location.Y + buttonClearModeXY.Location.Y;
            labelItemShuoMing.Location = po;                //更新标签说明坐标
            labelItemShuoMing.Text = "清屏";                //更新标签说明文字
            labelItemShuoMing.Visible = true;               //显示标签说明
        }

        private void buttonClearModeXY_MouseLeave(object sender, EventArgs e)
        {
            labelItemShuoMing.Visible = false;
        }

        private void buttonClearModeXY_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            buttonReXY.ForeColor = ControlButtonForeColorH;       //未选中边框颜色
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 29),
                ControlButtonForeColorH, ControlButtonForeColorH))
            using (Pen pe = new Pen(brush, 1f))
            using (Font fo = new Font("宋体", 7))
            using (Font foR = new Font("宋体", 9))
            {
                pe.StartCap = LineCap.SquareAnchor;
                pe.EndCap = LineCap.ArrowAnchor;
                Grap.DrawLine(pe, 5, 27, 29, 27);           //画X轴
                Grap.DrawLine(pe, 5, 27, 5, 2);             //画Y轴
            }
        }
        #endregion

        #endregion

        #region **私有方法** 波形显示控件 鼠标事件 波形放大缩小，拖动波形显示曲线坐标**

        private Point _pictureBoxBigXY_L;   //存放[波形放大方框]的起点坐标
        private Point _pictureBoxBigXY_R;   //存放鼠标移动时的坐标
        private Point _pictureBoxBigXY_M;   //存放最后调整后[波形放大框]的位置坐标
        private float _labelXYNumX;         //存放坐标显示Label的X值
        private float _labelXYNumY;         //存放坐标显示Label的Y值
        private Point _showNum = new Point(); //显示坐标框的坐标       

        //波形显示控件 鼠标按下
        private void pictureBoxGraph_MouseDown(object sender, MouseEventArgs e)
        {
            //[波形放大]操作：如果当前可以显示[波形放大框]并且鼠标左键按下
            if (_isShowBigSmallModeXY && e.Button == MouseButtons.Left)
            {
                pictureBoxGraph.Cursor = Cursors.Cross;         //十字光标
                pictureBoxBigXY.Visible = false;                //隐藏[波形放大框]               
                pictureBoxBigXY.Parent = pictureBoxGraph;       //父容器[波形放大框]
                _pictureBoxBigXY_L.X = e.Location.X;
                _pictureBoxBigXY_L.Y = e.Location.Y;
                pictureBoxBigXY.Location = _pictureBoxBigXY_L;  //更新[波形放大框]位置坐标
            }
            //如果当前为拖动模式下，左键按下
            if (_isMoveModeXY && e.Button == MouseButtons.Left)
            {
                _startMouse.X = e.X;                            //记录鼠标移动前的坐标
                _startMouse.Y = e.Y;
            }
          
            //如果是显示坐标的模式
            if (_isShowNumModeXY && e.Button == MouseButtons.Left)
            {
                ShowCoordinate(e);                
            }
            //鼠标右键按下，显示当前坐标
            if (e.Button == MouseButtons.Right)
            {
                _changeXYPointsToNum(e.Location.X, e.Location.Y, ref _labelXYNumX, ref _labelXYNumY);
                toolStripTextBoxX.Text = string.Format(" X：{0}", Math.Round(_labelXYNumX, _iAccuracy + 2));
                toolStripTextBoxY.Text = string.Format(" Y：{0}", Math.Round(_labelXYNumY, _iAccuracy + 2));
            }
        }

        //波形显示控件 鼠标移动
        private void pictureBoxGraph_MouseMove(object sender, MouseEventArgs e)
        {
            //[波形放大]操作
            //如果当前可以显示[波形放大框]并且鼠标左键按下
            if ( _isShowBigSmallModeXY && e.Button == MouseButtons.Left)
            {
                //获取鼠标当前坐标并调整[波形放大框]的位置坐标和大小，超出显示范围则取边界坐标
                if (e.Location.X > pictureBoxGraph.Width - 5)
                {
                    _pictureBoxBigXY_R.X = pictureBoxGraph.Width - 5;
                }
                else if (e.Location.X < 5)
                {
                    _pictureBoxBigXY_R.X = 5;
                }
                else
                {
                    _pictureBoxBigXY_R.X = e.Location.X;
                }
                if (e.Location.Y > pictureBoxGraph.Height - 5)
                {
                    _pictureBoxBigXY_R.Y = pictureBoxGraph.Height - 5;
                }
                else if (e.Location.Y < 5)
                {
                    _pictureBoxBigXY_R.Y = 5;
                }
                else
                {
                    _pictureBoxBigXY_R.Y = e.Location.Y;
                }
                //坐标调整，获取[波形放大框]的位置坐标
                _pictureBoxBigXY_M.X = (_pictureBoxBigXY_L.X < _pictureBoxBigXY_R.X) ? _pictureBoxBigXY_L.X : _pictureBoxBigXY_R.X;
                _pictureBoxBigXY_M.Y = (_pictureBoxBigXY_L.Y < _pictureBoxBigXY_R.Y) ? _pictureBoxBigXY_L.Y : _pictureBoxBigXY_R.Y;
                pictureBoxBigXY.Location = _pictureBoxBigXY_M;
                //[波形放大框]大小调整
                pictureBoxBigXY.Width = Math.Abs(_pictureBoxBigXY_R.X - _pictureBoxBigXY_L.X);
                pictureBoxBigXY.Height = Math.Abs(_pictureBoxBigXY_R.Y - _pictureBoxBigXY_L.Y);
                //显示[波形放大框]
                pictureBoxBigXY.Visible = true;
            }

            if (_isShowNumModeXY && e.Button == MouseButtons.Left)
            {
                ShowCoordinate(e);//显示曲线上坐标的实际值
            }

            if (_isMoveModeXY && e.Button == MouseButtons.Left)
            {
                ReChange(_startMouse.X - e.X, _startMouse.Y - e.Y);
                _startMouse.X = e.X;
                _startMouse.Y = e.Y;
            }
        }

        //波形显示控件 鼠标抬起
        private void pictureBoxGraph_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isShowBigSmallModeXY && e.Button == MouseButtons.Right)
            {
                MenuRightClick.Hide();//不显示右键弹出菜单
                _Reduce(e.X, e.Y, 1);     // 缩小波形图          
            }
            //[波形放大]操作
            //如果当前可以显示[波形放大框]并且鼠标左键曾按下，并且[波形放大框]足够大
            if (_isShowBigSmallModeXY && e.Button == MouseButtons.Left && pictureBoxBigXY.Width > 10 && pictureBoxBigXY.Height > 10)
            {
                pictureBoxBigXY.Visible = false;                    //隐藏[波形放大框]                
                _Magnify();
            }
        }

        //波形放大操作框 放大按钮
        private void buttonBigXYBig_Click(object sender, EventArgs e)
        {
            pictureBoxBigXY.Visible = false;                           //隐藏[波形放大框]
            _isDefaultMoveModeXY = false;                                       //标记，启用放大查看模式
            _isAutoModeXY = false;                                     //标记，取消自动调整大小模式
            坐标自动调整ToolStripMenuItem.Checked = false;
            //转换坐标为实际值，更新波形显示控件坐标值
            if (_fXEnd - _fXBegin < 1.0f || _fYEnd - _fYBegin < 1.0f)
            {
                return;
            }                                                //防止放大到数据溢出的程度
            _changeXYPointsToNum(pictureBoxBigXY.Location.X, pictureBoxBigXY.Location.X + pictureBoxBigXY.Width,
                pictureBoxBigXY.Location.Y, pictureBoxBigXY.Location.Y + pictureBoxBigXY.Height,
                ref _fXBegin, ref _fXEnd, ref _fYBegin, ref _fYEnd);
            pictureBoxGraph.Refresh();                                 //更新显示
            panelItemsIN.Refresh();                                    //刷新按钮显示
        }

        //波形放大操作框 取消放大按钮
        private void buttonBigXYQuit_Click(object sender, EventArgs e)
        {
            pictureBoxBigXY.Visible = false;                    //隐藏[波形放大框]
        }

        #endregion
    }
}
