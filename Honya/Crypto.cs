using System;
using System.Security.Cryptography;
using System.Text;

namespace Honya
{
    public class Crypto
    {
        public static readonly string CryptoKey = "p7ntX8hjRNmznpfkk081z1NWCyjRS2Cc";
        private static byte[] cryptoKeyBytes;
        public static byte[] CryptoKeyBytes
        {
            get
            {
                if (cryptoKeyBytes == null)
                {
                    cryptoKeyBytes = Encoding.UTF8.GetBytes(CryptoKey);
                }

                return cryptoKeyBytes;
            }
        }

        public static byte[] Decrypt(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                return data;
            }

            var iv = new byte[CryptoKeyBytes.Length];
            Array.Copy(data, iv, iv.Length);
            var _data = new byte[data.Length - CryptoKeyBytes.Length];
            Array.Copy(data, CryptoKeyBytes.Length, _data, 0, _data.Length);

            var rijndaelManaged = new RijndaelManaged()
            {
                BlockSize = CryptoKeyBytes.Length * 8,
                KeySize = CryptoKeyBytes.Length * 8,
                IV = iv,
                Key = CryptoKeyBytes,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
            };

            using (var transform = rijndaelManaged.CreateDecryptor())
            {
                return transform.TransformFinalBlock(_data, 0, _data.Length);
            }
        }
    }
}
