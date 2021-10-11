
namespace WorldTournament
{
    partial class FormStartup
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStartup));
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnEditFighter = new System.Windows.Forms.Button();
            this.btnCheckFighter = new System.Windows.Forms.Button();
            this.btnDeleteFighter = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(60, 185);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(124, 23);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "Register New Fighter";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnEditFighter
            // 
            this.btnEditFighter.Location = new System.Drawing.Point(142, 214);
            this.btnEditFighter.Name = "btnEditFighter";
            this.btnEditFighter.Size = new System.Drawing.Size(115, 23);
            this.btnEditFighter.TabIndex = 1;
            this.btnEditFighter.Text = "Edit Fighter Info";
            this.btnEditFighter.UseVisualStyleBackColor = true;
            this.btnEditFighter.Click += new System.EventHandler(this.btnEditFighter_Click);
            // 
            // btnCheckFighter
            // 
            this.btnCheckFighter.Location = new System.Drawing.Point(263, 214);
            this.btnCheckFighter.Name = "btnCheckFighter";
            this.btnCheckFighter.Size = new System.Drawing.Size(136, 23);
            this.btnCheckFighter.TabIndex = 2;
            this.btnCheckFighter.Text = "Check Fighter Info";
            this.btnCheckFighter.UseVisualStyleBackColor = true;
            this.btnCheckFighter.Click += new System.EventHandler(this.btnCheckFighter_Click);
            // 
            // btnDeleteFighter
            // 
            this.btnDeleteFighter.Location = new System.Drawing.Point(334, 185);
            this.btnDeleteFighter.Name = "btnDeleteFighter";
            this.btnDeleteFighter.Size = new System.Drawing.Size(90, 23);
            this.btnDeleteFighter.TabIndex = 3;
            this.btnDeleteFighter.Text = "Delete Fighter";
            this.btnDeleteFighter.UseVisualStyleBackColor = true;
            this.btnDeleteFighter.Click += new System.EventHandler(this.btnDeleteFighter_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(117, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(264, 27);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "World Martial Arts Tournment";
            // 
            // FormStartup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(493, 249);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnDeleteFighter);
            this.Controls.Add(this.btnCheckFighter);
            this.Controls.Add(this.btnEditFighter);
            this.Controls.Add(this.btnRegister);
            this.Name = "FormStartup";
            this.Text = "World Tournment Applicants";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnEditFighter;
        private System.Windows.Forms.Button btnCheckFighter;
        private System.Windows.Forms.Button btnDeleteFighter;
        private System.Windows.Forms.Label lblTitle;
    }
}

