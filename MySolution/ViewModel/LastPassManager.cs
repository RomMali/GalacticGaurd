using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace ViewModel
{
    public class LastPassManager : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new LastPasses();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            LastPasses pass = entity as LastPasses;
            pass.user_id = Convert.ToInt32(reader["UserId"]);
            pass.accessTime = Convert.ToDateTime(reader["AccessTime"]);

            return pass;
        }

        public LastPassList SelectAll()
        {
            command.CommandText = "SELECT * FROM LastPasses";
            LastPassList list = new LastPassList(base.ExecuteCommand());
            return list;
        }

        public int Insert(LastPasses pass)
        {
            command.CommandText = "INSERT INTO LastPasses (UserId, AccessTime) VALUES (@UserId, @AccessTime)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@UserId", pass.user_id);
            command.Parameters.AddWithValue("@AccessTime", pass.accessTime);

            return base.ExecuteNonQuery();
        }
        
        public int Delete(int userId)
        {
            command.CommandText = "DELETE FROM LastPasses WHERE UserId = @UserId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@UserId", userId);
            return base.ExecuteNonQuery();
        }
    }
}
