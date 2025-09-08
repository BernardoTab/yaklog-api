using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YakLog.DataTransferring.Responses;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public UserScopeInfo User { get; set; } = new UserScopeInfo();
}