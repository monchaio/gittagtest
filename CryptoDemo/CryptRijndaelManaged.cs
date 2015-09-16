using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace CryptoDemo {
  public class CryptRijndaelManaged {

    private static byte[] key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 44, 27, 162, 37, 112, 221, 109, 
                                  241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 23, 239 };

    private static byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 222, 212, 79, 3, 114, 156 };
    private static ICryptoTransform encryptor, decryptor;

    static CryptRijndaelManaged() {
      RijndaelManaged rm = new RijndaelManaged();
      encryptor = rm.CreateEncryptor(key, vector);
      decryptor = rm.CreateDecryptor(key, vector);
    }

    public static string Encrypt(string unencrypted) {
      return Convert.ToBase64String(EncryptStringToBytes(unencrypted));
    }

    public static string Decrypt(string encrypted) {
      return DecryptStringFromBytes(Convert.FromBase64String(encrypted));
    }

    protected static byte[] EncryptStringToBytes(string plainText) {
      RijndaelManaged rm = new RijndaelManaged();
      encryptor = rm.CreateEncryptor(key, vector);
      byte[] encrypted;

      // Create the streams used for encryption. 
      using( MemoryStream msEncrypt = new MemoryStream() ) {
        using( CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write) ) {
          using( StreamWriter swEncrypt = new StreamWriter(csEncrypt) ) {

            //Write all data to the stream.
            swEncrypt.Write(plainText);
          }
          encrypted = msEncrypt.ToArray();
        }
      }

      // Return the encrypted bytes from the memory stream. 
      return encrypted;
    }

    protected static string DecryptStringFromBytes(byte[] cipherText) {
      RijndaelManaged rm = new RijndaelManaged();
      decryptor = rm.CreateDecryptor(key, vector);
      // Declare the string used to hold 
      // the decrypted text. 
      string plaintext = null;

      // Create the streams used for decryption. 
      using( MemoryStream msDecrypt = new MemoryStream(cipherText) ) {
        using( CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read) ) {
          using( StreamReader srDecrypt = new StreamReader(csDecrypt) ) {

            // Read the decrypted bytes from the decrypting stream 
            // and place them in a string.
            plaintext = srDecrypt.ReadToEnd();
          }
        }
      }

      return plaintext;
    }
  }
}
