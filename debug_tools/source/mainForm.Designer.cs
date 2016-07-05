namespace debug_tools
{
    partial class mainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.buttonMapFile = new System.Windows.Forms.Button();
            this.labelBaud = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelCom = new System.Windows.Forms.Label();
            this.comboBoxCom = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Location = new System.Drawing.Point(209, 12);
            this.comboBoxBaud.Name = "comboBoxBaud";
            this.comboBoxBaud.Size = new System.Drawing.Size(69, 20);
            this.comboBoxBaud.TabIndex = 29;
            // 
            // buttonMapFile
            // 
            this.buttonMapFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMapFile.Location = new System.Drawing.Point(195, 56);
            this.buttonMapFile.Name = "buttonMapFile";
            this.buttonMapFile.Size = new System.Drawing.Size(87, 79);
            this.buttonMapFile.TabIndex = 30;
            this.buttonMapFile.Text = "MapFile";
            this.buttonMapFile.UseVisualStyleBackColor = true;
            this.buttonMapFile.Click += new System.EventHandler(this.OpenMapFile_Click);
            // 
            // labelBaud
            // 
            this.labelBaud.AutoSize = true;
            this.labelBaud.Location = new System.Drawing.Point(162, 16);
            this.labelBaud.Name = "labelBaud";
            this.labelBaud.Size = new System.Drawing.Size(47, 12);
            this.labelBaud.TabIndex = 31;
            this.labelBaud.Text = "波特率:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDate.Location = new System.Drawing.Point(32, 58);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(130, 24);
            this.labelDate.TabIndex = 33;
            this.labelDate.Text = "2016/06/10";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTime.Location = new System.Drawing.Point(16, 100);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(159, 35);
            this.labelTime.TabIndex = 34;
            this.labelTime.Text = "16:35:10";
            // 
            // labelCom
            // 
            this.labelCom.AutoSize = true;
            this.labelCom.Location = new System.Drawing.Point(20, 17);
            this.labelCom.Name = "labelCom";
            this.labelCom.Size = new System.Drawing.Size(47, 12);
            this.labelCom.TabIndex = 36;
            this.labelCom.Text = "串口号:";
            // 
            // comboBoxCom
            // 
            this.comboBoxCom.FormattingEnabled = true;
            this.comboBoxCom.Location = new System.Drawing.Point(67, 13);
            this.comboBoxCom.Name = "comboBoxCom";
            this.comboBoxCom.Size = new System.Drawing.Size(78, 20);
            this.comboBoxCom.TabIndex = 35;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 171);
            this.Controls.Add(this.labelCom);
            this.Controls.Add(this.comboBoxCom);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelBaud);
            this.Controls.Add(this.buttonMapFile);
            this.Controls.Add(this.comboBoxBaud);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(325, 210);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(325, 210);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "debug_tools";
            this.toolTip.SetToolTip(this, "stm8s_bootload by hui.liu");
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox comboBoxBaud;
        private System.Windows.Forms.Button buttonMapFile;
        private System.Windows.Forms.Label labelBaud;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelCom;
        private System.Windows.Forms.ComboBox comboBoxCom;
    }
}

