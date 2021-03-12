namespace QueryRegistry
{
    partial class Form1
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
            this.UpdateComputers = new System.Windows.Forms.Button();
            this.CheckMyPC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UpdateComputers
            // 
            this.UpdateComputers.Location = new System.Drawing.Point(140, 111);
            this.UpdateComputers.Name = "UpdateComputers";
            this.UpdateComputers.Size = new System.Drawing.Size(136, 23);
            this.UpdateComputers.TabIndex = 0;
            this.UpdateComputers.Text = "Update Computers";
            this.UpdateComputers.UseVisualStyleBackColor = true;
            this.UpdateComputers.Click += new System.EventHandler(this.button1_Click);
            // 
            // CheckMyPC
            // 
            this.CheckMyPC.Location = new System.Drawing.Point(140, 50);
            this.CheckMyPC.Name = "CheckMyPC";
            this.CheckMyPC.Size = new System.Drawing.Size(136, 23);
            this.CheckMyPC.TabIndex = 1;
            this.CheckMyPC.Text = "Check PCs";
            this.CheckMyPC.UseVisualStyleBackColor = true;
            this.CheckMyPC.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CheckMyPC);
            this.Controls.Add(this.UpdateComputers);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UpdateComputers;
        private System.Windows.Forms.Button CheckMyPC;
    }
}

