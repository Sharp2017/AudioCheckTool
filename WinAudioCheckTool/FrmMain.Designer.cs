namespace WinAudioCheckTool
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.mn_System = new DevExpress.XtraBars.BarSubItem();
            this.btn_AudioCheckSettins = new DevExpress.XtraBars.BarButtonItem();
            this.btn_SelectFiles = new DevExpress.XtraBars.BarButtonItem();
            this.btn_SelectFolders = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barLowLevel = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barIsNewCheck = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mn_System,
            this.btn_AudioCheckSettins,
            this.btn_SelectFiles,
            this.btn_SelectFolders,
            this.btnCancel,
            this.barLowLevel,
            this.barIsNewCheck});
            this.barManager.MainMenu = this.bar2;
            this.barManager.MaxItemId = 19;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mn_System),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_SelectFiles),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_SelectFolders),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancel),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barLowLevel, DevExpress.XtraBars.BarItemPaintStyle.Caption),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barIsNewCheck, DevExpress.XtraBars.BarItemPaintStyle.Caption)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.RotateWhenVertical = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // mn_System
            // 
            this.mn_System.Caption = "系统";
            this.mn_System.Id = 2;
            this.mn_System.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_AudioCheckSettins)});
            this.mn_System.Name = "mn_System";
            // 
            // btn_AudioCheckSettins
            // 
            this.btn_AudioCheckSettins.Caption = "音频质检参数";
            this.btn_AudioCheckSettins.Id = 4;
            this.btn_AudioCheckSettins.Name = "btn_AudioCheckSettins";
            this.btn_AudioCheckSettins.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_AudioCheckSettins_ItemClick);
            // 
            // btn_SelectFiles
            // 
            this.btn_SelectFiles.Caption = "选择文件质检 ";
            this.btn_SelectFiles.Id = 5;
            this.btn_SelectFiles.Name = "btn_SelectFiles";
            this.btn_SelectFiles.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SelectFiles_ItemClick);
            // 
            // btn_SelectFolders
            // 
            this.btn_SelectFolders.Caption = "选择目录质检";
            this.btn_SelectFolders.Id = 6;
            this.btn_SelectFolders.Name = "btn_SelectFolders";
            this.btn_SelectFolders.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SelectFolders_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "取消质检";
            this.btnCancel.Id = 10;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Cancel_ItemClick);
            // 
            // barLowLevel
            // 
            this.barLowLevel.Caption = "是否记录静音错误：";
            this.barLowLevel.Edit = this.repositoryItemCheckEdit1;
            this.barLowLevel.EditValue = false;
            this.barLowLevel.Id = 13;
            this.barLowLevel.Name = "barLowLevel";
            this.barLowLevel.EditValueChanged += new System.EventHandler(this.barLowLevel_EditValueChanged);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // barIsNewCheck
            // 
            this.barIsNewCheck.Caption = "是否采用最新标准:";
            this.barIsNewCheck.Edit = this.repositoryItemCheckEdit2;
            this.barIsNewCheck.EditValue = false;
            this.barIsNewCheck.Id = 18;
            this.barIsNewCheck.Name = "barIsNewCheck";
            this.barIsNewCheck.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barIsNewCheck.EditValueChanged += new System.EventHandler(this.barIsNewCheck_EditValueChanged);
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // bar1
            // 
            this.bar1.BarName = "Tool";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.RotateWhenVertical = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tool";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Black";
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Location = new System.Drawing.Point(0, 26);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(0);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(779, 428);
            this.txtInfo.TabIndex = 4;
            this.txtInfo.Text = "";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 478);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "音频质检工具";
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem mn_System;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem btn_AudioCheckSettins;
        private DevExpress.XtraBars.BarButtonItem btn_SelectFiles;
        private DevExpress.XtraBars.BarButtonItem btn_SelectFolders;
        private DevExpress.XtraBars.Bar bar1;
        private System.Windows.Forms.RichTextBox txtInfo;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarEditItem barLowLevel;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarEditItem barIsNewCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;

    }
}

