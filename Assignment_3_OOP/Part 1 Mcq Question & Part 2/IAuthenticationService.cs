using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_1_Mcq_Question___Part_2
{
    internal interface IAuthenticationService
    {
            bool AuthenticateUser(string username, string password);
            bool AuthorizeUser(string username, string role);
    }
}
