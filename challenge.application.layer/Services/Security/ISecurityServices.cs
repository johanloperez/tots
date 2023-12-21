using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.application.layer.Services.Security
{
    public interface ISecurityServices
    {
        Task<string> GetToken(string code);
    }
}
