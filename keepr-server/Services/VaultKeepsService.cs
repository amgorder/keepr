using System;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _vkrepo;

        public VaultKeepsService(VaultKeepsRepository vkrepo)
        {
            _vkrepo = vkrepo;
        }

        internal VaultKeep Create(VaultKeep newVK)
        {
            //TODO if they are creating a VaultKeep, make sure they are the creator of the list
            return _vkrepo.Create(newVK);

        }



        internal void Delete(int id)
        {
            //NOTE getbyid to validate its valid and you are the creator
            _vkrepo.Delete(id);
        }
    }
}