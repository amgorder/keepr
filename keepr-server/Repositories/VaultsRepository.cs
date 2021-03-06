using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr_server.Models;

namespace keepr_server.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }


        internal IEnumerable<Vault> GetAll()
        {
            string sql = @"
      SELECT 
      v.*,
      prof.*
      FROM vaults v
      JOIN profiles prof ON v.creatorId = prof.id";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, splitOn: "id");
        }
        //      1 SELECT 
        //      4 v.*,
        //      6 prof.*
        //      2 FROM vaults v
        //      5 JOIN profiles prof ON v.creatorId = prof.id
        //      3 WHERE v.id = @id";
        internal Vault GetById(int id)
        {
            string sql = @" 
      SELECT 
      v.*,
      prof.*
      FROM vaults v
      JOIN profiles prof ON v.creatorId = prof.id
      WHERE v.id = @id";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, new { id }, splitOn: "id").FirstOrDefault();
        }

        // internal Vault Create(Vault newVault)
        // {
        //     string sql = @"
        //   INSERT INTO vaults 
        //   (name, description, isPrivate, creatorId) 
        //   VALUES 
        //   (@Name, @Description, @IsPrivate, @CreatorId);
        //   SELECT LAST_INSERT_ID();";
        //     int id = _db.ExecuteScalar<int>(sql, newVault);
        //     newVault.Id = id;
        //     return newVault;
        // }

        internal int Create(Vault VaultData)
        {
            string sql = @"
          INSERT INTO vaults 
          (name, description, isPrivate, creatorId) 
          VALUES 
          (@Name, @Description, @IsPrivate, @CreatorId);
          SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, VaultData);
        }


        internal Vault Edit(Vault updated)
        {
            string sql = @"
        UPDATE vaults
        SET
         name = @Name,
         description = @Description,
         isPrivate = @IsPrivate
        WHERE id = @Id;";
            _db.Execute(sql, updated);
            return updated;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }



        internal List<Vault> GetByProfileId(string id)
        {
            string sql = @"
      SELECT 
      vault.*,
      profile.*
      FROM vaults vault
      JOIN profiles profile ON vault.creatorId = profile.id
      WHERE vault.creatorId = @id;";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, new { id }, splitOn: "id").ToList();
        }


        internal IEnumerable<Vault> GetByCreatorId(string id)
        {
            string sql = @"
      SELECT 
      vault.*,
      profile.*
      FROM vaults vault
      JOIN profiles profile ON vault.creatorId = profile.id
      WHERE vault.creatorId = @id;";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, new { id }, splitOn: "id");
        }
    }




}