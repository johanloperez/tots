using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.domain.layer.api.Contracts
{
    public interface IMicrosoftGraphService
    {
        Task<string> RequestAccessToken();
        Task<IEnumerable<UserDto>> RequestAccessToken(
    }
}
