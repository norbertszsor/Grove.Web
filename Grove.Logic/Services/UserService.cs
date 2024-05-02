using Grove.Logic.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grove.Logic.Services
{
    public class UserService : IUserService
    {
        private bool _isAuthorized = false;

        // TODO - move to appsetings
        private readonly string _username = "admin123";
        private readonly string _password = "password123";

        public async Task<bool> LogIn(string username, string password)
        {
            if (username == _username && password == _password)
            {
                _isAuthorized = true;
                return true;
            }

            return false;
        }

        public async Task<bool> IsAuthorized() { return _isAuthorized; }
    }
}
