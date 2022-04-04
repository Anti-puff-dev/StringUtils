using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace StringUtils
{
    public class Cryptography
    {
        public static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;

        }


        public static string Md5Encrypt(string word, string key)
        {
            if (key == "" || key == null)
            {
                return System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(word));
            }
            else
            {
                try
                {
                    byte[] keyArray;
                    byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(word);

                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();


                    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                    tdes.Key = keyArray;
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tdes.CreateEncryptor();
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                    tdes.Clear();
                    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                }
                catch (Exception err)
                {
                }
            }

            return "";
        }

        public static string Md5Decrypt(string word, string key)
        {
            if (key == "" || key == null)
            {
                return System.Text.ASCIIEncoding.ASCII.GetString(System.Convert.FromBase64String(word));
            }
            else
            {
                try
                {
                    byte[] keyArray;
                    byte[] toEncryptArray = Convert.FromBase64String(word);

                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();

                    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                    tdes.Key = keyArray;
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tdes.CreateDecryptor();
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                    tdes.Clear();
                    return UTF8Encoding.UTF8.GetString(resultArray);
                }
                catch (Exception err)
                {
                }
            }

            return "";
        }
    }
}
