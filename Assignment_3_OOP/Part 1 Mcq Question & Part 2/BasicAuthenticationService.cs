using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_1_Mcq_Question___Part_2
{
    internal class BasicAuthenticationService : IAuthenticationService
    {
        public Dictionary<string, string> usernameAndPassword = new Dictionary<string, string>()
        {
            {"admin","123"},
            {"accounter","54875" },
            {"hr","123"},
            {"mentor","12345"},
            {"instructor","456"}
        };
        public Dictionary<string, string> usernameAndRole = new Dictionary<string, string>()
        {
            {"admin","it"},
            {"accounter","financial" },
            {"hr","human resources"},
            {"mentor","web development"},
            {"instructor","web development"}
        };
        public bool AuthenticateUser(string username, string password)
        {
            if (usernameAndPassword.ContainsKey(username))
            {
                if (usernameAndPassword[username] == password)
                    return true;
            }
            return false;
        }

        public bool AuthorizeUser(string username, string role)
        {
            if (usernameAndRole.ContainsKey(username))
            {
                if (usernameAndRole[username] == role)
                    return true;
            }
            return false;
        }
    }
}
