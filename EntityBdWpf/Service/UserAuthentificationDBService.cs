using EntityBdWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup.Localizer;

namespace EntityBdWpf.Service
{
    internal class UserAuthentificationDBService
    {
        public bool RegisterUser(string login, string password)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
               User  u = db.Users.FirstOrDefault(x => x.Login == login);
               if(u == null)
                {
                   db.Users.Add(new User() {Login=login, Password=CreateMD5(password)});
                   db.SaveChanges();
                }

            }

           
            return true;
        }
        public bool ValidateUser(string login, string password) 
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                User u = db.Users.FirstOrDefault(l=>l.Login==login);
                if(u != null)
                {
                    return ValidatePassword(login, password);
                }
                return false;
            }
            
        }
        private bool ValidatePassword(string originPassword, string passwordHash)
        {

            return CreateMD5(originPassword) == passwordHash; 
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
