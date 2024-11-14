using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ReportManager : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Report();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Report report = entity as Report;
            report.Id = int.Parse(reader["Id"].ToString());
            report.Description = reader["Description"].ToString();
            report.CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString());

            return report;
        }

        public Reports SelectAll()
        {
            command.CommandText = "SELECT * FROM ReportTable";
            return new Reports(base.ExecuteCommand());
        }

        public int Insert(Report report)
        {
            command.Parameters.Clear();
            command.CommandText = @"INSERT INTO ReportTable 
                                    (Description, CreatedAt) 
                                    VALUES 
                                    (@Description, @CreatedAt);
                                    SELECT SCOPE_IDENTITY();";

            command.Parameters.AddWithValue("@Description", report.Description);
            command.Parameters.AddWithValue("@CreatedAt", report.CreatedAt);

            return Convert.ToInt32(base.ExecuteScalar());
        }

        public int Update(Report report)
        {
            command.Parameters.Clear();
            command.CommandText = @"UPDATE ReportTable 
                                    SET Description = @Description,
                                        CreatedAt = @CreatedAt
                                    WHERE Id = @Id";

            command.Parameters.AddWithValue("@Id", report.Id);
            command.Parameters.AddWithValue("@Description", report.Description);
            command.Parameters.AddWithValue("@CreatedAt", report.CreatedAt);

            return base.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            command.Parameters.Clear();
            command.CommandText = "DELETE FROM ReportTable WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
            return base.ExecuteNonQuery();
        }
    }
}
