namespace GreenSwitch.HR
{
    partial class Department_Form
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddDepatment = new System.Windows.Forms.Button();
            this.grpResourceInfo = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateOfCreation = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfPurchase = new System.Windows.Forms.Label();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.btnSearchDepartment = new System.Windows.Forms.Button();
            this.cmdDepartment = new System.Windows.Forms.ComboBox();
            this.btnUpdateDepartment = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.grpResourceInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 39);
            this.label2.TabIndex = 47;
            this.label2.Text = "Department";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(390, 379);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 36);
            this.btnExit.TabIndex = 46;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddDepatment
            // 
            this.btnAddDepatment.Location = new System.Drawing.Point(162, 379);
            this.btnAddDepatment.Name = "btnAddDepatment";
            this.btnAddDepatment.Size = new System.Drawing.Size(98, 36);
            this.btnAddDepatment.TabIndex = 45;
            this.btnAddDepatment.Text = "&Add New Department";
            this.btnAddDepatment.UseVisualStyleBackColor = true;
            this.btnAddDepatment.Click += new System.EventHandler(this.btnAddDepatment_Click);
            // 
            // grpResourceInfo
            // 
            this.grpResourceInfo.Controls.Add(this.txtDescription);
            this.grpResourceInfo.Controls.Add(this.txtName);
            this.grpResourceInfo.Controls.Add(this.label1);
            this.grpResourceInfo.Controls.Add(this.dtpDateOfCreation);
            this.grpResourceInfo.Controls.Add(this.lblDateOfPurchase);
            this.grpResourceInfo.Controls.Add(this.lblPublisher);
            this.grpResourceInfo.Location = new System.Drawing.Point(162, 88);
            this.grpResourceInfo.Name = "grpResourceInfo";
            this.grpResourceInfo.Size = new System.Drawing.Size(310, 271);
            this.grpResourceInfo.TabIndex = 44;
            this.grpResourceInfo.TabStop = false;
            this.grpResourceInfo.Text = "Resource Information";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(19, 94);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(260, 84);
            this.txtDescription.TabIndex = 48;
            this.txtDescription.Text = "";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(19, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(197, 20);
            this.txtName.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Department Name";
            // 
            // dtpDateOfCreation
            // 
            this.dtpDateOfCreation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfCreation.Location = new System.Drawing.Point(18, 229);
            this.dtpDateOfCreation.Name = "dtpDateOfCreation";
            this.dtpDateOfCreation.Size = new System.Drawing.Size(197, 20);
            this.dtpDateOfCreation.TabIndex = 7;
            // 
            // lblDateOfPurchase
            // 
            this.lblDateOfPurchase.AutoSize = true;
            this.lblDateOfPurchase.Location = new System.Drawing.Point(15, 213);
            this.lblDateOfPurchase.Name = "lblDateOfPurchase";
            this.lblDateOfPurchase.Size = new System.Drawing.Size(83, 13);
            this.lblDateOfPurchase.TabIndex = 6;
            this.lblDateOfPurchase.Text = "Invocation Date";
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(16, 78);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(60, 13);
            this.lblPublisher.TabIndex = 2;
            this.lblPublisher.Text = "Description";
            // 
            // btnSearchDepartment
            // 
            this.btnSearchDepartment.Location = new System.Drawing.Point(47, 169);
            this.btnSearchDepartment.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSearchDepartment.Name = "btnSearchDepartment";
            this.btnSearchDepartment.Size = new System.Drawing.Size(56, 20);
            this.btnSearchDepartment.TabIndex = 48;
            this.btnSearchDepartment.Text = "&Search";
            this.btnSearchDepartment.UseVisualStyleBackColor = true;
            this.btnSearchDepartment.Click += new System.EventHandler(this.btnSearchDepartment_Click);
            // 
            // cmdDepartment
            // 
            this.cmdDepartment.FormattingEnabled = true;
            this.cmdDepartment.Location = new System.Drawing.Point(16, 131);
            this.cmdDepartment.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdDepartment.Name = "cmdDepartment";
            this.cmdDepartment.Size = new System.Drawing.Size(120, 21);
            this.cmdDepartment.TabIndex = 49;
            // 
            // btnUpdateDepartment
            // 
            this.btnUpdateDepartment.Location = new System.Drawing.Point(278, 379);
            this.btnUpdateDepartment.Name = "btnUpdateDepartment";
            this.btnUpdateDepartment.Size = new System.Drawing.Size(98, 36);
            this.btnUpdateDepartment.TabIndex = 50;
            this.btnUpdateDepartment.Text = "&Update Department";
            this.btnUpdateDepartment.UseVisualStyleBackColor = true;
            this.btnUpdateDepartment.Click += new System.EventHandler(this.btnUpdateDepartment_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(278, 421);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 35);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(332, 453);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 12);
            this.button2.TabIndex = 52;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Department_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 501);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdateDepartment);
            this.Controls.Add(this.cmdDepartment);
            this.Controls.Add(this.btnSearchDepartment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAddDepatment);
            this.Controls.Add(this.grpResourceInfo);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Department_Form";
            this.Text = "Department";
            this.Load += new System.EventHandler(this.Department_Form_Load);
            this.grpResourceInfo.ResumeLayout(false);
            this.grpResourceInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnAddDepatment;
        internal System.Windows.Forms.GroupBox grpResourceInfo;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker dtpDateOfCreation;
        internal System.Windows.Forms.Label lblDateOfPurchase;
        internal System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Button btnSearchDepartment;
        private System.Windows.Forms.ComboBox cmdDepartment;
        internal System.Windows.Forms.Button btnUpdateDepartment;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button2;
    }
}