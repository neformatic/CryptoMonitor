using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.DAL.Interfaces
{
    public interface IRoleRepository
    {
        string GetRole(int id);
    }
}
