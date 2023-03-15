using OFOP.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFOP.Core
{
    public interface ILoginService
    {
        bool Login(LoginViewModel user);
    }
}
