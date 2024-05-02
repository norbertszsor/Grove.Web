using Grove.Logic.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grove.Logic
{
    public static class CustomAuthExtension
    {
        public static readonly Func<IServiceProvider, Task<bool>> customAuthFunctiion =
            new Func<IServiceProvider, Task<bool>>(x =>
                x.GetService<IUserService>().IsAuthorized());
    }
}
