using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace ViewModel
{
    public class NetworkManager : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Networks();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Networks network = entity as Networks;
            network.networkName = reader["NetworkName"].ToString();
            network.ipRange = reader["IpRange"].ToString();

            return network;
        }

        public NetworkList SelectAll()
        {
            command.CommandText = "SELECT * FROM Networks";
            NetworkList list = new NetworkList(base.ExecuteCommand());
            return list;
        }

        public int Insert(Networks network)
        {
            command.CommandText = "INSERT INTO Networks (NetworkName, IpRange) VALUES (@NetworkName, @IpRange)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@NetworkName", network.networkName);
            command.Parameters.AddWithValue("@IpRange", network.ipRange);

            return base.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            command.CommandText = "DELETE FROM Networks WHERE Id = @Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", id);
            return base.ExecuteNonQuery();
        }
    }
}
