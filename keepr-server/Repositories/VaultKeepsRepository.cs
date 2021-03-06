using System.Data;
using Dapper;
using keepr_server.Models;

namespace keepr_server.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal VaultKeep Create(VaultKeep newVK)
        {
            string sql = @"UPDATE keeps k SET k.keeps = k.keeps + 1 WHERE id = @KeepId;
      INSERT INTO vaultkeeps 
      (keepId, vaultId, creatorId) 
      VALUES 
      (@KeepId, @VaultId, @CreatorId);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newVK);
            newVK.Id = id;
            return newVK;
        }

        internal int Delete(int id, string userId)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @id AND creatorId = @userId LIMIT 1;";
            return _db.Execute(sql, new { id, userId });

        }
    }
}