using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string cipherText = encryptedText.Text;

                string plainText = DecryptCipherText(cipherText, filePath);

                encryptedText.Text = "";
                decryptedText.Text = plainText;
            }

        }

        

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string plainText = decryptedText.Text;

                string cipherText = GetCipherText(plainText, filePath);

                encryptedText.Text = cipherText;
                decryptedText.Text = "";
            }
        }

        private string DecryptCipherText(string cipherText, string privateKeyPath)
        {
            RSACryptoServiceProvider cipher = new RSACryptoServiceProvider();
            cipher.FromXmlString(File.ReadAllText(privateKeyPath));
            byte[] original = cipher.Decrypt(Convert.FromBase64String(cipherText), false);
            return Encoding.UTF8.GetString(original);
        }

        private string GetCipherText(string plaintext, string publicKeyPath)
        {
            RSACryptoServiceProvider cipher = new RSACryptoServiceProvider();
            cipher.FromXmlString(File.ReadAllText(publicKeyPath));
            byte[] data = Encoding.UTF8.GetBytes(plaintext);
            byte[] cipherText = cipher.Encrypt(data, false);
            return Convert.ToBase64String(cipherText);
        }

        private void btnGeneratePair_Click(object sender, EventArgs e)
        {
            GenerateKeys("public.xml", "private.xml");
        }

        private void GenerateKeys(string publicKeyFileName, string privateKeyFileName)
        {

            // Variables
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaProvider = null;
            StreamWriter publicKeyFile = null;
            StreamWriter privateKeyFile = null;

            string publicKey = "";
            string privateKey = "";

            try
            {

                // Create a new key pair on target CSP
                cspParams = new CspParameters();
                cspParams.ProviderType = 1; // PROV_RSA_FULL
                //cspParams.ProviderName; // CSP name

                cspParams.Flags = CspProviderFlags.UseArchivableKey;
                cspParams.KeyNumber = (int)KeyNumber.Exchange;
                rsaProvider = new RSACryptoServiceProvider(cspParams);

                // Export public key
                publicKey = rsaProvider.ToXmlString(false);

                // Write public key to file            
                publicKeyFile = File.CreateText(publicKeyFileName);
                publicKeyFile.Write(publicKey);


                // Export private/public key pair
                privateKey = rsaProvider.ToXmlString(true);

                // Write private/public key pair to file
                privateKeyFile = File.CreateText(privateKeyFileName);
                privateKeyFile.Write(privateKey);

            }
            catch (Exception ex)
            {

                // Any errors? Show them

                Console.WriteLine("Exception generating a new key pair! More info:");
                Console.WriteLine(ex.Message);
            }
            finally
            {

                // Do some clean up if needed

                if (publicKeyFile != null)
                {
                    publicKeyFile.Close();
                }

                if (privateKeyFile != null)
                {
                    privateKeyFile.Close();
                }
            }
        } // Keys
    }
}
