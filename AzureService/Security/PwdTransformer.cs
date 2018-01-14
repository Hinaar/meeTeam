using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AzureService.Security
{
    //TODO: slow hash(Rfc2898DeriveBytes) instead
    public class PwdTransformer
    {
        private static PwdTransformer instance;

        private PwdTransformer() { }

        public static PwdTransformer Instance
        {
            get
            {
                if (instance == null)
                    instance = new PwdTransformer();
                return instance;
            }
        }

        /// <summary>
        /// Creates salt and hash for password
        /// </summary>
        /// <param name="pwd">Input password</param>
        /// <returns>salt,hash</returns>
        public (byte[], byte[]) EncryptPass(string pwd) //tuple -> .item1 .item2
        {
            byte[] salt = generateSalt();
            byte[] pass = Encoding.UTF8.GetBytes(pwd);
            byte[] hash = Hash(pass, salt); 
            return (salt, hash);
        }

        public bool CheckPass(string pwd, byte[] salt, byte[] hash)
        {
            byte[] pass = Encoding.UTF8.GetBytes(pwd);
            byte[] pwHash = Hash(pass, salt);
            return pwHash.SequenceEqual(hash);
        }


        private byte[] Hash(byte[] val, byte[] salt)
        {
            byte[] salted = val.Concat(salt).ToArray();
            return new SHA256Managed().ComputeHash(salted);
        }

        private byte[] generateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[24];
            rng.GetBytes(salt);
            return salt;
        }

    }
}