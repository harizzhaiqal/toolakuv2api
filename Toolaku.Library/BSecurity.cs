using System;
using System.Security.Cryptography;
using System.IO;
using System.Web;

namespace Toolaku.Library
{
    public class BSecurity
    {
        /// <summary>
        /// Encrypt using AES
        /// </summary>
        /// <param name="plainText">string password</param>
        /// <param name="Key">byte[] AES_Key</param>
        /// <param name="IV">byte[] AES_IV</param>
        /// <returns>return password in byte[]</returns>
        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            // Create an AesManaged object 
            // with the specified key and IV. 
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

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

        /// <summary>
        /// Decrypt using AES
        /// </summary>
        /// <param name="cipherText">string encryptedPassword</param>
        /// <param name="Key">byte[] AES_Key</param>
        /// <param name="IV">byte[] AES_IV</param>
        /// <returns>return password in string</returns>
        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an AesManaged object 
            // with the specified key and IV. 
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

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

        /// <summary>
        /// utilty function to convert string to byte[] 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] GetBytes(string str)
        {
            return Convert.FromBase64String(str);
        }

        /// <summary>
        /// utilty function to convert byte[] to string  
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetString(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// generate new salt value
        /// </summary>
        /// <returns></returns>
        public static string GetSaltValue()
        {
            string saltValue = System.Guid.NewGuid().ToString().Replace("-", "").ToUpper();

            return saltValue;
        }

        /// <summary>
        /// generate new AES_Key
        /// </summary>
        /// <returns></returns>
        public static string generateAES_Key()
        {
            using (AesManaged myAes = new AesManaged())
            {
                return GetString(myAes.Key);
            }
        }

        /// <summary>
        /// generate new AES_IV
        /// </summary>
        /// <returns></returns>
        public static string generateAES_IV()
        {
            using (AesManaged myAes = new AesManaged())
            {
                return GetString(myAes.IV);
            }
        }

        /// <summary>
        /// Encrypt password using AES-256 algorithm
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="aes_key"></param>
        /// <param name="aes_iv"></param>
        /// <returns></returns>
        public static string Encrypt_AES(string password, string salt, string aes_key, string aes_iv)
        {
            try
            {
                byte[] lbyteAESKey;
                byte[] lbyteAESIV;
                string lstrEncryptedPassword = string.Empty;

                //default add salt infront of password
                password = salt + password;

                lbyteAESKey = GetBytes(aes_key);
                lbyteAESIV = GetBytes(aes_iv);

                // Encrypt the string to an array of bytes. 
                byte[] encrypted = EncryptStringToBytes_Aes(password, lbyteAESKey, lbyteAESIV);

                lstrEncryptedPassword = GetString(encrypted);

                return lstrEncryptedPassword;
            }
            catch (Exception e)
            {
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
                throw e;
            }
        }

        /// <summary>
        /// Decrypt password using AES-256 algorithm
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="aes_key"></param>
        /// <param name="aes_iv"></param>
        /// <returns></returns>
        public static string Decrypt_AES(string password, string salt, string aes_key, string aes_iv)
        {
            try
            {
                byte[] lbyteAESKey;
                byte[] lbyteAESIV;
                byte[] lbytePassword;
                string lstrDecryptedPassword = string.Empty;

                lbyteAESKey = GetBytes(aes_key);
                lbyteAESIV = GetBytes(aes_iv);

                using (AesManaged myAes = new AesManaged())
                {
                    lbytePassword = GetBytes(password);

                    // Decrypt the bytes to a string. 
                    lstrDecryptedPassword = DecryptStringFromBytes_Aes(lbytePassword, lbyteAESKey, lbyteAESIV);
                }

                //remove salt value
                lstrDecryptedPassword = lstrDecryptedPassword.Replace(salt, "");

                return lstrDecryptedPassword;
            }
            catch (Exception e)
            {
                //string context = Common.ToStr(System.Web.HttpContext.Current);
                //clsErrorLog.ErrorLog(context, e);
                throw e; ;
            }
        }

    }
}
