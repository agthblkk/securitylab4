namespace seclab4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnSwitchLanguage;
        private System.Windows.Forms.Label lblDecrypted;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnSwitchLanguage = new System.Windows.Forms.Button();
            this.lblDecrypted = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(50, 50);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(300, 100);
            this.txtInput.TabIndex = 0;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(50, 170);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(100, 23);
            this.btnLoadFile.TabIndex = 1;
            this.btnLoadFile.Text = "Завантажити";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(50, 210);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(100, 23);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "Шифрувати";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(200, 210);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(100, 23);
            this.btnDecrypt.TabIndex = 3;
            this.btnDecrypt.Text = "Розшифрувати";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnSwitchLanguage
            // 
            this.btnSwitchLanguage.Location = new System.Drawing.Point(50, 250);
            this.btnSwitchLanguage.Name = "btnSwitchLanguage";
            this.btnSwitchLanguage.Size = new System.Drawing.Size(250, 23);
            this.btnSwitchLanguage.TabIndex = 4;
            this.btnSwitchLanguage.Text = "Switch to English";
            this.btnSwitchLanguage.UseVisualStyleBackColor = true;
            this.btnSwitchLanguage.Click += new System.EventHandler(this.btnSwitchLanguage_Click);
            // 
            // lblDecrypted
            // 
            // lblDecrypted
            this.lblDecrypted.AutoSize = true;
            this.lblDecrypted.Location = new System.Drawing.Point(50, 300);
            this.lblDecrypted.Name = "lblDecrypted";
            this.lblDecrypted.Size = new System.Drawing.Size(0, 13);
            this.lblDecrypted.TabIndex = 5;
            this.lblDecrypted.Text = "Файл збережено до:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnSwitchLanguage);
            this.Controls.Add(this.lblDecrypted);
            this.Name = "Form1";
            this.Text = "DES Encryption";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
