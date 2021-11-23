//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Threading.Tasks;

//namespace EvoNaplo.Services
//{
//    public class PasswordService
//    {


        


//        public PasswordService()
//        {
            
//        }


//        /// <summary>
//        /// This method converts a string into a secure hash, using a crypto service, some rfc thing, and salt.
//        /// </summary>
//        /// <param name="password">the password you want to convert</param> 
//        /// <returns></returns>
//        public string HashPassword(string password)
//        {
            

//            //generating salt
//            byte[] salt;
//            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

//            //getting the hash
//            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
//            byte[] hash = pbkdf2.GetBytes(20);

//            //combining to a byte array
//            byte[] hashBytes = new byte[36];
//            Array.Copy(salt, 0, hashBytes, 0, 16);
//            Array.Copy(hash, 0, hashBytes, 16, 20);

//            //convert into a string
//            string passwordHash = Convert.ToBase64String(hashBytes);

            

//            return passwordHash;
//        }


//        /// <summary>
//        /// This method verifies if the input string matches the hashed one.
//        /// </summary>
//        /// <param name="password">the password you want tested</param>
//        /// <param name="passwordHash">the hash you want the password to be tested against</param>
//        /// <returns></returns>
//        public bool VerifyPassword(string password, string passwordHash)
//        {
            

//            //converting back to bytes
//            byte[] hashBytes = Convert.FromBase64String(passwordHash);

//            //getting the salt back
//            byte[] salt = new byte[16];
//            Array.Copy(hashBytes, 0, salt, 0, 16);

//            //getting the hash of the password
//            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
//            byte[] hash = pbkdf2.GetBytes(20);

//            //thank you internet, very cool
//            for (int i = 0; i < 20; i++)
//            {
//                if (hashBytes[i + 16] != hash[i])
//                {
                    
//                    return false;
//                }
//            }
            
//            return true;
//        }


//    }
//}
