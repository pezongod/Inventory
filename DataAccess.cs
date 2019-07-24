using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class DataAccess
    {
        private const string conString = "Server=(localdb)\\mssqllocaldb; Database=Inventory";

        //public List<Vara> GetAllVarorBrief()
        //{
        //    var sql = @"SELECT [Id], [Author], [Title]
        //                FROM BlogPost";

        //    using (SqlConnection connection = new SqlConnection(conString))
        //    using (SqlCommand command = new SqlCommand(sql, connection))
        //    {
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        var list = new List<Vara>();

        //        while (reader.Read())
        //        {
        //            var bp = new Vara
        //            {
        //                Id = reader.GetSqlInt32(0).Value,
        //                SubTypId = reader.GetSqlInt32(1).Value,
        //                Pris = reader.GetSqlInt32(2).Value
        //            };
        //            list.Add(bp);
        //        }

        //        return list;

        //    }
        //}

        //public Vara GetPostById(int postId)
        //{
        //    var sql = @"SELECT [Id], [Author], [Title]
        //                FROM BlogPost
        //                WHERE Id=@Id";

        //    using (SqlConnection connection = new SqlConnection(conString))
        //    using (SqlCommand command = new SqlCommand(sql, connection))
        //    {
        //        connection.Open();
        //        command.Parameters.Add(new SqlParameter("Id", postId));

        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            var bp = new Vara
        //            {
        //                Id = reader.GetSqlInt32(0).Value,
        //                SubTypId = reader.GetSqlInt32(1).Value,
        //                Pris = reader.GetSqlInt32(2).Value
        //            };
        //            return bp;

        //        }

        //        return null;

        //    }
        //}

        public void AddVara(Vara vara)
        {
            var sql = "INSERT INTO Vara(SubTypId, Beskrivning) VALUES(@SubTypId, @Beskrivning)";


            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("SubTypId", vara.SubTypId));
                command.Parameters.Add(new SqlParameter("Beskrivning", vara.Beskrivning));
                command.ExecuteNonQuery();
            }
        }

    }
}
