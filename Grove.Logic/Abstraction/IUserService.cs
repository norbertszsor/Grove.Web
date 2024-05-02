using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grove.Logic.Abstraction
{
    public interface IUserService
    {
        Task<bool> LogIn(string username, string password);
        Task<bool> IsAuthorized();
    }
}
