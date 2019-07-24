using Inventory.Classer;
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

        public List<Typ> GetAllTyps()
        {
            var sql = "SELECT * FROM Typ";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Typ>();

                while (reader.Read())
                {
                    var bp = new Typ
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Namn = reader.GetSqlString(1).Value
                    };
                    list.Add(bp);
                }

                return list;

            }
        }

        public List<SubTyp> GetAllSubTyps(int typId)
        {
            var sql = "SELECT Namn FROM Subtyp WHERE TypID=@typId";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("typId", typId));

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<SubTyp>();

                while (reader.Read())
                {
                    var bp = new SubTyp
                    {
                        Namn = reader.GetSqlString(0).Value
                    };
                    list.Add(bp);
                }

                return list;

            }
        }

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
