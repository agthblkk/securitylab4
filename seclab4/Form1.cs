using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace seclab4
{
    public partial class Form1 : Form
    {
        private DESCryptoServiceProvider desProvider;
        private bool isUkrainian = true;

        public Form1()
        {
            InitializeComponent(); // Метод, який налаштовує компоненти з Designer
            desProvider = new DESCryptoServiceProvider();
            InitializeLanguage(); // Метод для встановлення мови
        }

        private void InitializeLanguage()
        {
            if (isUkrainian)
            {
                btnEncrypt.Text = "Шифрувати";
                btnDecrypt.Text = "Розшифрувати";
                lblDecrypted.Text = ""; // Очищаємо текст, щоб уникнути статичних повідомлень
                btnLoadFile.Text = "Завантажити файл";
                btnSwitchLanguage.Text = "Switch to English";
            }
            else
            {
                btnEncrypt.Text = "Encrypt";
                btnDecrypt.Text = "Decrypt";
                lblDecrypted.Text = ""; // Очищаємо текст
                btnLoadFile.Text = "Load File";
                btnSwitchLanguage.Text = "Переключити на українську";
            }
        }





        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    txtInput.Text = File.ReadAllText(filePath); // Зчитуємо текст із вибраного файлу
                }
            }
        }


private void btnEncrypt_Click(object sender, EventArgs e)
{
    try
    {
        if (string.IsNullOrWhiteSpace(txtInput.Text))
        {
            MessageBox.Show(isUkrainian ? "Будь ласка, введіть текст для шифрування." : "Please enter text to encrypt.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
            DefaultExt = "txt",
            AddExtension = true
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string encryptedFilePath = saveFileDialog.FileName;

            // Налаштування DES
            desProvider.Key = Encoding.UTF8.GetBytes("ABCDEFGH"); // Використовуйте UTF-8 для підтримки українських символів
            desProvider.IV = Encoding.UTF8.GetBytes("ABCDEFGH");
            desProvider.Padding = PaddingMode.PKCS7;
            desProvider.Mode = CipherMode.CBC;

            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(txtInput.Text);

            using (FileStream fs = new FileStream(encryptedFilePath, FileMode.Create))
            using (CryptoStream cryptoStream = new CryptoStream(fs, desProvider.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
            }

            lblDecrypted.Text = isUkrainian 
                ? $"Файл зашифровано і збережено до: {encryptedFilePath}" 
                : $"File encrypted and saved to: {encryptedFilePath}";
            lblDecrypted.Refresh();

            MessageBox.Show(isUkrainian ? "Файл успішно зашифровано!" : "File encrypted successfully!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(isUkrainian ? "Помилка шифрування: " : $"Encryption error: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}





private void btnDecrypt_Click(object sender, EventArgs e)
{
    try
    {
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string encryptedFilePath = openFileDialog.FileName;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                DefaultExt = "txt",
                AddExtension = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string decryptedFilePath = saveFileDialog.FileName;

                // Налаштування DES
                desProvider.Key = Encoding.UTF8.GetBytes("ABCDEFGH");
                desProvider.IV = Encoding.UTF8.GetBytes("ABCDEFGH");
                desProvider.Padding = PaddingMode.PKCS7;
                desProvider.Mode = CipherMode.CBC;

                byte[] decryptedBytes;

                using (FileStream fs = new FileStream(encryptedFilePath, FileMode.Open))
                using (CryptoStream cryptoStream = new CryptoStream(fs, desProvider.CreateDecryptor(), CryptoStreamMode.Read))
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    cryptoStream.CopyTo(memoryStream);
                    decryptedBytes = memoryStream.ToArray();
                }

                string decryptedText = Encoding.UTF8.GetString(decryptedBytes); // Українські символи
                File.WriteAllText(decryptedFilePath, decryptedText);

                lblDecrypted.Text = isUkrainian 
                    ? $"Файл збережено до: {decryptedFilePath}" 
                    : $"File saved to: {decryptedFilePath}";
                lblDecrypted.Refresh();

                MessageBox.Show(isUkrainian ? "Файл успішно розшифровано!" : "File decrypted successfully!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(isUkrainian ? "Помилка розшифрування: " : $"Decryption error: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

        private void btnSwitchLanguage_Click(object sender, EventArgs e)
        {
            isUkrainian = !isUkrainian;
            InitializeLanguage();
        }

    }
}
