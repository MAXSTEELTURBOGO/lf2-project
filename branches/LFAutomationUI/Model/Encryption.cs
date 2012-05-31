using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace LFAutomationUI.Model
{
    /// <summary>
    /// 加密类
    /// </summary>
    public class Encryption
    {
        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        public Encryption()
        {
        }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="encryptString">要加密的字符串</param>
        /// <param name="encryptKey">密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string encryptString, string encryptKey)
        {
            try
            {
                byte[] keys = Encoding.UTF8.GetBytes(encryptKey.PadRight(8, '?').ToCharArray(), 0, 8);
                byte[] rgbKey=new byte[8];
                Array.Copy(keys, rgbKey, 8);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="decryptString">要解密的字符串</param>
        /// <param name="decryptKey">密钥</param>
        /// <returns>解密后的字符串</returns>
        private static string Decrypt(string decryptString, string decryptKey)
        {
            try
            {
                byte[] keys = Encoding.UTF8.GetBytes(decryptKey.PadRight(8, '?').ToCharArray(), 0, 8);
                byte[] rgbKey = new byte[8];
                Array.Copy(keys,rgbKey,8);

                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }
    }

}



