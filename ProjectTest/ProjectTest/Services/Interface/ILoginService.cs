using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTest.Model;

namespace ProjectTest.Services.Interface
{
    public interface ILoginService
    {
        public LoginModel Login(InputLoginModel inputModel);
    }
}
