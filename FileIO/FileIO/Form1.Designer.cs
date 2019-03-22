namespace FileIO
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
            this.readButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.txtDataContents = new System.Windows.Forms.TextBox();
            this.encryptionButton = new System.Windows.Forms.Button();
            this.decryptionButton = new System.Windows.Forms.Button();
            this.simpleEncryptButton = new System.Windows.Forms.Button();
            this.simpleDecryptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(86, 340);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(156, 62);
            this.readButton.TabIndex = 0;
            this.readButton.Text = "Read Text File";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(476, 340);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(163, 62);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save Text To File";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // txtDataContents
            // 
            this.txtDataContents.Location = new System.Drawing.Point(86, 46);
            this.txtDataContents.Multiline = true;
            this.txtDataContents.Name = "txtDataContents";
            this.txtDataContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDataContents.Size = new System.Drawing.Size(553, 244);
            this.txtDataContents.TabIndex = 2;
            // 
            // encryptionButton
            // 
            this.encryptionButton.Location = new System.Drawing.Point(651, 18);
            this.encryptionButton.Name = "encryptionButton";
            this.encryptionButton.Size = new System.Drawing.Size(137, 53);
            this.encryptionButton.TabIndex = 3;
            this.encryptionButton.Text = "Encrypt (Rijndael)";
            this.encryptionButton.UseVisualStyleBackColor = true;
            this.encryptionButton.Click += new System.EventHandler(this.encryptionButton_Click);
            // 
            // decryptionButton
            // 
            this.decryptionButton.Location = new System.Drawing.Point(651, 89);
            this.decryptionButton.Name = "decryptionButton";
            this.decryptionButton.Size = new System.Drawing.Size(137, 60);
            this.decryptionButton.TabIndex = 4;
            this.decryptionButton.Text = "Decrypt (Rijndael)";
            this.decryptionButton.UseVisualStyleBackColor = true;
            this.decryptionButton.Click += new System.EventHandler(this.decryptionButton_Click);
            // 
            // simpleEncryptButton
            // 
            this.simpleEncryptButton.Location = new System.Drawing.Point(665, 174);
            this.simpleEncryptButton.Name = "simpleEncryptButton";
            this.simpleEncryptButton.Size = new System.Drawing.Size(105, 41);
            this.simpleEncryptButton.TabIndex = 5;
            this.simpleEncryptButton.Text = "Encrypt";
            this.simpleEncryptButton.UseVisualStyleBackColor = true;
            this.simpleEncryptButton.Click += new System.EventHandler(this.simpleEncryptButton_Click);
            // 
            // simpleDecryptButton
            // 
            this.simpleDecryptButton.Location = new System.Drawing.Point(665, 221);
            this.simpleDecryptButton.Name = "simpleDecryptButton";
            this.simpleDecryptButton.Size = new System.Drawing.Size(105, 39);
            this.simpleDecryptButton.TabIndex = 6;
            this.simpleDecryptButton.Text = "Decrypt";
            this.simpleDecryptButton.UseVisualStyleBackColor = true;
            this.simpleDecryptButton.Click += new System.EventHandler(this.simpleDecryptButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.simpleDecryptButton);
            this.Controls.Add(this.simpleEncryptButton);
            this.Controls.Add(this.decryptionButton);
            this.Controls.Add(this.encryptionButton);
            this.Controls.Add(this.txtDataContents);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.saveButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File IO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox txtDataContents;
        private System.Windows.Forms.Button encryptionButton;
        private System.Windows.Forms.Button decryptionButton;
        private System.Windows.Forms.Button simpleEncryptButton;
        private System.Windows.Forms.Button simpleDecryptButton;
    }
}

