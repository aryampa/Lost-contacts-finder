using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace LostContactFinder._01_Automated
{
    class EncAndDec
    {
        Byte[] key_bytes;

        public EncAndDec(String key)
        {//constructor accepts base64String  string as imput......




            key_bytes = Convert.FromBase64String(key);// convert base64string to bytes....

        }

        public string encryptData(string Data)
        {

            try
            {
                Byte[] text_to_encrypt_bytes = UTF8Encoding.UTF8.GetBytes(Data);

                MD5CryptoServiceProvider hasHmd5 = new MD5CryptoServiceProvider();

                Byte[] hashingKey = hasHmd5.ComputeHash(key_bytes);

                hasHmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = hashingKey;

                tdes.Mode = CipherMode.ECB;

                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encrypt_transformer = tdes.CreateEncryptor();

                Byte[] encryted_result = encrypt_transformer.TransformFinalBlock(text_to_encrypt_bytes, 0, text_to_encrypt_bytes.Length);

                tdes.Clear();

                return Convert.ToBase64String(encryted_result, 0, encryted_result.Length);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Data Encryption Error Occured: " + ex.Message, "Data Encryption Error");
            }

            return "";
        }

        public string dencryptData(string textData)
        {
            try
            {

                Byte[] encrted_data_bytes = Convert.FromBase64String(textData);

                MD5CryptoServiceProvider hasHmd5 = new MD5CryptoServiceProvider();

                Byte[] hashingKey = hasHmd5.ComputeHash(key_bytes);

                hasHmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = hashingKey;

                tdes.Mode = CipherMode.ECB;

                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decrypt_transformer = tdes.CreateDecryptor();

                Byte[] decrypted_result = decrypt_transformer.TransformFinalBlock(encrted_data_bytes, 0, encrted_data_bytes.Length);

                tdes.Clear();

                return UTF8Encoding.UTF8.GetString(decrypted_result);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalid Key or UserName.", "Data De-Encrption Error: " + ex.Message);

            }

            return "";


        }
    }
}
