using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Pengpai.UI
{
    public partial class ZGraph : UserControl
    {
        /***************************************
         *  模块：公共函数接口模块
         *  设计人：xf_z1988
         *  修改人：Pengpai
         *  原始文章在博客园的位置：
         *  http://www.cnblogs.com/xf_z1988/archive/2010/05/11/CSharp_WinForm_Waveform.html 
         *  升级文章在博客园的位置：
         *  http://www.cnblogs.com/pengpai/archive/2013/05/19/3086778.html
         *  原作者联系方式：zhengxuanfan@Gmail.com
         *  修改者联系方式：250421696@qq.com
         * ************************************/
        #region **清空所有加载的波形数据 f_ClearAllPix():void **
        /// <summary>
        /// 清空所有加载的波形数据并清空显示
        /// </summary>
        public void f_ClearAllPix()
        {
            //重新初始化
            _listX.Clear();
            _listY.Clear();
            _haveFile.Clear();
            _filePath.Clear();
            _listColor.Clear();
            _listWidth.Clear();
            _listLineJoin.Clear();
            _listLineCap.Clear();
            _listDrawStyle.Clear();
            //更新
            pictureBoxGraph.Refresh();
        }
        #endregion

        #region **重新初始化X轴和Y轴坐标 void f_reXY() **
        /// <summary>
        /// 重新初始化X轴和Y轴坐标
        /// </summary>
        public void f_reXY()
        {
            buttonReXY_Click(null, null);
            buttonAutoModeXY_Click(null, null);
        }
        #endregion

        #region **更新显示 f_Refresh():void **
        /// <summary>
        /// 更新显示
        /// </summary>
        public void f_Refresh()
        {
            pictureBoxGraph.Refresh();
        }
        #endregion

        #region **设置波形控件初始化状态**
        /// <summary>
        /// 波形控件初始化状态
        /// </summary>
        public enum GraphStyle
        {
            /// <summary>
            /// 自动调整坐标模式
            /// </summary>
            AutoMode,
            /// <summary>
            /// 按默认坐标范围平移
            /// </summary>
            DefaultMoveMode,
            /// <summary>
            /// 正常显示模式
            /// </summary>
            None
        }
       /// <summary>
       /// 初始化波形控件
       /// </summary>
       /// <param name="mode">初始化模式</param>
        public void f_InitMode(GraphStyle mode)
        {
            switch (mode)
            {
                case GraphStyle.AutoMode:
                    _isAutoModeXY = true;
                    _isDefaultMoveModeXY = false;
                    break;
                case GraphStyle.DefaultMoveMode:
                    _isAutoModeXY = false;
                    _isDefaultMoveModeXY = true;
                    break;
                case GraphStyle.None:
                    _isAutoModeXY = false;
                    _isDefaultMoveModeXY = false;
                    break;
                default:
                    break;
                    
            }
            Refresh();            
        }
        #endregion

        #region **清空原有数据并加载一条波形数据**
        /// <summary>
        /// 清空原有数据并加载一条波形数据
        /// </summary>
        /// <param name="listX">X轴</param>
        /// <param name="listY">Y轴</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        /// <param name="listLineJoin">线条连接点</param>
        /// <param name="listLineCap">线条起始线帽</param>
        /// <param name="listDrawStyle">线条样式</param>
        public void f_LoadOnePix( List<float> listX,  List<float> listY, Color listColor, int listWidth, LineJoin listLineJoin, LineCap listLineCap, DrawStyle listDrawStyle)
        {
            //重新初始化
            f_ClearAllPix();
            //装载
            _listX.Add(listX);
            _listY.Add(listY);
            _filePath.Add(null);
            _haveFile.Add(false);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(listLineJoin);
            _listLineCap.Add(listLineCap);
            _listDrawStyle.Add(listDrawStyle);

        }
        /// <summary>
        /// 清空原有数据并加载一条波形数据，显示样式为线条
        /// </summary>
        /// <param name="listX">X轴</param>
        /// <param name="listY">Y轴</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        public void f_LoadOnePix( List<float> listX,  List<float> listY, Color listColor, int listWidth)
        {
            //重新初始化
            f_ClearAllPix();
            //装载
            _listX.Add(listX);
            _listY.Add(listY);
            _filePath.Add(null);
            _haveFile.Add(false);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(LineJoin.Bevel);
            _listLineCap.Add(LineCap.NoAnchor);
            _listDrawStyle.Add(DrawStyle.Line);

        }
        /// <summary>
        /// 清空原有数据并加载一条波形数据,文件和链表混排
        /// </summary>
        /// <param name="wavePath">波形文件位置</param>
        /// <param name="listX">X轴</param>
        /// <param name="listY">Y轴</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        /// <param name="listLineJoin">线条连接点</param>
        /// <param name="listLineCap">线条起始线帽</param>
        /// <param name="listDrawStyle">线条样式</param>
        public void f_LoadOnePix(string wavePath, List<float> listX, List<float> listY, Color listColor, int listWidth, LineJoin listLineJoin, LineCap listLineCap, DrawStyle listDrawStyle)
        {
            //重新初始化
            f_ClearAllPix();
            //装载
            _listX.Add(listX);
            _listY.Add(listY);
            _filePath.Add(wavePath);
            _haveFile.Add(true);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(listLineJoin);
            _listLineCap.Add(listLineCap);
            _listDrawStyle.Add(listDrawStyle);
        }

        /// <summary>
        /// 清空原有数据并加载一条波形数据，显示样式为线条，文件和链表混排
        /// </summary>
        /// <param name="wavePath">波形文件位置</param>
        /// <param name="listX">X轴</param>
        /// <param name="listY">Y轴</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        public void f_LoadOnePix(string wavePath, List<float> listX, List<float> listY, Color listColor, int listWidth)
        {
            //重新初始化
            f_ClearAllPix();
            //装载
            _listX.Add(listX);
            _listY.Add(listY);
            _filePath.Add(wavePath);
            _haveFile.Add(true);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(LineJoin.Bevel);
            _listLineCap.Add(LineCap.NoAnchor);
            _listDrawStyle.Add(DrawStyle.Line);

        }

        /// <summary>
        /// 清空原有数据并加载一条波形数据，只读取文件数据
        /// </summary>
        /// <param name="wavePath">波形文件位置</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        /// <param name="listLineJoin">线条连接点</param>
        /// <param name="listLineCap">线条起始线帽</param>
        /// <param name="listDrawStyle">线条样式</param>
        public void f_LoadOnePix(string wavePath, Color listColor, int listWidth, LineJoin listLineJoin, LineCap listLineCap, DrawStyle listDrawStyle)
        {
            //重新初始化
            f_ClearAllPix();
            //装载
            _listX.Add(null);
            _listY.Add(null);
            _filePath.Add(wavePath);
            _haveFile.Add(true);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(listLineJoin);
            _listLineCap.Add(listLineCap);
            _listDrawStyle.Add(listDrawStyle);
        }

        /// <summary>
        /// 清空原有数据并加载一条波形数据，显示样式为线条，只读取文件数据
        /// </summary>
        /// <param name="wavePath">波形文件位置</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        public void f_LoadOnePix(string wavePath, Color listColor, int listWidth)
        {
            //重新初始化
            f_ClearAllPix();
            //装载
            _listX.Add(null);
            _listY.Add(null);
            _filePath.Add(wavePath);
            _haveFile.Add(true);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(LineJoin.Bevel);
            _listLineCap.Add(LineCap.NoAnchor);
            _listDrawStyle.Add(DrawStyle.Line);
        }
        #endregion

        #region **在原有波形上添加一条波形数据 **
        /// <summary>
        /// 在原有波形上添加一条线
        /// 不可动态循环
        /// </summary>
        /// <param name="listX">X轴</param>
        /// <param name="listY">Y轴</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        /// <param name="listLineJoin">线条连接点</param>
        /// <param name="listLineCap">线条起始线帽</param>
        /// <param name="listDrawStyle">线条样式</param>
        public void f_AddPix( List<float> listX,  List<float> listY, Color listColor, int listWidth, LineJoin listLineJoin, LineCap listLineCap, DrawStyle listDrawStyle)
        {
            //装载
            _listX.Add(listX);
            _listY.Add(listY);
            _filePath.Add(null);
            _haveFile.Add(false);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(listLineJoin);
            _listLineCap.Add(listLineCap);
            _listDrawStyle.Add(listDrawStyle);
        }
        /// <summary>
        /// 在原有波形上添加一条线，显示样式为线条
        /// 不可动态循环
        /// </summary>
        /// <param name="listX">X轴</param>
        /// <param name="listY">Y轴</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>        
        public void f_AddPix( List<float> listX,  List<float> listY, Color listColor, int listWidth)
        {
            //装载
            _listX.Add(listX);
            _listY.Add(listY);
            _filePath.Add(null);
            _haveFile.Add(false);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(LineJoin.Bevel);
            _listLineCap.Add(LineCap.NoAnchor);
            _listDrawStyle.Add(DrawStyle.Line);
        }
        /// <summary>
        /// 在原有波形上添加一条线,文件和链表混排
        /// </summary>
        /// <param name="wavePath">波形文件位置</param>
        /// <param name="listX">X轴</param>
        /// <param name="listY">Y轴</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        /// <param name="listLineJoin">线条连接点</param>
        /// <param name="listLineCap">线条起始线帽</param>
        /// <param name="listDrawStyle">线条样式</param>
        public void f_AddPix(string wavePath, List<float> listX, List<float> listY, Color listColor, int listWidth, LineJoin listLineJoin, LineCap listLineCap, DrawStyle listDrawStyle)
        {
            //装载
            _listX.Add(listX);
            _listY.Add(listY);
            _filePath.Add(wavePath);
            _haveFile.Add(true);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(listLineJoin);
            _listLineCap.Add(listLineCap);
            _listDrawStyle.Add(listDrawStyle);
        }
        /// <summary>
        /// 在原有波形上添加一条线，显示样式为线条，文件和链表混排
        /// </summary>
        /// <param name="wavePath">波形文件位置</param>
        /// <param name="listX">X轴</param>
        /// <param name="listY">Y轴</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        public void f_AddPix(string wavePath, List<float> listX, List<float> listY, Color listColor, int listWidth)
        {
            //装载
            _listX.Add(listX);
            _listY.Add(listY);
            _filePath.Add(wavePath);
            _haveFile.Add(true);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(LineJoin.Bevel);
            _listLineCap.Add(LineCap.NoAnchor);
            _listDrawStyle.Add(DrawStyle.Line);
        }

        /// <summary>
        /// 在原有波形上添加一条线,只显示文件数据
        /// </summary>
        /// <param name="wavePath">波形文件位置</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        /// <param name="listLineJoin">线条连接点</param>
        /// <param name="listLineCap">线条起始线帽</param>
        /// <param name="listDrawStyle">线条样式</param>
        public void f_AddPix(string wavePath, Color listColor, int listWidth, LineJoin listLineJoin, LineCap listLineCap, DrawStyle listDrawStyle)
        {
            //装载
            _listX.Add(null);
            _listY.Add(null);
            _filePath.Add(wavePath);
            _haveFile.Add(true);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(listLineJoin);
            _listLineCap.Add(listLineCap);
            _listDrawStyle.Add(listDrawStyle);
        }
        /// <summary>
        /// 在原有波形上添加一条线，显示样式为线条，只显示文件数据
        /// </summary>
        /// <param name="wavePath">波形文件位置</param>
        /// <param name="listColor">线条颜色</param>
        /// <param name="listWidth">线条宽度</param>
        public void f_AddPix(string wavePath, Color listColor, int listWidth)
        {
            //装载
            _listX.Add(null);
            _listY.Add(null);
            _filePath.Add(wavePath);
            _haveFile.Add(true);
            _listColor.Add(listColor);
            _listWidth.Add(listWidth);
            _listLineJoin.Add(LineJoin.Bevel);
            _listLineCap.Add(LineCap.NoAnchor);
            _listDrawStyle.Add(DrawStyle.Line);
        }
        #endregion

        #region ** 清除其中一个波形 **

        /// <summary>
        /// 清楚一个波形
        /// </summary>
        /// <param name="index">波形的索引号</param>
        public void f_ClearAWave(int index)
        {
            _listX.RemoveAt(index);
            _listY.RemoveAt(index);
            _haveFile.RemoveAt(index);
            _filePath.RemoveAt(index);
            _listColor.RemoveAt(index);
            _listWidth.RemoveAt(index);
            _listLineJoin.RemoveAt(index);
            _listLineCap.RemoveAt(index);
            _listDrawStyle.RemoveAt(index);
        }
        #endregion

    }
}
