using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace System.Extensions
{
    public static class BinaryExtensions
    {
        #region BinaryWriter

        /// <summary>
        /// Writes data to a BinaryWriter in chunks of the specified buffer size.
        /// </summary>
        /// <param name="writer">The BinaryWriter to write data to.</param>
        /// <param name="data">The data to write.</param>
        /// <param name="buffer">The size of the buffer for chunked writing.</param>
        public static void Write(this BinaryWriter writer, byte[] data, int buffer)
        {
            int length = data.Length;
            int count = length / buffer;
            int flush = count * buffer;

            for (int index = 0; index < count; index++)
            {
                writer.Write(data, index * buffer, buffer);
                writer.Flush();
            }

            if (length > flush)
            {
                writer.Write(data, flush, length - flush);
            }
            writer.Flush();
        }

        #endregion

        #region Byte Array

        /// <summary>
        /// Decrypts the byte array using AES encryption with the specified key.
        /// The key is also used as the IV.
        /// </summary>
        /// <param name="data">The encrypted data.</param>
        /// <param name="key">The decryption key.</param>
        /// <returns>The decrypted byte array.</returns>
        public static byte[] FromAES(this byte[] data, string key)
        {
            return FromAES(data, key, key);
        }

        /// <summary>
        /// Decrypts the byte array using AES encryption with the specified key and IV.
        /// </summary>
        /// <param name="data">The encrypted data.</param>
        /// <param name="key">The decryption key.</param>
        /// <param name="iv">The initialization vector.</param>
        /// <returns>The decrypted byte array.</returns>
        public static byte[] FromAES(this byte[] data, string key, string iv)
        {
            using (var crypto = Aes.Create())
            {
                crypto.Key = key.ToUTF8();
                crypto.IV = iv.ToUTF8();
                using (var decryptor = crypto.CreateDecryptor())
                {
                    return decryptor.TransformFinalBlock(data, 0, data.Length);
                }
            }
        }

        /// <summary>
        /// Encrypts the byte array using AES encryption with the specified key.
        /// The key is also used as the IV.
        /// </summary>
        /// <param name="data">The data to encrypt.</param>
        /// <param name="key">The encryption key.</param>
        /// <returns>The encrypted byte array.</returns>
        public static byte[] ToAES(this byte[] data, string key)
        {
            return ToAES(data, key, key);
        }

        /// <summary>
        /// Encrypts the byte array using AES encryption with the specified key and IV.
        /// </summary>
        /// <param name="data">The data to encrypt.</param>
        /// <param name="key">The encryption key.</param>
        /// <param name="iv">The initialization vector.</param>
        /// <returns>The encrypted byte array.</returns>
        public static byte[] ToAES(this byte[] data, string key, string iv)
        {
            using (var crypto = Aes.Create())
            {
                crypto.Key = key.ToUTF8();
                crypto.IV = iv.ToUTF8();
                using (ICryptoTransform encryptor = crypto.CreateEncryptor())
                {
                    return encryptor.TransformFinalBlock(data, 0, data.Length);
                }
            }
        }

        /// <summary>
        /// Converts the byte array to a Base64-encoded string.
        /// </summary>
        /// <param name="data">The byte array to encode.</param>
        /// <returns>A Base64-encoded string representation of the byte array.</returns>
        public static string ToBase64(this byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// Converts the byte array to a hexadecimal string.
        /// </summary>
        /// <param name="data">The byte array to convert.</param>
        /// <returns>A hexadecimal string representation of the byte array.</returns>
        public static string ToHex(this byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", "");
        }

        /// <summary>
        /// Computes the MD5 hash of the byte array.
        /// </summary>
        /// <param name="data">The data to hash.</param>
        /// <returns>The MD5 hash as a byte array.</returns>
        public static byte[] ToMD5(this byte[] data)
        {
            using (var crypto = MD5.Create())
            {
                return crypto.ComputeHash(data);
            }
        }

        /// <summary>
        /// Decodes the byte array to a UTF-8 string.
        /// </summary>
        /// <param name="data">The byte array to decode.</param>
        /// <returns>A UTF-8 string representation of the byte array.</returns>
        public static string ToUTF8(this byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }

        #endregion
    }
}