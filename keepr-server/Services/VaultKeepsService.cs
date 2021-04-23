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



        internal void Delete(int id, string userId)
        {
            // var data = _vkrepo.GetById(id);
            // if (data == null)
            // {

            //     throw new Exception("Invalid Id");
            // }
            // if (data.CreatorId != userId)
            // {

            //     throw new Exception("You're not the owner.");
            // }
            int affected = _vkrepo.Delete(id, userId);
            if (affected < 1)
            {
                throw new Exception("You're not the owner.");
            }
        }
    }
}