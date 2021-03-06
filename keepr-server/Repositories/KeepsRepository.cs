using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr_server.Models;

namespace keepr_server.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;
        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }


        internal IEnumerable<Keep> GetAll()
        {
            string sql = @"
      SELECT 
      k.*,
      prof.*
      FROM keeps k
      JOIN profiles prof ON k.creatorId = prof.id";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }, splitOn: "id");
        }

        internal Keep GetById(int id)
        {
            string sql = @" 
      SELECT 
      k.*,
      prof.*
      FROM keeps k
      JOIN profiles prof ON k.creatorId = prof.id
      WHERE k.id = @id";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }, new { id }, splitOn: "id").FirstOrDefault();
        }

        internal Keep Create(Keep newKeep)
        {
            string sql = @"
      INSERT INTO keeps 
      (name, description, img, views, shares, keeps, creatorId) 
      VALUES 
      (@Name, @Description, @Img, @Views, @Shares, @Keeps, @CreatorId);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newKeep);
            newKeep.Id = id;
            return newKeep;
        }

        internal Keep Edit(Keep updated)
        {
            string sql = @"
        UPDATE keeps
        SET
         name = @Name,
         description = @Description,
         img = @Img,
         views = @Views,
         shares = @Shares,
         keeps = @Keeps
        WHERE id = @Id;";
            _db.Execute(sql, updated);
            return updated;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }


        internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
        {
            string sql = @"SELECT 
          k.*,
          vk.id AS VaultKeepId,
          prof.*
          FROM vaultkeeps vk
          JOIN keeps k ON k.id = vk.keepId
          JOIN profiles prof ON vk.creatorId = prof.id
          WHERE vk.vaultId = @id;";
            // return _db.Query<VaultKeepViewModel>(sql, new { id });
            return _db.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql, (keep, profile) =>
           {
               keep.Creator = profile;
               return keep;
           }, new { id }, splitOn: "id");
        }

        internal List<Keep> GetByProfileId(string id)
        {
            string sql = @"
      SELECT 
      keep.*,
      profile.*
      FROM keeps keep
      JOIN profiles profile ON keep.creatorId = profile.id
      WHERE keep.creatorId = @id;";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }, new { id }, splitOn: "id").ToList();
        }
        internal IEnumerable<Keep> GetByCreatorId(string id)
        {
            string sql = @"
      SELECT 
      keep.*,
      profile.*
      FROM keeps keep
      JOIN profiles profile ON keep.creatorId = profile.id
      WHERE keep.creatorId = @id;";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }, new { id }, splitOn: "id");
        }

    }
}