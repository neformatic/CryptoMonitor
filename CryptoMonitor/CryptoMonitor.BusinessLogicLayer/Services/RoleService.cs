using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public string GetRole(int id)
        {
            var role = _roleRepository.GetRole(id);
            return role;
        }
    }
}
