namespace seclab4.Tests;

using System.IO;
using System.Security.Cryptography;
using System.Text;
using Xunit;
using seclab4;

public class EncryptionTests
{
    private readonly DESCryptoServiceProvider desProvider;

    public EncryptionTests()
    {
        desProvider = new DESCryptoServiceProvider
        {
            Key = Encoding.UTF8.GetBytes("ABCDEFGH"),
            IV = Encoding.UTF8.GetBytes("ABCDEFGH"),
            Padding = PaddingMode.PKCS7,
            Mode = CipherMode.CBC
        };
    }

    [Fact]
    public void EncryptAndDecrypt_ShouldReturnOriginalText()
    {
        // Arrange
        string originalText = "Привіт, це тест!";
        string encryptedFilePath = "encrypted_test.txt";
        string decryptedFilePath = "decrypted_test.txt";

        // Act
        EncryptTextToFile(originalText, encryptedFilePath);
        string decryptedText = DecryptTextFromFile(encryptedFilePath, decryptedFilePath);

        // Assert
        Assert.Equal(originalText, decryptedText);

        // Clean up
        File.Delete(encryptedFilePath);
        File.Delete(decryptedFilePath);
    }

    private void EncryptTextToFile(string text, string filePath)
    {
        byte[] dataToEncrypt = Encoding.UTF8.GetBytes(text);

        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        using (CryptoStream cryptoStream = new CryptoStream(fs, desProvider.CreateEncryptor(), CryptoStreamMode.Write))
        {
            cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
        }
    }

    private string DecryptTextFromFile(string encryptedFilePath, string decryptedFilePath)
    {
        byte[] decryptedBytes;

        using (FileStream fs = new FileStream(encryptedFilePath, FileMode.Open))
        using (CryptoStream cryptoStream = new CryptoStream(fs, desProvider.CreateDecryptor(), CryptoStreamMode.Read))
        using (MemoryStream memoryStream = new MemoryStream())
        {
            cryptoStream.CopyTo(memoryStream);
            decryptedBytes = memoryStream.ToArray();
        }

        string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

        File.WriteAllText(decryptedFilePath, decryptedText);

        return decryptedText;
    }
}
