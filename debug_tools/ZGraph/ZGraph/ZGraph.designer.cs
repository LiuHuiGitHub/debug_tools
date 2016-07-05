using System.Windows.Forms;
namespace Pengpai.UI
{
    partial class ZGraph
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxBottom = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxTop = new System.Windows.Forms.PictureBox();
            this.buttonLinesShowXY = new System.Windows.Forms.Button();
            this.panelControlItem = new System.Windows.Forms.Panel();
            this.panelItemsIN = new System.Windows.Forms.Panel();
            this.buttonReXY = new System.Windows.Forms.Button();
            this.buttonAutoModeXY = new System.Windows.Forms.Button();
            this.buttonClearModeXY = new System.Windows.Forms.Button();
            this.buttonCutMapModeXY = new System.Windows.Forms.Button();
            this.buttonShowNumModeXY = new System.Windows.Forms.Button();
            this.buttonMoveModeXY = new System.Windows.Forms.Button();
            this.buttonBigModeXY = new System.Windows.Forms.Button();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.MenuRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBoxX = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxY = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.网格显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大选取框功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坐标自动调整ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.默认坐标范围ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.波形拖动toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelItemShuoMing = new System.Windows.Forms.Label();
            this.pictureBoxBigXY = new System.Windows.Forms.PictureBox();
            this.pictureBoxDrag = new System.Windows.Forms.PictureBox();
            this.labelShowNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTop)).BeginInit();
            this.panelControlItem.SuspendLayout();
            this.panelItemsIN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.MenuRightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBigXY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDrag)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBottom
            // 
            this.pictureBoxBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxBottom.BackColor = System.Drawing.Color.White;
            this.pictureBoxBottom.ErrorImage = null;
            this.pictureBoxBottom.InitialImage = null;
            this.pictureBoxBottom.Location = new System.Drawing.Point(-1, 359);
            this.pictureBoxBottom.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxBottom.MinimumSize = new System.Drawing.Size(0, 45);
            this.pictureBoxBottom.Name = "pictureBoxBottom";
            this.pictureBoxBottom.Size = new System.Drawing.Size(456, 45);
            this.pictureBoxBottom.TabIndex = 0;
            this.pictureBoxBottom.TabStop = false;
            this.pictureBoxBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxBottom_Paint);
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxLeft.BackColor = System.Drawing.Color.White;
            this.pictureBoxLeft.ErrorImage = null;
            this.pictureBoxLeft.InitialImage = null;
            this.pictureBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxLeft.MinimumSize = new System.Drawing.Size(50, 0);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(50, 359);
            this.pictureBoxLeft.TabIndex = 1;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxLeft_Paint);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxRight.BackColor = System.Drawing.Color.White;
            this.pictureBoxRight.ErrorImage = null;
            this.pictureBoxRight.InitialImage = null;
            this.pictureBoxRight.Location = new System.Drawing.Point(404, 0);
            this.pictureBoxRight.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxRight.MinimumSize = new System.Drawing.Size(50, 0);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(50, 359);
            this.pictureBoxRight.TabIndex = 2;
            this.pictureBoxRight.TabStop = false;
            this.pictureBoxRight.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxRight_Paint);
            // 
            // pictureBoxTop
            // 
            this.pictureBoxTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTop.BackColor = System.Drawing.Color.White;
            this.pictureBoxTop.ErrorImage = null;
            this.pictureBoxTop.InitialImage = null;
            this.pictureBoxTop.Location = new System.Drawing.Point(50, 0);
            this.pictureBoxTop.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxTop.MinimumSize = new System.Drawing.Size(0, 30);
            this.pictureBoxTop.Name = "pictureBoxTop";
            this.pictureBoxTop.Size = new System.Drawing.Size(354, 30);
            this.pictureBoxTop.TabIndex = 3;
            this.pictureBoxTop.TabStop = false;
            this.pictureBoxTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTop_Paint);
            // 
            // buttonLinesShowXY
            // 
            this.buttonLinesShowXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLinesShowXY.BackColor = System.Drawing.Color.Black;
            this.buttonLinesShowXY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLinesShowXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLinesShowXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLinesShowXY.ForeColor = System.Drawing.Color.White;
            this.buttonLinesShowXY.Location = new System.Drawing.Point(1, 1);
            this.buttonLinesShowXY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.buttonLinesShowXY.Name = "buttonLinesShowXY";
            this.buttonLinesShowXY.Size = new System.Drawing.Size(32, 32);
            this.buttonLinesShowXY.TabIndex = 5;
            this.buttonLinesShowXY.TabStop = false;
            this.buttonLinesShowXY.UseVisualStyleBackColor = false;
            this.buttonLinesShowXY.Click += new System.EventHandler(this.buttonLinesShowXY_Click);
            this.buttonLinesShowXY.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonLinesShowXY_Paint);
            this.buttonLinesShowXY.MouseEnter += new System.EventHandler(this.buttonLinesShowXY_MouseEnter);
            this.buttonLinesShowXY.MouseLeave += new System.EventHandler(this.buttonLinesShowXY_MouseLeave);
            // 
            // panelControlItem
            // 
            this.panelControlItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControlItem.AutoScroll = true;
            this.panelControlItem.BackColor = System.Drawing.Color.Black;
            this.panelControlItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelControlItem.Controls.Add(this.panelItemsIN);
            this.panelControlItem.Location = new System.Drawing.Point(405, 30);
            this.panelControlItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.panelControlItem.Name = "panelControlItem";
            this.panelControlItem.Size = new System.Drawing.Size(36, 329);
            this.panelControlItem.TabIndex = 6;
            // 
            // panelItemsIN
            // 
            this.panelItemsIN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelItemsIN.BackColor = System.Drawing.Color.Transparent;
            this.panelItemsIN.Controls.Add(this.buttonReXY);
            this.panelItemsIN.Controls.Add(this.buttonAutoModeXY);
            this.panelItemsIN.Controls.Add(this.buttonClearModeXY);
            this.panelItemsIN.Controls.Add(this.buttonCutMapModeXY);
            this.panelItemsIN.Controls.Add(this.buttonShowNumModeXY);
            this.panelItemsIN.Controls.Add(this.buttonMoveModeXY);
            this.panelItemsIN.Controls.Add(this.buttonBigModeXY);
            this.panelItemsIN.Controls.Add(this.buttonLinesShowXY);
            this.panelItemsIN.Location = new System.Drawing.Point(1, 10);
            this.panelItemsIN.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.panelItemsIN.Name = "panelItemsIN";
            this.panelItemsIN.Size = new System.Drawing.Size(34, 307);
            this.panelItemsIN.TabIndex = 9;
            // 
            // buttonReXY
            // 
            this.buttonReXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReXY.BackColor = System.Drawing.Color.Black;
            this.buttonReXY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonReXY.ForeColor = System.Drawing.Color.White;
            this.buttonReXY.Location = new System.Drawing.Point(1, 100);
            this.buttonReXY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.buttonReXY.Name = "buttonReXY";
            this.buttonReXY.Size = new System.Drawing.Size(32, 32);
            this.buttonReXY.TabIndex = 14;
            this.buttonReXY.TabStop = false;
            this.buttonReXY.UseVisualStyleBackColor = false;
            this.buttonReXY.Click += new System.EventHandler(this.buttonReXY_Click);
            this.buttonReXY.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonReXY_Paint);
            this.buttonReXY.MouseEnter += new System.EventHandler(this.buttonReXY_MouseEnter);
            this.buttonReXY.MouseLeave += new System.EventHandler(this.buttonReXY_MouseLeave);
            // 
            // buttonAutoModeXY
            // 
            this.buttonAutoModeXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoModeXY.BackColor = System.Drawing.Color.Black;
            this.buttonAutoModeXY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAutoModeXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAutoModeXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAutoModeXY.ForeColor = System.Drawing.Color.White;
            this.buttonAutoModeXY.Location = new System.Drawing.Point(1, 67);
            this.buttonAutoModeXY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.buttonAutoModeXY.Name = "buttonAutoModeXY";
            this.buttonAutoModeXY.Size = new System.Drawing.Size(32, 32);
            this.buttonAutoModeXY.TabIndex = 14;
            this.buttonAutoModeXY.TabStop = false;
            this.buttonAutoModeXY.UseVisualStyleBackColor = false;
            this.buttonAutoModeXY.Click += new System.EventHandler(this.buttonAutoModeXY_Click);
            this.buttonAutoModeXY.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonAutoModeXY_Paint);
            this.buttonAutoModeXY.MouseEnter += new System.EventHandler(this.buttonAutoModeXY_MouseEnter);
            this.buttonAutoModeXY.MouseLeave += new System.EventHandler(this.buttonAutoModeXY_MouseLeave);
            // 
            // buttonClearModeXY
            // 
            this.buttonClearModeXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearModeXY.BackColor = System.Drawing.Color.Black;
            this.buttonClearModeXY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearModeXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearModeXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClearModeXY.ForeColor = System.Drawing.Color.White;
            this.buttonClearModeXY.Location = new System.Drawing.Point(1, 277);
            this.buttonClearModeXY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.buttonClearModeXY.Name = "buttonClearModeXY";
            this.buttonClearModeXY.Size = new System.Drawing.Size(32, 30);
            this.buttonClearModeXY.TabIndex = 15;
            this.buttonClearModeXY.TabStop = false;
            this.buttonClearModeXY.UseVisualStyleBackColor = false;
            this.buttonClearModeXY.Click += new System.EventHandler(this.buttonClearModeXY_Click);
            this.buttonClearModeXY.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonClearModeXY_Paint);
            this.buttonClearModeXY.MouseEnter += new System.EventHandler(this.buttonClearModeXY_MouseEnter);
            this.buttonClearModeXY.MouseLeave += new System.EventHandler(this.buttonClearModeXY_MouseLeave);
            // 
            // buttonCutMapModeXY
            // 
            this.buttonCutMapModeXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCutMapModeXY.BackColor = System.Drawing.Color.Black;
            this.buttonCutMapModeXY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCutMapModeXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCutMapModeXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCutMapModeXY.ForeColor = System.Drawing.Color.White;
            this.buttonCutMapModeXY.Location = new System.Drawing.Point(0, 199);
            this.buttonCutMapModeXY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.buttonCutMapModeXY.Name = "buttonCutMapModeXY";
            this.buttonCutMapModeXY.Size = new System.Drawing.Size(32, 32);
            this.buttonCutMapModeXY.TabIndex = 14;
            this.buttonCutMapModeXY.TabStop = false;
            this.buttonCutMapModeXY.UseVisualStyleBackColor = false;
            this.buttonCutMapModeXY.Click += new System.EventHandler(this.buttonCutMapModeXY_Click);
            this.buttonCutMapModeXY.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonCutMapModeXY_Paint);
            this.buttonCutMapModeXY.MouseEnter += new System.EventHandler(this.buttonCutMapModeXY_MouseEnter);
            this.buttonCutMapModeXY.MouseLeave += new System.EventHandler(this.buttonCutMapModeXY_MouseLeave);
            this.buttonCutMapModeXY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonCutMapModeXY_MouseUp);
            // 
            // buttonShowNumModeXY
            // 
            this.buttonShowNumModeXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowNumModeXY.BackColor = System.Drawing.Color.Black;
            this.buttonShowNumModeXY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShowNumModeXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowNumModeXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonShowNumModeXY.ForeColor = System.Drawing.Color.White;
            this.buttonShowNumModeXY.Location = new System.Drawing.Point(0, 166);
            this.buttonShowNumModeXY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.buttonShowNumModeXY.Name = "buttonShowNumModeXY";
            this.buttonShowNumModeXY.Size = new System.Drawing.Size(32, 32);
            this.buttonShowNumModeXY.TabIndex = 13;
            this.buttonShowNumModeXY.TabStop = false;
            this.buttonShowNumModeXY.UseVisualStyleBackColor = false;
            this.buttonShowNumModeXY.Click += new System.EventHandler(this.buttonShowNumModeXY_Click);
            this.buttonShowNumModeXY.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonShowNumModeXY_Paint);
            this.buttonShowNumModeXY.MouseEnter += new System.EventHandler(this.buttonShowNumModeXY_MouseEnter);
            this.buttonShowNumModeXY.MouseLeave += new System.EventHandler(this.buttonShowNumModeXY_MouseLeave);
            // 
            // buttonMoveModeXY
            // 
            this.buttonMoveModeXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveModeXY.BackColor = System.Drawing.Color.Black;
            this.buttonMoveModeXY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMoveModeXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMoveModeXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonMoveModeXY.ForeColor = System.Drawing.Color.White;
            this.buttonMoveModeXY.Location = new System.Drawing.Point(0, 133);
            this.buttonMoveModeXY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.buttonMoveModeXY.Name = "buttonMoveModeXY";
            this.buttonMoveModeXY.Size = new System.Drawing.Size(32, 32);
            this.buttonMoveModeXY.TabIndex = 12;
            this.buttonMoveModeXY.TabStop = false;
            this.buttonMoveModeXY.UseVisualStyleBackColor = false;
            this.buttonMoveModeXY.Click += new System.EventHandler(this.buttonMoveModeXY_Click);
            this.buttonMoveModeXY.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonMoveModeXY_Paint);
            this.buttonMoveModeXY.MouseEnter += new System.EventHandler(this.buttonMoveModeXY_MouseEnter);
            this.buttonMoveModeXY.MouseLeave += new System.EventHandler(this.buttonMoveModeXY_MouseLeave);
            // 
            // buttonBigModeXY
            // 
            this.buttonBigModeXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBigModeXY.BackColor = System.Drawing.Color.Black;
            this.buttonBigModeXY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBigModeXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBigModeXY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonBigModeXY.ForeColor = System.Drawing.Color.White;
            this.buttonBigModeXY.Location = new System.Drawing.Point(1, 34);
            this.buttonBigModeXY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.buttonBigModeXY.Name = "buttonBigModeXY";
            this.buttonBigModeXY.Size = new System.Drawing.Size(32, 32);
            this.buttonBigModeXY.TabIndex = 10;
            this.buttonBigModeXY.TabStop = false;
            this.buttonBigModeXY.UseVisualStyleBackColor = false;
            this.buttonBigModeXY.Click += new System.EventHandler(this.buttonBigModeXY_Click);
            this.buttonBigModeXY.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonBigModeXY_Paint);
            this.buttonBigModeXY.MouseEnter += new System.EventHandler(this.buttonBigModeXY_MouseEnter);
            this.buttonBigModeXY.MouseLeave += new System.EventHandler(this.buttonBigModeXY_MouseLeave);
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGraph.BackColor = System.Drawing.Color.Black;
            this.pictureBoxGraph.ContextMenuStrip = this.MenuRightClick;
            this.pictureBoxGraph.ErrorImage = null;
            this.pictureBoxGraph.InitialImage = null;
            this.pictureBoxGraph.Location = new System.Drawing.Point(50, 30);
            this.pictureBoxGraph.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(354, 329);
            this.pictureBoxGraph.TabIndex = 4;
            this.pictureBoxGraph.TabStop = false;
            this.pictureBoxGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGraph_Paint);
            this.pictureBoxGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseDown);
            this.pictureBoxGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseMove);
            this.pictureBoxGraph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseUp);
            // 
            // MenuRightClick
            // 
            this.MenuRightClick.BackColor = System.Drawing.Color.White;
            this.MenuRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxX,
            this.toolStripTextBoxY,
            this.toolStripSeparator1,
            this.网格显示ToolStripMenuItem,
            this.放大选取框功能ToolStripMenuItem,
            this.坐标自动调整ToolStripMenuItem,
            this.默认坐标范围ToolStripMenuItem,
            this.波形拖动toolStripMenuItem1});
            this.MenuRightClick.Name = "MenuRightClick";
            this.MenuRightClick.Size = new System.Drawing.Size(161, 156);
            // 
            // toolStripTextBoxX
            // 
            this.toolStripTextBoxX.BackColor = System.Drawing.Color.White;
            this.toolStripTextBoxX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.toolStripTextBoxX.Name = "toolStripTextBoxX";
            this.toolStripTextBoxX.ReadOnly = true;
            this.toolStripTextBoxX.Size = new System.Drawing.Size(100, 16);
            this.toolStripTextBoxX.Text = "0";
            // 
            // toolStripTextBoxY
            // 
            this.toolStripTextBoxY.BackColor = System.Drawing.Color.White;
            this.toolStripTextBoxY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBoxY.ForeColor = System.Drawing.Color.Black;
            this.toolStripTextBoxY.Name = "toolStripTextBoxY";
            this.toolStripTextBoxY.ReadOnly = true;
            this.toolStripTextBoxY.Size = new System.Drawing.Size(100, 16);
            this.toolStripTextBoxY.Text = "0";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // 网格显示ToolStripMenuItem
            // 
            this.网格显示ToolStripMenuItem.Checked = true;
            this.网格显示ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.网格显示ToolStripMenuItem.Name = "网格显示ToolStripMenuItem";
            this.网格显示ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.网格显示ToolStripMenuItem.Text = "网格显示";
            this.网格显示ToolStripMenuItem.Click += new System.EventHandler(this.buttonLinesShowXY_Click);
            // 
            // 放大选取框功能ToolStripMenuItem
            // 
            this.放大选取框功能ToolStripMenuItem.Name = "放大选取框功能ToolStripMenuItem";
            this.放大选取框功能ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.放大选取框功能ToolStripMenuItem.Text = "放大选取框功能";
            this.放大选取框功能ToolStripMenuItem.Click += new System.EventHandler(this.buttonBigModeXY_Click);
            // 
            // 坐标自动调整ToolStripMenuItem
            // 
            this.坐标自动调整ToolStripMenuItem.Name = "坐标自动调整ToolStripMenuItem";
            this.坐标自动调整ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.坐标自动调整ToolStripMenuItem.Text = "坐标自动调整";
            this.坐标自动调整ToolStripMenuItem.Click += new System.EventHandler(this.buttonAutoModeXY_Click);
            // 
            // 默认坐标范围ToolStripMenuItem
            // 
            this.默认坐标范围ToolStripMenuItem.Name = "默认坐标范围ToolStripMenuItem";
            this.默认坐标范围ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.默认坐标范围ToolStripMenuItem.Text = "默认坐标范围";
            this.默认坐标范围ToolStripMenuItem.Click += new System.EventHandler(this.buttonReXY_Click);
            // 
            // 波形拖动toolStripMenuItem1
            // 
            this.波形拖动toolStripMenuItem1.Name = "波形拖动toolStripMenuItem1";
            this.波形拖动toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.波形拖动toolStripMenuItem1.Text = "波形拖动";
            this.波形拖动toolStripMenuItem1.Click += new System.EventHandler(this.buttonMoveModeXY_Click);
            // 
            // labelItemShuoMing
            // 
            this.labelItemShuoMing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelItemShuoMing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.labelItemShuoMing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelItemShuoMing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelItemShuoMing.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelItemShuoMing.ForeColor = System.Drawing.Color.White;
            this.labelItemShuoMing.Location = new System.Drawing.Point(342, 364);
            this.labelItemShuoMing.Name = "labelItemShuoMing";
            this.labelItemShuoMing.Size = new System.Drawing.Size(100, 32);
            this.labelItemShuoMing.TabIndex = 9;
            this.labelItemShuoMing.Text = "说明";
            this.labelItemShuoMing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelItemShuoMing.Visible = false;
            // 
            // pictureBoxBigXY
            // 
            this.pictureBoxBigXY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pictureBoxBigXY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBigXY.ErrorImage = null;
            this.pictureBoxBigXY.InitialImage = null;
            this.pictureBoxBigXY.Location = new System.Drawing.Point(222, 365);
            this.pictureBoxBigXY.Name = "pictureBoxBigXY";
            this.pictureBoxBigXY.Size = new System.Drawing.Size(114, 32);
            this.pictureBoxBigXY.TabIndex = 11;
            this.pictureBoxBigXY.TabStop = false;
            this.pictureBoxBigXY.Visible = false;
            // 
            // pictureBoxDrag
            // 
            this.pictureBoxDrag.BackColor = System.Drawing.Color.White;
            this.pictureBoxDrag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDrag.ErrorImage = null;
            this.pictureBoxDrag.InitialImage = null;
            this.pictureBoxDrag.Location = new System.Drawing.Point(195, 389);
            this.pictureBoxDrag.Name = "pictureBoxDrag";
            this.pictureBoxDrag.Size = new System.Drawing.Size(7, 7);
            this.pictureBoxDrag.TabIndex = 12;
            this.pictureBoxDrag.TabStop = false;
            this.pictureBoxDrag.Visible = false;
            // 
            // labelShowNum
            // 
            this.labelShowNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelShowNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelShowNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelShowNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelShowNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelShowNum.ForeColor = System.Drawing.Color.Blue;
            this.labelShowNum.Location = new System.Drawing.Point(50, 378);
            this.labelShowNum.Name = "labelShowNum";
            this.labelShowNum.Size = new System.Drawing.Size(139, 19);
            this.labelShowNum.TabIndex = 13;
            this.labelShowNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelShowNum.Visible = false;
            // 
            // ZGraph
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelShowNum);
            this.Controls.Add(this.pictureBoxDrag);
            this.Controls.Add(this.pictureBoxBigXY);
            this.Controls.Add(this.labelItemShuoMing);
            this.Controls.Add(this.panelControlItem);
            this.Controls.Add(this.pictureBoxGraph);
            this.Controls.Add(this.pictureBoxTop);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.pictureBoxBottom);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(390, 270);
            this.Name = "ZGraph";
            this.Size = new System.Drawing.Size(454, 404);
            this.Resize += new System.EventHandler(this.ZGraph_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTop)).EndInit();
            this.panelControlItem.ResumeLayout(false);
            this.panelItemsIN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.MenuRightClick.ResumeLayout(false);
            this.MenuRightClick.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBigXY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDrag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBottom;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.PictureBox pictureBoxTop;
        private System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.Button buttonLinesShowXY;
        private System.Windows.Forms.Panel panelControlItem;
        //private System.Windows.Forms.Button buttonControlItemUP;
       // private System.Windows.Forms.Button buttonItemsDown;
        private System.Windows.Forms.Panel panelItemsIN;
        private System.Windows.Forms.Button buttonBigModeXY;
        private System.Windows.Forms.Label labelItemShuoMing;
        private System.Windows.Forms.PictureBox pictureBoxBigXY;
        private System.Windows.Forms.ToolStripMenuItem 网格显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大选取框功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 坐标自动调整ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 默认坐标范围ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxX;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxY;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button buttonShowNumModeXY;
        private System.Windows.Forms.Button buttonMoveModeXY;
        private System.Windows.Forms.Button buttonCutMapModeXY;
        private System.Windows.Forms.ContextMenuStrip MenuRightClick;
        private System.Windows.Forms.ToolStripMenuItem 波形拖动toolStripMenuItem1;
        public System.Windows.Forms.Button buttonClearModeXY;
        private System.Windows.Forms.PictureBox pictureBoxDrag;
        private Label labelShowNum;
        private Button buttonReXY;
        private Button buttonAutoModeXY;
    }
}
