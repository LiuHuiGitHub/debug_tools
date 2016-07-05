namespace debug_tools
{
    partial class VariableControl
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxEnable = new System.Windows.Forms.CheckBox();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.labelLength = new System.Windows.Forms.Label();
            this.textBoxAddr = new System.Windows.Forms.TextBox();
            this.labelAddr = new System.Windows.Forms.Label();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.labelType = new System.Windows.Forms.Label();
            this.labelVariable = new System.Windows.Forms.Label();
            this.comboBoxVariable = new System.Windows.Forms.ComboBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.labelValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxEnable
            // 
            this.checkBoxEnable.AutoSize = true;
            this.checkBoxEnable.Location = new System.Drawing.Point(617, 6);
            this.checkBoxEnable.Name = "checkBoxEnable";
            this.checkBoxEnable.Size = new System.Drawing.Size(15, 14);
            this.checkBoxEnable.TabIndex = 32;
            this.checkBoxEnable.UseVisualStyleBackColor = true;
            // 
            // textBoxLength
            // 
            this.textBoxLength.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBoxLength.Location = new System.Drawing.Point(425, 2);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(42, 21);
            this.textBoxLength.TabIndex = 31;
            this.textBoxLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Location = new System.Drawing.Point(388, 6);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(35, 12);
            this.labelLength.TabIndex = 30;
            this.labelLength.Text = "长度:";
            // 
            // textBoxAddr
            // 
            this.textBoxAddr.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBoxAddr.Location = new System.Drawing.Point(310, 2);
            this.textBoxAddr.Name = "textBoxAddr";
            this.textBoxAddr.Size = new System.Drawing.Size(74, 21);
            this.textBoxAddr.TabIndex = 29;
            this.textBoxAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // labelAddr
            // 
            this.labelAddr.AutoSize = true;
            this.labelAddr.Location = new System.Drawing.Point(273, 6);
            this.labelAddr.Name = "labelAddr";
            this.labelAddr.Size = new System.Drawing.Size(35, 12);
            this.labelAddr.TabIndex = 28;
            this.labelAddr.Text = "地址:";
            // 
            // textBoxType
            // 
            this.textBoxType.Location = new System.Drawing.Point(227, 2);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.ReadOnly = true;
            this.textBoxType.Size = new System.Drawing.Size(42, 21);
            this.textBoxType.TabIndex = 27;
            this.textBoxType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(190, 6);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(35, 12);
            this.labelType.TabIndex = 26;
            this.labelType.Text = "类型:";
            // 
            // labelVariable
            // 
            this.labelVariable.AutoSize = true;
            this.labelVariable.Location = new System.Drawing.Point(3, 6);
            this.labelVariable.Name = "labelVariable";
            this.labelVariable.Size = new System.Drawing.Size(35, 12);
            this.labelVariable.TabIndex = 25;
            this.labelVariable.Text = "变量:";
            // 
            // comboBoxVariable
            // 
            this.comboBoxVariable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxVariable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxVariable.FormattingEnabled = true;
            this.comboBoxVariable.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.comboBoxVariable.Location = new System.Drawing.Point(40, 3);
            this.comboBoxVariable.MaxDropDownItems = 10;
            this.comboBoxVariable.Name = "comboBoxVariable";
            this.comboBoxVariable.Size = new System.Drawing.Size(146, 20);
            this.comboBoxVariable.TabIndex = 24;
            this.comboBoxVariable.SelectedIndexChanged += new System.EventHandler(this.comboBoxVariable_SelectedIndexChanged);
            // 
            // textBoxValue
            // 
            this.textBoxValue.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBoxValue.Location = new System.Drawing.Point(513, 2);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(96, 21);
            this.textBoxValue.TabIndex = 35;
            this.textBoxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(476, 6);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(35, 12);
            this.labelValue.TabIndex = 34;
            this.labelValue.Text = "数值:";
            // 
            // VariableControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.checkBoxEnable);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.labelLength);
            this.Controls.Add(this.textBoxAddr);
            this.Controls.Add(this.labelAddr);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelVariable);
            this.Controls.Add(this.comboBoxVariable);
            this.Name = "VariableControl";
            this.Size = new System.Drawing.Size(637, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVariable;
        private System.Windows.Forms.ComboBox comboBoxVariable;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.Label labelAddr;
        private System.Windows.Forms.TextBox textBoxAddr;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.TextBox textBoxLength;
        private System.Windows.Forms.CheckBox checkBoxEnable;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TextBox textBoxValue;
    }
}
