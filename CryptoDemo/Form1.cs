using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoDemo {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      // CryptRijndaelManaged

      string sourceText = "Hello World this text for testing encrypt and decrypt 555555555555555555555555555555555555555555555555555.";
      //string sourceText = "q0FXVur4Sot8cLiQ2BuldT43xLzjDkYPzBToOJVDOR+SIKhNuNoNSJi3qu+GPGS/"
      //string sourceText = "Hello World this text for testing encrypt and decrypt.";
      string encryptText = "";
      string decryptText = "";

      //encryptText = CryptRijndaelManaged.Encrypt(sourceText);
      //decryptText = CryptRijndaelManaged.Decrypt(encryptText);
      //if( sourceText != decryptText ) {
      //  MessageBox.Show("Cryption process failed.");
      //}

      //encryptText = CryptAESManaged.Encrypt(sourceText);
      //decryptText = CryptAESManaged.Decrypt(encryptText);
      //if( sourceText != decryptText ) {
      //  MessageBox.Show("Cryption process failed.");
      //}

      //encryptText = CryptAES.Encrypt(sourceText);
      //decryptText = CryptAES.Decrypt(encryptText);
      //if( sourceText != decryptText ) {
      //  MessageBox.Show("Cryption process failed.");
      //}

      decryptText = CryptAES.Decrypt("q0FXVur4Sot8cLiQ2BuldT43xLzjDkYPzBToOJVDOR+SIKhNuNoNSJi3qu+GPGS/");

      MessageBox.Show("OK");
    }
  }
}
