using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PureCloud_simulator
{
    public class EncryptionHelper
    {

        /// 
        /// Chiffre une chaîne de caractère
        /// 
        /// Texte clair à chiffrer
        /// Clé de chiffrement
        /// Vecteur d'initialisation
        /// Retourne le texte chiffré
        public string EncryptString(string clearText, string strKey, string strIv)
        {

            // Place le texte à chiffrer dans un tableau d'octets
            byte[] plainText = Encoding.UTF8.GetBytes(clearText);

            // Place la clé de chiffrement dans un tableau d'octets
            byte[] key = Encoding.UTF8.GetBytes(strKey);

            // Place le vecteur d'initialisation dans un tableau d'octets
            byte[] iv = Encoding.UTF8.GetBytes(strIv);


            RijndaelManaged rijndael = new RijndaelManaged();

            // Définit le mode utilisé
            //rijndael.Mode = CipherMode.CBC;
            rijndael.Mode = CipherMode.ECB;

            //rijndael.Padding = PaddingMode.Zeros;

            // Crée le chiffreur AES - Rijndael
            ICryptoTransform aesEncryptor = rijndael.CreateEncryptor(key, iv);

            MemoryStream ms = new MemoryStream();

            // Ecris les données chiffrées dans le MemoryStream
            CryptoStream cs = new CryptoStream(ms, aesEncryptor, CryptoStreamMode.Write);
            cs.Write(plainText, 0, plainText.Length);
            cs.FlushFinalBlock();


            // Place les données chiffrées dans un tableau d'octet
            byte[] CipherBytes = ms.ToArray();


            ms.Close();
            cs.Close();

            // Place les données chiffrées dans une chaine encodée en Base64
            return Convert.ToBase64String(CipherBytes);


        }

        /// <summary>
        /// Déchiffre une chaîne de caractère
        /// </summary>
        /// <param name="cipherText">Texte chiffré</param>
        /// <param name="strKey">Clé de déchiffrement</param>
        /// <param name="strIv">Vecteur d'initialisation</param>
        /// <returns></returns>
        public string DecryptString(string cipherText, string strKey, string strIv)
        {

            // Place le texte à déchiffrer dans un tableau d'octets
            byte[] cipheredData = Convert.FromBase64String(cipherText);

            // Place la clé de déchiffrement dans un tableau d'octets
            byte[] key = Encoding.UTF8.GetBytes(strKey);

            // Place le vecteur d'initialisation dans un tableau d'octets
            byte[] iv = Encoding.UTF8.GetBytes(strIv);

            RijndaelManaged rijndael = new RijndaelManaged();
            //rijndael.Mode = CipherMode.CBC;
            rijndael.Mode = CipherMode.ECB;


            // Ecris les données déchiffrées dans le MemoryStream
            ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv);
            MemoryStream ms = new MemoryStream(cipheredData);
            CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);

            // Place les données déchiffrées dans un tableau d'octet
            byte[] plainTextData = new byte[cipheredData.Length];

            int decryptedByteCount = cs.Read(plainTextData, 0, plainTextData.Length);

            ms.Close();
            cs.Close();

            return Encoding.UTF8.GetString(plainTextData, 0, decryptedByteCount);

        }

    }

}
