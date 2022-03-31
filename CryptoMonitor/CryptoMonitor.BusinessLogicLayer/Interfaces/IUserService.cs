using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.Interfaces
{
    public interface IUserService
    {
        int GetUserId(string login);
    }
}
