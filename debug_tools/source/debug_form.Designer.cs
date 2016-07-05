namespace debug_tools
{
    partial class debug_from
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(debug_from));
            this.buttonLook = new System.Windows.Forms.Button();
            this.textBoxShow = new System.Windows.Forms.TextBox();
            this.contextMenuStripTextBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemClip = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCycle = new System.Windows.Forms.TextBox();
            this.zGraph = new Pengpai.UI.ZGraph();
            this.variableControl3 = new debug_tools.VariableControl();
            this.contextMenuStrip0 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemWrite = new System.Windows.Forms.ToolStripMenuItem();
            this.variableControl2 = new debug_tools.VariableControl();
            this.variableControl1 = new debug_tools.VariableControl();
            this.variableControl0 = new debug_tools.VariableControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTextBox.SuspendLayout();
            this.contextMenuStrip0.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLook
            // 
            this.buttonLook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLook.Location = new System.Drawing.Point(656, 36);
            this.buttonLook.Name = "buttonLook";
            this.buttonLook.Size = new System.Drawing.Size(84, 66);
            this.buttonLook.TabIndex = 5;
            this.buttonLook.Text = "查看";
            this.buttonLook.UseVisualStyleBackColor = true;
            this.buttonLook.Click += new System.EventHandler(this.buttonLook_Click);
            // 
            // textBoxShow
            // 
            this.textBoxShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxShow.ContextMenuStrip = this.contextMenuStripTextBox;
            this.textBoxShow.Location = new System.Drawing.Point(9, 509);
            this.textBoxShow.Multiline = true;
            this.textBoxShow.Name = "textBoxShow";
            this.textBoxShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxShow.Size = new System.Drawing.Size(737, 144);
            this.textBoxShow.TabIndex = 7;
            // 
            // contextMenuStripTextBox
            // 
            this.contextMenuStripTextBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemClip,
            this.ToolStripMenuItemCopy,
            this.ToolStripMenuItemClear});
            this.contextMenuStripTextBox.Name = "contextMenuStripTextBox";
            this.contextMenuStripTextBox.Size = new System.Drawing.Size(101, 70);
            // 
            // toolStripMenuItemClip
            // 
            this.toolStripMenuItemClip.Name = "toolStripMenuItemClip";
            this.toolStripMenuItemClip.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItemClip.Text = "剪切";
            this.toolStripMenuItemClip.Click += new System.EventHandler(this.toolStripMenuItemClip_Click);
            // 
            // ToolStripMenuItemCopy
            // 
            this.ToolStripMenuItemCopy.Name = "ToolStripMenuItemCopy";
            this.ToolStripMenuItemCopy.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItemCopy.Text = "复制";
            this.ToolStripMenuItemCopy.Click += new System.EventHandler(this.ToolStripMenuItemCopy_Click);
            // 
            // ToolStripMenuItemClear
            // 
            this.ToolStripMenuItemClear.Name = "ToolStripMenuItemClear";
            this.ToolStripMenuItemClear.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItemClear.Text = "清空";
            this.ToolStripMenuItemClear.Click += new System.EventHandler(this.ToolStripMenuItemClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(659, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "周期:";
            // 
            // textBoxCycle
            // 
            this.textBoxCycle.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBoxCycle.Location = new System.Drawing.Point(694, 9);
            this.textBoxCycle.Name = "textBoxCycle";
            this.textBoxCycle.Size = new System.Drawing.Size(37, 21);
            this.textBoxCycle.TabIndex = 4;
            this.textBoxCycle.Text = "0";
            this.textBoxCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // zGraph
            // 
            this.zGraph.AllowDrop = true;
            this.zGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zGraph.BackColor = System.Drawing.Color.White;
            this.zGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zGraph.Location = new System.Drawing.Point(9, 117);
            this.zGraph.m_backColorH = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.zGraph.m_backColorL = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph.m_BigXYBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph.m_ControlButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph.m_ControlButtonForeColorH = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.zGraph.m_ControlButtonForeColorL = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.zGraph.m_ControlItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph.m_coordinateLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph.m_coordinateStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph.m_coordinateStringTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph.m_DirectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.zGraph.m_DirectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph.m_fXBeginSYS = 0F;
            this.zGraph.m_fXEndSYS = 60F;
            this.zGraph.m_fYBeginSYS = 0F;
            this.zGraph.m_fYEndSYS = 1F;
            this.zGraph.m_GraphBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph.m_iLineShowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.zGraph.m_iLineShowColorAlpha = 100;
            this.zGraph.m_ShowNumBackColor = System.Drawing.Color.White;
            this.zGraph.m_ShowNumForeClor = System.Drawing.Color.Yellow;
            this.zGraph.m_SySnameX = "X轴坐标";
            this.zGraph.m_SySnameY = "Y轴坐标";
            this.zGraph.m_SyStitle = "波形显示";
            this.zGraph.m_titleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.zGraph.m_titleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.zGraph.m_titlePosition = 0.4F;
            this.zGraph.m_titleSize = 14;
            this.zGraph.Margin = new System.Windows.Forms.Padding(0);
            this.zGraph.MinimumSize = new System.Drawing.Size(390, 270);
            this.zGraph.Name = "zGraph";
            this.zGraph.Size = new System.Drawing.Size(737, 389);
            this.zGraph.TabIndex = 14;
            // 
            // variableControl3
            // 
            this.variableControl3.ContextMenuStrip = this.contextMenuStrip3;
            this.variableControl3.Location = new System.Drawing.Point(12, 85);
            this.variableControl3.Name = "variableControl3";
            this.variableControl3.Size = new System.Drawing.Size(636, 26);
            this.variableControl3.TabIndex = 3;
            this.variableControl3.VariableValue = new byte[0];
            // 
            // contextMenuStrip0
            // 
            this.contextMenuStrip0.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemWrite});
            this.contextMenuStrip0.Name = "contextMenuStripWrite";
            this.contextMenuStrip0.Size = new System.Drawing.Size(101, 26);
            // 
            // ToolStripMenuItemWrite
            // 
            this.ToolStripMenuItemWrite.Name = "ToolStripMenuItemWrite";
            this.ToolStripMenuItemWrite.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItemWrite.Text = "写入";
            this.ToolStripMenuItemWrite.Click += new System.EventHandler(this.ToolStripMenuItemWrite0_Click);
            // 
            // variableControl2
            // 
            this.variableControl2.ContextMenuStrip = this.contextMenuStrip2;
            this.variableControl2.Location = new System.Drawing.Point(12, 58);
            this.variableControl2.Name = "variableControl2";
            this.variableControl2.Size = new System.Drawing.Size(636, 26);
            this.variableControl2.TabIndex = 2;
            this.variableControl2.VariableValue = new byte[0];
            // 
            // variableControl1
            // 
            this.variableControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.variableControl1.Location = new System.Drawing.Point(12, 31);
            this.variableControl1.Name = "variableControl1";
            this.variableControl1.Size = new System.Drawing.Size(636, 26);
            this.variableControl1.TabIndex = 1;
            this.variableControl1.VariableValue = new byte[0];
            // 
            // variableControl0
            // 
            this.variableControl0.ContextMenuStrip = this.contextMenuStrip0;
            this.variableControl0.Location = new System.Drawing.Point(12, 4);
            this.variableControl0.Name = "variableControl0";
            this.variableControl0.Size = new System.Drawing.Size(636, 26);
            this.variableControl0.TabIndex = 0;
            this.variableControl0.VariableValue = new byte[0];
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStripWrite";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem1.Text = "写入";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItemWrite1_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStrip2.Name = "contextMenuStripWrite";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem2.Text = "写入";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItemWrite2_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.contextMenuStrip3.Name = "contextMenuStripWrite";
            this.contextMenuStrip3.Size = new System.Drawing.Size(153, 48);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "写入";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItemWrite3_Click);
            // 
            // debug_from
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 661);
            this.Controls.Add(this.variableControl3);
            this.Controls.Add(this.variableControl2);
            this.Controls.Add(this.variableControl1);
            this.Controls.Add(this.variableControl0);
            this.Controls.Add(this.zGraph);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCycle);
            this.Controls.Add(this.textBoxShow);
            this.Controls.Add(this.buttonLook);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 700);
            this.Name = "debug_from";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.debug_form_FormClosing);
            this.contextMenuStripTextBox.ResumeLayout(false);
            this.contextMenuStrip0.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonLook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCycle;
        public System.Windows.Forms.TextBox textBoxShow;
        private Pengpai.UI.ZGraph zGraph;
        private VariableControl variableControl0;
        private VariableControl variableControl1;
        private VariableControl variableControl2;
        private VariableControl variableControl3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClear;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemWrite;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip0;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}