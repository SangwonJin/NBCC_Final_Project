namespace GreenSwitch.HR
{
    partial class Modification_Main
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
            this.btnPersonal = new System.Windows.Forms.Button();
            this.btnJob = new System.Windows.Forms.Button();
            this.btnEmployment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPersonal
            // 
            this.btnPersonal.Location = new System.Drawing.Point(77, 253);
            this.btnPersonal.Name = "btnPersonal";
            this.btnPersonal.Size = new System.Drawing.Size(171, 71);
            this.btnPersonal.TabIndex = 0;
            this.btnPersonal.Text = "Modify Personal Info";
            this.btnPersonal.UseVisualStyleBackColor = true;
            this.btnPersonal.Click += new System.EventHandler(this.btnPersonal_Click);
            // 
            // btnJob
            // 
            this.btnJob.Location = new System.Drawing.Point(300, 253);
            this.btnJob.Name = "btnJob";
            this.btnJob.Size = new System.Drawing.Size(140, 71);
            this.btnJob.TabIndex = 1;
            this.btnJob.Text = "Modify Job Info";
            this.btnJob.UseVisualStyleBackColor = true;
            this.btnJob.Click += new System.EventHandler(this.btnJob_Click);
            // 
            // btnEmployment
            // 
            this.btnEmployment.Location = new System.Drawing.Point(494, 253);
            this.btnEmployment.Name = "btnEmployment";
            this.btnEmployment.Size = new System.Drawing.Size(186, 71);
            this.btnEmployment.TabIndex = 2;
            this.btnEmployment.Text = "Modify Employment Status";
            this.btnEmployment.UseVisualStyleBackColor = true;
            this.btnEmployment.Click += new System.EventHandler(this.btnEmployment_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Gulim", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(132, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(548, 49);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose a option below";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 52);
            this.label2.TabIndex = 50;
            this.label2.Text = "Modification";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(342, 371);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(77, 48);
            this.btnExit.TabIndex = 51;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Modification_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEmployment);
            this.Controls.Add(this.btnJob);
            this.Controls.Add(this.btnPersonal);
            this.Name = "Modification_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modification_Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPersonal;
        private System.Windows.Forms.Button btnJob;
        private System.Windows.Forms.Button btnEmployment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnExit;
    }
}