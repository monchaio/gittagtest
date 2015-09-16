using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CryptoDemo {
  public class CryptAES {
    private static byte[] key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 44, 27, 162, 37, 112, 221, 109, 
                                  241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 23, 239 };

    private static byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 222, 212, 79, 3, 114, 156 };
    private static ICryptoTransform encryptor, decryptor;
    //private UTF8Encoding encoder;

    static CryptAES() {
      RijndaelManaged rm = new RijndaelManaged();
      encryptor = rm.CreateEncryptor(key, vector);
      decryptor = rm.CreateDecryptor(key, vector);
    }

    public static string Encrypt(string unencrypted) {
      return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(unencrypted)));
    }

    public static string Decrypt(string encrypted) {
      return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(encrypted)));
    }

    public static byte[] Encrypt(byte[] buffer) {
      return Transform(buffer, encryptor);
    }

    public static byte[] Decrypt(byte[] buffer) {
      return Transform(buffer, decryptor);
    }

    protected static byte[] Transform(byte[] buffer, ICryptoTransform transform) {
      MemoryStream stream = new MemoryStream();
      using( CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write) ) {
        cs.Write(buffer, 0, buffer.Length);
      }
      return stream.ToArray();
    }
  }
}
