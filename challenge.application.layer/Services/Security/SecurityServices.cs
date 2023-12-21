using challenge.domain.layer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.application.layer.Services.Security
{
    public class SecurityServices : ISecurityServices
    {
        private readonly IMicrosoftGraphApiService _mgApiService;

        public SecurityServices(IMicrosoftGraphApiService mgApiService)
        {
            _mgApiService = mgApiService;
        }

        public async Task<string> GetToken(string code)
        {
            return await _mgApiService.RequestAccessToken(code);
        }
    }
}
