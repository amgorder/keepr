using System;
using System.Collections.Generic;
using System.Linq;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Vault> GetAll()
        {
            return _repo.GetAll();
        }

        internal Vault GetById(int id, string userId)
        {
            var data = _repo.GetById(id);
            if (data == null)
            {

                throw new Exception("Invalid Id");
            }
            if (data.CreatorId != userId && data.IsPrivate)
            {

                throw new Exception("This is private and youre not the owner.");
            }
            return data;
        }

        public Vault Create(Vault newVault)
        {
            newVault.Id = _repo.Create(newVault);
            return newVault;
        }
        internal Vault Edit(Vault updated)
        {
            var original = GetById(updated.Id, updated.CreatorId);
            if (original.CreatorId != updated.CreatorId)
            {
                throw new Exception("Invalid Edit Permissions");
            }
            updated.Name = updated.Name != null ? updated.Name : original.Name;
            updated.Description = updated.Description != null ? updated.Description : original.Description;
            updated.IsPrivate = updated.IsPrivate;


            return _repo.Edit(updated);
        }


        internal string Delete(int id, string userId)
        {
            var original = GetById(id, userId);
            if (original.CreatorId != userId)
            {
                throw new Exception("Invalid Delete Permissions");
            }
            _repo.Delete(id);
            return "deleted";
        }

        internal List<Vault> GetVaultsByProfileId(string id)
        {
            var vaults = _repo.GetByProfileId(id);
            return vaults.FindAll(v => !v.IsPrivate);
        }

        internal IEnumerable<Vault> GetVaultsByAccountId(string id)
        {
            return _repo.GetByCreatorId(id);
        }

    }
}