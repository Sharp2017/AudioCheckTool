namespace WinAudioCheckTool
{
    partial class Form_AudioCheckSetting
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
            this.btn_LoadDefault = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.se_LRDuration = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.chk_LR = new DevExpress.XtraEditors.CheckEdit();
            this.se_LR = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk_OverLoad = new DevExpress.XtraEditors.CheckEdit();
            this.se_Overloaddbfs = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_ReversDuration = new DevExpress.XtraEditors.SpinEdit();
            this.txt_Reverse = new DevExpress.XtraEditors.SpinEdit();
            this.chk_Reverse = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_Mute = new DevExpress.XtraEditors.CheckEdit();
            this.se_MuteDuration = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.se_Mutedbfs = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.se_LRDuration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_LR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_LR.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_OverLoad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Overloaddbfs.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ReversDuration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Reverse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Reverse.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Mute.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_MuteDuration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Mutedbfs.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_LoadDefault
            // 
            this.btn_LoadDefault.Location = new System.Drawing.Point(8, 418);
            this.btn_LoadDefault.Name = "btn_LoadDefault";
            this.btn_LoadDefault.Size = new System.Drawing.Size(75, 23);
            this.btn_LoadDefault.TabIndex = 18;
            this.btn_LoadDefault.Text = "默认值";
            this.btn_LoadDefault.Visible = false;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Location = new System.Drawing.Point(9, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(260, 14);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "以下检测项用于审核时辅助技审工具参数设置";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.se_LRDuration);
            this.groupBox4.Controls.Add(this.labelControl7);
            this.groupBox4.Controls.Add(this.chk_LR);
            this.groupBox4.Controls.Add(this.se_LR);
            this.groupBox4.Controls.Add(this.labelControl5);
            this.groupBox4.Location = new System.Drawing.Point(9, 274);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(461, 104);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "左右声道检测";
            // 
            // se_LRDuration
            // 
            this.se_LRDuration.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.se_LRDuration.Location = new System.Drawing.Point(160, 65);
            this.se_LRDuration.Name = "se_LRDuration";
            this.se_LRDuration.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.se_LRDuration.Properties.IsFloatValue = false;
            this.se_LRDuration.Properties.Mask.EditMask = "N00";
            this.se_LRDuration.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.se_LRDuration.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.se_LRDuration.Size = new System.Drawing.Size(115, 21);
            this.se_LRDuration.TabIndex = 10;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(11, 69);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 14);
            this.labelControl7.TabIndex = 9;
            this.labelControl7.Text = "长度（秒）：";
            // 
            // chk_LR
            // 
            this.chk_LR.EditValue = true;
            this.chk_LR.Location = new System.Drawing.Point(316, 66);
            this.chk_LR.Name = "chk_LR";
            this.chk_LR.Properties.Caption = "强制左右电平差检测？";
            this.chk_LR.Size = new System.Drawing.Size(139, 19);
            this.chk_LR.TabIndex = 8;
            // 
            // se_LR
            // 
            this.se_LR.EditValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.se_LR.Location = new System.Drawing.Point(160, 21);
            this.se_LR.Name = "se_LR";
            this.se_LR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.se_LR.Properties.IsFloatValue = false;
            this.se_LR.Properties.Mask.EditMask = "N00";
            this.se_LR.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.se_LR.Size = new System.Drawing.Size(115, 21);
            this.se_LR.TabIndex = 2;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(11, 26);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(147, 14);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "左右声道电平差（dBFS）：";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(395, 418);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 16;
            this.btn_Close.Text = "关闭";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(314, 418);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 14;
            this.btn_OK.Text = "确定";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chk_OverLoad);
            this.groupBox3.Controls.Add(this.se_Overloaddbfs);
            this.groupBox3.Controls.Add(this.labelControl6);
            this.groupBox3.Location = new System.Drawing.Point(9, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(461, 69);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "过载检测设置";
            // 
            // chk_OverLoad
            // 
            this.chk_OverLoad.EditValue = true;
            this.chk_OverLoad.Location = new System.Drawing.Point(325, 25);
            this.chk_OverLoad.Name = "chk_OverLoad";
            this.chk_OverLoad.Properties.Caption = "强制过载检测？";
            this.chk_OverLoad.Size = new System.Drawing.Size(117, 19);
            this.chk_OverLoad.TabIndex = 8;
            // 
            // se_Overloaddbfs
            // 
            this.se_Overloaddbfs.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.se_Overloaddbfs.Location = new System.Drawing.Point(109, 23);
            this.se_Overloaddbfs.Name = "se_Overloaddbfs";
            this.se_Overloaddbfs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.se_Overloaddbfs.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.se_Overloaddbfs.Properties.IsFloatValue = false;
            this.se_Overloaddbfs.Properties.Mask.EditMask = "N00";
            this.se_Overloaddbfs.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.se_Overloaddbfs.Properties.MinValue = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.se_Overloaddbfs.Size = new System.Drawing.Size(115, 21);
            this.se_Overloaddbfs.TabIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(11, 26);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(99, 14);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "过载值（dBFS）：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_ReversDuration);
            this.groupBox2.Controls.Add(this.txt_Reverse);
            this.groupBox2.Controls.Add(this.chk_Reverse);
            this.groupBox2.Controls.Add(this.labelControl3);
            this.groupBox2.Controls.Add(this.labelControl4);
            this.groupBox2.Location = new System.Drawing.Point(9, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 81);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "反相检测设置";
            // 
            // txt_ReversDuration
            // 
            this.txt_ReversDuration.EditValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txt_ReversDuration.Location = new System.Drawing.Point(359, 23);
            this.txt_ReversDuration.Name = "txt_ReversDuration";
            this.txt_ReversDuration.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txt_ReversDuration.Properties.IsFloatValue = false;
            this.txt_ReversDuration.Properties.Mask.EditMask = "N00";
            this.txt_ReversDuration.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.txt_ReversDuration.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_ReversDuration.Size = new System.Drawing.Size(83, 21);
            this.txt_ReversDuration.TabIndex = 11;
            // 
            // txt_Reverse
            // 
            this.txt_Reverse.EditValue = new decimal(new int[] {
            7,
            0,
            0,
            -2147418112});
            this.txt_Reverse.Location = new System.Drawing.Point(109, 23);
            this.txt_Reverse.Name = "txt_Reverse";
            this.txt_Reverse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txt_Reverse.Properties.DisplayFormat.FormatString = "0.00";
            this.txt_Reverse.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_Reverse.Properties.EditFormat.FormatString = "0.00";
            this.txt_Reverse.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_Reverse.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txt_Reverse.Properties.Mask.EditMask = "0.00";
            this.txt_Reverse.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_Reverse.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txt_Reverse.Size = new System.Drawing.Size(115, 21);
            this.txt_Reverse.TabIndex = 8;
            // 
            // chk_Reverse
            // 
            this.chk_Reverse.EditValue = true;
            this.chk_Reverse.Location = new System.Drawing.Point(325, 50);
            this.chk_Reverse.Name = "chk_Reverse";
            this.chk_Reverse.Properties.Caption = "强制反相检测？";
            this.chk_Reverse.Size = new System.Drawing.Size(117, 19);
            this.chk_Reverse.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(233, 26);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(120, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "检测时间长度（秒）：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 26);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 14);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "相位检测阀值：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_Mute);
            this.groupBox1.Controls.Add(this.se_MuteDuration);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.se_Mutedbfs);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Location = new System.Drawing.Point(9, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 77);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "静音检测设置";
            // 
            // chk_Mute
            // 
            this.chk_Mute.EditValue = true;
            this.chk_Mute.Location = new System.Drawing.Point(325, 50);
            this.chk_Mute.Name = "chk_Mute";
            this.chk_Mute.Properties.Caption = "强制静音检测？";
            this.chk_Mute.Size = new System.Drawing.Size(117, 19);
            this.chk_Mute.TabIndex = 6;
            // 
            // se_MuteDuration
            // 
            this.se_MuteDuration.EditValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.se_MuteDuration.Location = new System.Drawing.Point(327, 23);
            this.se_MuteDuration.Name = "se_MuteDuration";
            this.se_MuteDuration.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.se_MuteDuration.Properties.IsFloatValue = false;
            this.se_MuteDuration.Properties.Mask.EditMask = "N00";
            this.se_MuteDuration.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.se_MuteDuration.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.se_MuteDuration.Size = new System.Drawing.Size(115, 21);
            this.se_MuteDuration.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(232, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(96, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "静音长度（秒）：";
            // 
            // se_Mutedbfs
            // 
            this.se_Mutedbfs.EditValue = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.se_Mutedbfs.Location = new System.Drawing.Point(109, 23);
            this.se_Mutedbfs.Name = "se_Mutedbfs";
            this.se_Mutedbfs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.se_Mutedbfs.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.se_Mutedbfs.Properties.IsFloatValue = false;
            this.se_Mutedbfs.Properties.Mask.EditMask = "N00";
            this.se_Mutedbfs.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.se_Mutedbfs.Properties.MinValue = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.se_Mutedbfs.Size = new System.Drawing.Size(115, 21);
            this.se_Mutedbfs.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(99, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "静音值（dBFS）：";
            // 
            // Form_AudioCheckSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 445);
            this.Controls.Add(this.btn_LoadDefault);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_AudioCheckSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "音频质检参数设置";
            this.Load += new System.EventHandler(this.Form_AudioCheckSetting_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.se_LRDuration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_LR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_LR.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_OverLoad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Overloaddbfs.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ReversDuration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Reverse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Reverse.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Mute.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_MuteDuration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Mutedbfs.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_LoadDefault;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraEditors.SpinEdit se_LRDuration;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.CheckEdit chk_LR;
        private DevExpress.XtraEditors.SpinEdit se_LR;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton btn_OK;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.CheckEdit chk_OverLoad;
        private DevExpress.XtraEditors.SpinEdit se_Overloaddbfs;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SpinEdit txt_ReversDuration;
        private DevExpress.XtraEditors.SpinEdit txt_Reverse;
        private DevExpress.XtraEditors.CheckEdit chk_Reverse;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.CheckEdit chk_Mute;
        private DevExpress.XtraEditors.SpinEdit se_MuteDuration;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit se_Mutedbfs;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}