#region **引用**
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
#endregion

namespace Pengpai.UI              
{
    /// <summary>
    /// 波形显示控件
    /// 坐标最小差值：1.0
    /// </summary>
    public partial class ZGraph : UserControl
    {
        /***************************************
         *  模块：波形显示控件
         *  设计人：xf_z1988
         *  修改人：Pengpai
         *  原始文章在博客园的位置：
         *  http://www.cnblogs.com/xf_z1988/archive/2010/05/11/CSharp_WinForm_Waveform.html 
         *  升级文章在博客园的位置：
         *  http://www.cnblogs.com/pengpai/archive/2013/05/19/3086778.html
         *  原作者联系方式：zhengxuanfan@Gmail.com
         *  修改者联系方式：250421696@qq.com
         * ************************************/
        /// <summary>
        /// 构造
        /// 初始化坐标值，坐标标定值，坐标标定权值
        /// </summary>
        public ZGraph()
        {
            InitializeComponent();
            //初始化默认坐标值，坐标标定值和坐标标定权值
            _fXBegin = _fXBeginGO = _fXBeginSYS;
            _fYBegin = _fYBeginGO = _fYBeginSYS;
            _fXEnd = _fXEndGO = _fXEndSYS;
            _fYEnd = _fYEndGO = _fYEndSYS;
            _fXQuanBeginGO = _getQuan(_fXBeginGO);
            _fXQuanEndGO = _getQuan(_fXEndGO);
            _fYQuanBeginGO = _getQuan(_fYBeginGO);
            _fYQuanEndGO = _getQuan(_fYEndGO);
        }
    }
}
