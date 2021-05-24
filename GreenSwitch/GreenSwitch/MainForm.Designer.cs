namespace GreenSwitch
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnProcessPO = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnModifyPO = new System.Windows.Forms.Button();
            this.picEmployee = new System.Windows.Forms.PictureBox();
            this.picDepartment = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new MdiTabControl.TabControl();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tspNew = new System.Windows.Forms.ToolStripButton();
            this.tspOpen = new System.Windows.Forms.ToolStripButton();
            this.tspSave = new System.Windows.Forms.ToolStripButton();
            this.tspPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tspCut = new System.Windows.Forms.ToolStripButton();
            this.tspCopy = new System.Windows.Forms.ToolStripButton();
            this.tspPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tspAbout = new System.Windows.Forms.ToolStripButton();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuHR = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegularSupervisor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreatePurchaseOrderRS = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyPurchaseOrderRS = new System.Windows.Forms.ToolStripMenuItem();
            this.processPurchaseOrderRS = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegularEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeptHeadAddResource = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverdueChargeReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreatePO = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDepartment)).BeginInit();
            this.ToolStrip1.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 51);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnCreatePO);
            this.splitContainer1.Panel1.Controls.Add(this.btnProcessPO);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnModifyPO);
            this.splitContainer1.Panel1.Controls.Add(this.picEmployee);
            this.splitContainer1.Panel1.Controls.Add(this.picDepartment);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1277, 792);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 11;
            // 
            // btnProcessPO
            // 
            this.btnProcessPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessPO.ForeColor = System.Drawing.Color.DarkRed;
            this.btnProcessPO.Location = new System.Drawing.Point(10, 321);
            this.btnProcessPO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnProcessPO.Name = "btnProcessPO";
            this.btnProcessPO.Size = new System.Drawing.Size(251, 49);
            this.btnProcessPO.TabIndex = 12;
            this.btnProcessPO.Text = "Process PO";
            this.btnProcessPO.UseVisualStyleBackColor = true;
          
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::GreenSwitch.Properties.Resources.Profile_Menu;
            this.pictureBox1.Location = new System.Drawing.Point(9, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(251, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnModifyPO
            // 
            this.btnModifyPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyPO.ForeColor = System.Drawing.Color.DarkRed;
            this.btnModifyPO.Location = new System.Drawing.Point(10, 266);
            this.btnModifyPO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnModifyPO.Name = "btnModifyPO";
            this.btnModifyPO.Size = new System.Drawing.Size(251, 49);
            this.btnModifyPO.TabIndex = 10;
            this.btnModifyPO.Text = "Modify PO";
            this.btnModifyPO.UseVisualStyleBackColor = true;
  
            // 
            // picEmployee
            // 
            this.picEmployee.Image = global::GreenSwitch.Properties.Resources.Employee_menu1;
            this.picEmployee.Location = new System.Drawing.Point(9, 138);
            this.picEmployee.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picEmployee.Name = "picEmployee";
            this.picEmployee.Size = new System.Drawing.Size(250, 59);
            this.picEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEmployee.TabIndex = 8;
            this.picEmployee.TabStop = false;
            this.picEmployee.Click += new System.EventHandler(this.picEmployee_Click);
            // 
            // picDepartment
            // 
            this.picDepartment.Image = global::GreenSwitch.Properties.Resources.Department_Menu;
            this.picDepartment.Location = new System.Drawing.Point(9, 76);
            this.picDepartment.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picDepartment.Name = "picDepartment";
            this.picDepartment.Size = new System.Drawing.Size(250, 56);
            this.picDepartment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDepartment.TabIndex = 7;
            this.picDepartment.TabStop = false;
            this.picDepartment.Click += new System.EventHandler(this.picDepartment_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.MenuRenderer = null;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(982, 764);
            this.tabControl1.TabCloseButtonImage = null;
            this.tabControl1.TabCloseButtonImageDisabled = null;
            this.tabControl1.TabCloseButtonImageHot = null;
            this.tabControl1.TabIndex = 0;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspNew,
            this.tspOpen,
            this.tspSave,
            this.tspPrint,
            this.toolStripSeparator7,
            this.tspCut,
            this.tspCopy,
            this.tspPaste,
            this.toolStripSeparator8,
            this.tspAbout});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 24);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(1277, 27);
            this.ToolStrip1.TabIndex = 10;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // tspNew
            // 
            this.tspNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspNew.Image = ((System.Drawing.Image)(resources.GetObject("tspNew.Image")));
            this.tspNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspNew.Name = "tspNew";
            this.tspNew.Size = new System.Drawing.Size(24, 24);
            this.tspNew.Text = "&New";
            // 
            // tspOpen
            // 
            this.tspOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspOpen.Image = ((System.Drawing.Image)(resources.GetObject("tspOpen.Image")));
            this.tspOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspOpen.Name = "tspOpen";
            this.tspOpen.Size = new System.Drawing.Size(24, 24);
            this.tspOpen.Text = "&Open";
            // 
            // tspSave
            // 
            this.tspSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspSave.Image = ((System.Drawing.Image)(resources.GetObject("tspSave.Image")));
            this.tspSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspSave.Name = "tspSave";
            this.tspSave.Size = new System.Drawing.Size(24, 24);
            this.tspSave.Text = "&Save";
            // 
            // tspPrint
            // 
            this.tspPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspPrint.Image = ((System.Drawing.Image)(resources.GetObject("tspPrint.Image")));
            this.tspPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspPrint.Name = "tspPrint";
            this.tspPrint.Size = new System.Drawing.Size(24, 24);
            this.tspPrint.Text = "&Print";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // tspCut
            // 
            this.tspCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspCut.Image = ((System.Drawing.Image)(resources.GetObject("tspCut.Image")));
            this.tspCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspCut.Name = "tspCut";
            this.tspCut.Size = new System.Drawing.Size(24, 24);
            this.tspCut.Text = "C&ut";
            // 
            // tspCopy
            // 
            this.tspCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspCopy.Image = ((System.Drawing.Image)(resources.GetObject("tspCopy.Image")));
            this.tspCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspCopy.Name = "tspCopy";
            this.tspCopy.Size = new System.Drawing.Size(24, 24);
            this.tspCopy.Text = "&Copy";
            // 
            // tspPaste
            // 
            this.tspPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspPaste.Image = ((System.Drawing.Image)(resources.GetObject("tspPaste.Image")));
            this.tspPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspPaste.Name = "tspPaste";
            this.tspPaste.Size = new System.Drawing.Size(24, 24);
            this.tspPaste.Text = "&Paste";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 27);
            // 
            // tspAbout
            // 
            this.tspAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspAbout.Image = ((System.Drawing.Image)(resources.GetObject("tspAbout.Image")));
            this.tspAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspAbout.Name = "tspAbout";
            this.tspAbout.Size = new System.Drawing.Size(24, 24);
            this.tspAbout.Text = "He&lp";
            this.tspAbout.Click += new System.EventHandler(this.TspAbout_Click);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mainMenuHR,
            this.mnuRegularSupervisor,
            this.mnuRegularEmployee,
            this.mnuReport,
            this.mnuHelp});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuStrip1.Size = new System.Drawing.Size(1277, 24);
            this.MenuStrip1.TabIndex = 9;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.toolStripSeparator,
            this.mnuFileSave,
            this.mnuFileSaveAs,
            this.toolStripSeparator1,
            this.mnuFilePrint,
            this.toolStripSeparator2,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileNew.Image")));
            this.mnuFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuFileNew.Size = new System.Drawing.Size(146, 22);
            this.mnuFileNew.Text = "&New";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileOpen.Image")));
            this.mnuFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(146, 22);
            this.mnuFileOpen.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileSave.Image")));
            this.mnuFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(146, 22);
            this.mnuFileSave.Text = "&Save";
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.Size = new System.Drawing.Size(146, 22);
            this.mnuFileSaveAs.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // mnuFilePrint
            // 
            this.mnuFilePrint.Image = ((System.Drawing.Image)(resources.GetObject("mnuFilePrint.Image")));
            this.mnuFilePrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFilePrint.Name = "mnuFilePrint";
            this.mnuFilePrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuFilePrint.Size = new System.Drawing.Size(146, 22);
            this.mnuFilePrint.Text = "&Print";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(146, 22);
            this.mnuFileExit.Text = "E&xit";
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditUndo,
            this.mnuEditRedo,
            this.toolStripSeparator3,
            this.mnuEditCut,
            this.mnuEditCopy,
            this.mnuEditPaste,
            this.toolStripSeparator4,
            this.mnuEditSelectAll});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuEditUndo
            // 
            this.mnuEditUndo.Name = "mnuEditUndo";
            this.mnuEditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuEditUndo.Size = new System.Drawing.Size(144, 22);
            this.mnuEditUndo.Text = "&Undo";
            // 
            // mnuEditRedo
            // 
            this.mnuEditRedo.Name = "mnuEditRedo";
            this.mnuEditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.mnuEditRedo.Size = new System.Drawing.Size(144, 22);
            this.mnuEditRedo.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuEditCut
            // 
            this.mnuEditCut.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditCut.Image")));
            this.mnuEditCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuEditCut.Name = "mnuEditCut";
            this.mnuEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuEditCut.Size = new System.Drawing.Size(144, 22);
            this.mnuEditCut.Text = "Cu&t";
            // 
            // mnuEditCopy
            // 
            this.mnuEditCopy.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditCopy.Image")));
            this.mnuEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuEditCopy.Name = "mnuEditCopy";
            this.mnuEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuEditCopy.Size = new System.Drawing.Size(144, 22);
            this.mnuEditCopy.Text = "&Copy";
            // 
            // mnuEditPaste
            // 
            this.mnuEditPaste.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditPaste.Image")));
            this.mnuEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuEditPaste.Name = "mnuEditPaste";
            this.mnuEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuEditPaste.Size = new System.Drawing.Size(144, 22);
            this.mnuEditPaste.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuEditSelectAll
            // 
            this.mnuEditSelectAll.Name = "mnuEditSelectAll";
            this.mnuEditSelectAll.Size = new System.Drawing.Size(144, 22);
            this.mnuEditSelectAll.Text = "Select &All";
            // 
            // mainMenuHR
            // 
            this.mainMenuHR.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDepartment,
            this.menuEmployee});
            this.mainMenuHR.Name = "mainMenuHR";
            this.mainMenuHR.Size = new System.Drawing.Size(35, 20);
            this.mainMenuHR.Text = "&HR";
            // 
            // menuDepartment
            // 
            this.menuDepartment.Name = "menuDepartment";
            this.menuDepartment.Size = new System.Drawing.Size(137, 22);
            this.menuDepartment.Text = "&Department";
            this.menuDepartment.Click += new System.EventHandler(this.menuDepartment_Click);
            // 
            // menuEmployee
            // 
            this.menuEmployee.Name = "menuEmployee";
            this.menuEmployee.Size = new System.Drawing.Size(137, 22);
            this.menuEmployee.Text = "&Employee";
            this.menuEmployee.Click += new System.EventHandler(this.menuEmployee_Click);
            // 
            // mnuRegularSupervisor
            // 
            this.mnuRegularSupervisor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreatePurchaseOrderRS,
            this.ModifyPurchaseOrderRS,
            this.processPurchaseOrderRS});
            this.mnuRegularSupervisor.Name = "mnuRegularSupervisor";
            this.mnuRegularSupervisor.Size = new System.Drawing.Size(117, 20);
            this.mnuRegularSupervisor.Text = "&Regular Supervisor";
            // 
            // mnuCreatePurchaseOrderRS
            // 
            this.mnuCreatePurchaseOrderRS.Name = "mnuCreatePurchaseOrderRS";
            this.mnuCreatePurchaseOrderRS.Size = new System.Drawing.Size(258, 22);
            this.mnuCreatePurchaseOrderRS.Text = "&Create and Process Purchase Order";

            // 
            // ModifyPurchaseOrderRS
            // 
            this.ModifyPurchaseOrderRS.Name = "ModifyPurchaseOrderRS";
            this.ModifyPurchaseOrderRS.Size = new System.Drawing.Size(258, 22);
            this.ModifyPurchaseOrderRS.Text = "&Modify Purchase Order";

            // 
            // processPurchaseOrderRS
            // 
            this.processPurchaseOrderRS.Name = "processPurchaseOrderRS";
            this.processPurchaseOrderRS.Size = new System.Drawing.Size(258, 22);
            this.processPurchaseOrderRS.Text = "&Process Purchase Order";
        
            // 
            // mnuRegularEmployee
            // 
            this.mnuRegularEmployee.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeptHeadAddResource});
            this.mnuRegularEmployee.Name = "mnuRegularEmployee";
            this.mnuRegularEmployee.Size = new System.Drawing.Size(114, 20);
            this.mnuRegularEmployee.Text = "&Regular Employee";
            // 
            // mnuDeptHeadAddResource
            // 
            this.mnuDeptHeadAddResource.Name = "mnuDeptHeadAddResource";
            this.mnuDeptHeadAddResource.Size = new System.Drawing.Size(192, 22);
            this.mnuDeptHeadAddResource.Text = "&Create Purchase Order";

            // 
            // mnuReport
            // 
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOverdueChargeReport});
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(54, 20);
            this.mnuReport.Text = "&Report";
            // 
            // mnuOverdueChargeReport
            // 
            this.mnuOverdueChargeReport.Name = "mnuOverdueChargeReport";
            this.mnuOverdueChargeReport.Size = new System.Drawing.Size(198, 22);
            this.mnuOverdueChargeReport.Text = "&Overdue Charge Report";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.mnuHelpAbout,
            this.logoutToolStrip});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(113, 6);
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(116, 22);
            this.mnuHelpAbout.Text = "&About...";
            this.mnuHelpAbout.Click += new System.EventHandler(this.MnuHelpAbout_Click);
            // 
            // logoutToolStrip
            // 
            this.logoutToolStrip.Name = "logoutToolStrip";
            this.logoutToolStrip.Size = new System.Drawing.Size(116, 22);
            this.logoutToolStrip.Text = "&Logout";
            this.logoutToolStrip.Click += new System.EventHandler(this.LogoutToolStrip_Click);
            // 
            // btnCreatePO
            // 
            this.btnCreatePO.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePO.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCreatePO.Location = new System.Drawing.Point(10, 211);
            this.btnCreatePO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCreatePO.Name = "btnCreatePO";
            this.btnCreatePO.Size = new System.Drawing.Size(251, 49);
            this.btnCreatePO.TabIndex = 13;
            this.btnCreatePO.Text = "Create PO";
            this.btnCreatePO.UseVisualStyleBackColor = true;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 843);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.MenuStrip1);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDepartment)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private MdiTabControl.TabControl tabControl1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton tspNew;
        internal System.Windows.Forms.ToolStripButton tspOpen;
        internal System.Windows.Forms.ToolStripButton tspSave;
        internal System.Windows.Forms.ToolStripButton tspPrint;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        internal System.Windows.Forms.ToolStripButton tspCut;
        internal System.Windows.Forms.ToolStripButton tspCopy;
        internal System.Windows.Forms.ToolStripButton tspPaste;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        internal System.Windows.Forms.ToolStripButton tspAbout;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem mnuFile;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem mnuFilePrint;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        internal System.Windows.Forms.ToolStripMenuItem mnuEdit;
        internal System.Windows.Forms.ToolStripMenuItem mnuEditUndo;
        internal System.Windows.Forms.ToolStripMenuItem mnuEditRedo;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        internal System.Windows.Forms.ToolStripMenuItem mnuEditCut;
        internal System.Windows.Forms.ToolStripMenuItem mnuEditCopy;
        internal System.Windows.Forms.ToolStripMenuItem mnuEditPaste;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal System.Windows.Forms.ToolStripMenuItem mnuEditSelectAll;
        internal System.Windows.Forms.ToolStripMenuItem mainMenuHR;
        internal System.Windows.Forms.ToolStripMenuItem menuDepartment;
        internal System.Windows.Forms.ToolStripMenuItem menuEmployee;
        internal System.Windows.Forms.ToolStripMenuItem mnuRegularEmployee;
        internal System.Windows.Forms.ToolStripMenuItem mnuDeptHeadAddResource;
        internal System.Windows.Forms.ToolStripMenuItem mnuReport;
        internal System.Windows.Forms.ToolStripMenuItem mnuOverdueChargeReport;
        internal System.Windows.Forms.ToolStripMenuItem mnuHelp;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        internal System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        internal System.Windows.Forms.ToolStripMenuItem mnuRegularSupervisor;
        internal System.Windows.Forms.ToolStripMenuItem mnuCreatePurchaseOrderRS;
        internal System.Windows.Forms.ToolStripMenuItem ModifyPurchaseOrderRS;
        private System.Windows.Forms.PictureBox picDepartment;
        private System.Windows.Forms.PictureBox picEmployee;
        private System.Windows.Forms.Button btnModifyPO;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnProcessPO;
        private System.Windows.Forms.ToolStripMenuItem processPurchaseOrderRS;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStrip;
        private System.Windows.Forms.Button btnCreatePO;
    }
}

