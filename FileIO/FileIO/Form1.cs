using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace FileIO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string data = txtDataContents.Text;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text Contents |*.txt";
            dialog.FileName = ".txt";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                File.WriteAllText(fileName, data);
                MessageBox.Show("Data saved");
            } else
            {
                MessageBox.Show("Save error");
            }

            
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text Contents|*.txt";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                txtDataContents.Text = File.ReadAllText(fileName);
                isEncrypted = false;
            }
            encryptedSave = EncryptStringToBytes(txtDataContents.Text, myRijndael.Key, myRijndael.IV);
        }

        private byte[] encryptedSave;
        private Rijndael myRijndael;
        private Boolean isEncrypted = false;
 

        private void encryptionButton_Click(object sender, EventArgs e)
        {
            if (!isEncrypted)
            {
                encryptedSave = EncryptStringToBytes(txtDataContents.Text, myRijndael.Key, myRijndael.IV);
                isEncrypted = true;
                string s = Convert.ToBase64String(encryptedSave);
                txtDataContents.Text = s;
            } else
            {
                MessageBox.Show("Data is already encrypted");
            }
        }

        private void decryptionButton_Click(object sender, EventArgs e)
        {

            if (isEncrypted )
            {
                
                txtDataContents.Text = DecryptStringFromBytes(encryptedSave, myRijndael.Key, myRijndael.IV);
                
                isEncrypted = false;
            } else
            {
                MessageBox.Show("Data is already decrypted");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myRijndael = Rijndael.Create();
        }

   static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;
                rijAlg.Padding = PaddingMode.PKCS7;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;
                rijAlg.Padding = PaddingMode.PKCS7;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        
        }

        private Int16 shift = 3;

        private void simpleEncryptButton_Click(object sender, EventArgs e)
        {
            txtDataContents.Text = Cipher(txtDataContents.Text, shift);
        }

        private void simpleDecryptButton_Click(object sender, EventArgs e)
        {
            txtDataContents.Text = Decipher(txtDataContents.Text, shift);
        }

        // credit https://www.youtube.com/watch?v=2ruqxHVlZfM
        static string Cipher(string text, int shift)
        {
            var result = string.Empty; 

            
            var firstCharCode = 'A';
            var offset = ('z' - 'A') + 1;

            foreach (var c in text)
            {
                var newChar = ' ';

                if ( c != ' ' )
                {
                    var oldIdxInAlphabet = c - firstCharCode;

                    var idxShifted = oldIdxInAlphabet + shift;
                    while (idxShifted < 0) idxShifted = offset + idxShifted;

                    var newIdxInAlphabet = idxShifted % offset;

                    newChar = (char)(firstCharCode + newIdxInAlphabet);
                }

                result += newChar;
            }



            return result;
        }

        static string Decipher(string CipheredText, int shift)
        {
            return Cipher(CipheredText, shift * -1);
        }
    }
}
