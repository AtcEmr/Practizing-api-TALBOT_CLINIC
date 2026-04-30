using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PractiZing.BusinessLogic.Common
{
    public class EncryptionProvider
    {
        byte[] result;
        public string _encryptionKey = "379ACD0B1OP2EFIJKL45GH6MNQRSTU8VWXYZ";
        byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        byte[] iv = { 65, 110, 68, 26, 69, 178, 200, 219 };

        public byte[] Encrypt(string strString)
        {
            UTF8Encoding utf8encoder = new UTF8Encoding();
            byte[] inputInBytes = utf8encoder.GetBytes(strString);
            TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();
            //  The ICryptTransform interface uses the TripleDES
            //  crypt provider along with encryption key and init vector
            //  information
            ICryptoTransform cryptoTransform = tdesProvider.CreateEncryptor(key, iv);
            //  All cryptographic functions need a stream to output the
            //  encrypted information. Here we declare a memory stream
            //  for this purpose.
            MemoryStream encryptedStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write);
            //  Write the encrypted information to the stream. Flush the information
            //  when done to ensure everything is out of the buffer.
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
            cryptStream.FlushFinalBlock();
            encryptedStream.Position = 0;
            //  Read the stream back into a Byte array and return it to the calling
            //  method.

            encryptedStream.Read(result, 0, Convert.ToInt16(cryptStream.Length));
            cryptStream.Close();
            return result;
            
        }


        public string Decrypt(byte[] bytInputInBytes)
        {
            //  UTFEncoding is used to transform the decrypted Byte Array
            //  information back into a string.
            UTF8Encoding utf8encoder = new UTF8Encoding();
            TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();
            string strReturn;
            //  As before we must provide the encryption/decryption key along with
            //  the init vector.
            ICryptoTransform cryptoTransform = tdesProvider.CreateDecryptor(key, iv);
            //  Provide a memory stream to decrypt information into
            MemoryStream decryptedStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write);
            cryptStream.Write(bytInputInBytes, 0, bytInputInBytes.Length);
            cryptStream.FlushFinalBlock();
            decryptedStream.Position = 0;
            //  Read the memory stream and convert it back into a string
            decryptedStream.Read(result, 0, Convert.ToInt16(decryptedStream.Length));
            UTF8Encoding myutf = new UTF8Encoding();
            strReturn = myutf.GetString(result);
            tdesProvider.Clear();
            cryptoTransform.Dispose();
            decryptedStream.Close();
            decryptedStream.Dispose();
            cryptStream.Close();
            cryptStream.Dispose();
            return strReturn;
        }

        public Rfc2898DeriveBytes GetRfcBytes()
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(
                                            _encryptionKey,
                                            new byte[] {
                                                0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                                            });
            return pdb;
        }

        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return "";

            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = GetRfcBytes();

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        //cs.Dispose();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
