using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BlacklistManager : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new BlacklistObj();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            BlacklistObj blacklist = entity as BlacklistObj;
            blacklist.Id = int.Parse(reader["Id"].ToString());
            blacklist.SourceIp = reader["SourceIp"].ToString();
            blacklist.Reason = reader["Reason"].ToString();
            blacklist.BlockedAt = DateTime.Parse(reader["BlockedAt"].ToString());

            return blacklist;
        }

        public Blacklist SelectAll()
        {
            command.CommandText = "SELECT * FROM BlacklistTable";
            return new Blacklist(base.ExecuteCommand());
        }

        public int Insert(BlacklistObj blacklist)
        {
            command.Parameters.Clear();
            command.CommandText = @"INSERT INTO BlacklistTable 
                                    (SourceIp, Reason, BlockedAt) 
                                    VALUES 
                                    (@SourceIp, @Reason, @BlockedAt);
                                    SELECT SCOPE_IDENTITY();";

            command.Parameters.AddWithValue("@SourceIp", blacklist.SourceIp);
            command.Parameters.AddWithValue("@Reason", blacklist.Reason);
            command.Parameters.AddWithValue("@BlockedAt", blacklist.BlockedAt);

            return Convert.ToInt32(base.ExecuteScalar());
        }

        public int Update(BlacklistObj blacklist)
        {
            command.Parameters.Clear();
            command.CommandText = @"UPDATE BlacklistTable 
                                    SET SourceIp = @SourceIp,
                                        Reason = @Reason,
                                        BlockedAt = @BlockedAt
                                    WHERE Id = @Id";

            command.Parameters.AddWithValue("@Id", blacklist.Id);
            command.Parameters.AddWithValue("@SourceIp", blacklist.SourceIp);
            command.Parameters.AddWithValue("@Reason", blacklist.Reason);
            command.Parameters.AddWithValue("@BlockedAt", blacklist.BlockedAt);

            return base.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            command.Parameters.Clear();
            command.CommandText = "DELETE FROM BlacklistTable WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
            return base.ExecuteNonQuery();
        }
    }
}
