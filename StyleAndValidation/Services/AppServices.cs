using StyleAndValidation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleAndValidation.Services
{
    public class AppServices
    {
        User loggedUser;
        List<User> users;
        public AppServices()
        {
            users = new List<User>();
            FillUsers();
        }
        public void FillUsers() 
        {
            users.Add(new User() { Email = "talsi@gmail.com", FullName = "Tal Simon", Password = "1234", Username = "talsi" });
        }

        public User GetLoggedUser()
        { 
            return loggedUser;
        }
        public async Task<bool> Login(string username, string password)
        {
            if (username == null || password == null)
                return false;
            loggedUser = null;
            loggedUser= users.FirstOrDefault(x=>x.Username == username&&x.Password==password);
            await Task.Delay(1000); 
            return loggedUser!= null;   
        }

        public async Task<bool> RegisterUserAsync(User u)
        {
            users.Add(u);
            await Task.Delay(3000);
            return true;    
        }

        public void Logout()
        {
            loggedUser = null;
        }
    }
}
