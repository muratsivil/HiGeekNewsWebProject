using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HiGeekNewsWebProject.Associate.Helpers
{
    public class EncryptionHelper
    {

        private const string EncryptionPassword = "HiGeek_2020";
        private static readonly byte[] DefaultInitVertor = { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

        public static byte[] Encrypt(byte[] clearData, byte[] key, byte[] iv)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = key;
            alg.IV = iv;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        public static string Encrypt(string clearText, string password)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, DefaultInitVertor);
            byte[] encrytedata = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encrytedata);
        }

        public static string Encrypt(string clearText)
        {
            return Encrypt(clearText, EncryptionPassword);
        }

        public static string Decrypt(byte[] chiperData, byte[] key, byte[] iv)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = key;
            alg.IV = iv;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(chiperData, 0, chiperData.Length);
            cs.Close();
            byte[] decryptedData = ms.ToArray();
            return decryptedData.ToString();
        }

        public static string Decrypt(string chiperText, string password)
        {
            byte[] chiperBytes = Convert.FromBase64String(chiperText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, DefaultInitVertor);
            byte[] decryptData = Encoding.Unicode.GetBytes(Decrypt(chiperBytes, pdb.GetBytes(32), pdb.GetBytes(16)));
            return Encoding.Unicode.GetString(decryptData);
        }

        public static string Decrypt(string chiperText)
        {
            return Decrypt(chiperText, EncryptionPassword);
        }

        public static string GetMd5(string strSource)
        {
            Encoder enc = Encoding.Unicode.GetEncoder();

            byte[] unicodeText = new byte[strSource.Length * 2];
            enc.GetBytes(strSource.ToCharArray(), 0, strSource.Length, unicodeText, 0, true);

            byte[] result = new MD5CryptoServiceProvider().ComputeHash(unicodeText);
            string strResult = Convert.ToBase64String(result);
            return strResult.Substring(0, strResult.Length - 2);
        }
    }
}
