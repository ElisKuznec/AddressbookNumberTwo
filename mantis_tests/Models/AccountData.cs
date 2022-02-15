using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class AccountData
    {
        private string username;
        private string password;
        public AccountData()
        {
            this.Username = username;
            this.Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Id { get; internal set; }
        public string Name { get; internal set; }
    }
}