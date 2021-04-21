using System;
using System.Collections.Generic;
using System.Linq;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;

        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Keep> GetAll()
        {
            return _repo.GetAll();
        }

        internal Keep GetById(int id)
        {
            var data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal Keep Create(Keep newKeep)
        {
            return _repo.Create(newKeep);
        }

        internal Keep Edit(Keep updated)
        {
            var original = GetById(updated.Id);
            if (original.CreatorId != updated.CreatorId)
            {
                throw new Exception("Invalid Edit Permissions");
            }
            updated.Name = updated.Name != null && updated.Name.Length > 2 ? updated.Name : original.Name;
            updated.Description = updated.Description != null ? updated.Description : original.Description;
            updated.Img = updated.Img != null ? updated.Img : original.Img;
            updated.Views = updated.Views;
            updated.Shares = updated.Shares;
            updated.Keeps = updated.Keeps;

            return _repo.Edit(updated);
        }


        internal string Delete(int id, string userId)
        {
            var original = GetById(id);
            if (original.CreatorId != userId)
            {
                throw new Exception("Invalid Delete Permissions");
            }
            _repo.Delete(id);
            return "Deleted";
        }

        internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
        {
            return _repo.GetKeepsByVaultId(id);
        }
        internal List<Keep> GetKeepsByProfileId(string id)
        {
            var keeps = _repo.GetByProfileId(id);
            return keeps;
        }

    }
}