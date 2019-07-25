using Inventory.Classer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Inventory
{
    public class DataAccess
    {
        private const string conString = "Server=(localdb)\\mssqllocaldb; Database=Inventory";

        public List<Vara> GetAllVaraOfTyp(int id)
        {
            var sql = @"SELECT Vara.Id, Vara.Beskrivning, Vara.Pris, Status.Namn, Vara.DatumInköpt, Typ.Id, Typ.Namn, Subtyp.Id, Subtyp.Namn, Vara.BildId
                        from Subtyp
                        join Vara on Subtyp.Id = Vara.SubTypId
                        join Typ on Subtyp.TypId = Typ.Id
                        join Status on Status.Id = Vara.StatusId
                        WHERE Typ.Id = @id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.Add(new SqlParameter("id", id));

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Vara>();

                while (reader.Read())
                {
                    var vara = new Vara
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Beskrivning = GetString(reader.GetSqlString(1)),
                        Pris = GetInt(reader.GetSqlInt32(2)),
                        StatusNamn = GetString(reader.GetSqlString(3)),
                        DatumInköpt = GetDateTime(reader.GetDateTime(4)),
                        TypId = reader.GetSqlInt32(5).Value,
                        TypNamn = reader.GetSqlString(6).Value,
                        SubTypId = reader.GetSqlInt32(7).Value,
                        SubTypNamn = reader.GetSqlString(8).Value,
                        BildId = GetInt(reader.GetSqlInt32(9))
                    };

                    list.Add(vara);
                }

                return list;
            }
        }

        private int? GetInt(SqlInt32 x)
        {
            if (x.IsNull)
            {
                return null;
            }
            else
            {
                return x.Value;
            }
        }
        private string GetString(SqlString x)
        {
            if (x.IsNull)
            {
                return null;
            }
            else
            {
                return x.Value;
            }
        }
        private DateTime? GetDateTime(SqlDateTime x)
        {
            if (x.IsNull)
            {
                return null;
            }
            else
            {
                return x.Value;
            }
        }

        public List<IEntity> GetAllTyps()
        {
            var sql = "SELECT * FROM Typ";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<IEntity>();

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

        public List<IEntity> GetAllSubTyps(int typId)
        {
            var sql = "SELECT Namn, Id FROM Subtyp WHERE TypID=@typId";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("typId", typId));

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<IEntity>();

                while (reader.Read())
                {
                    
                    var bp = new SubTyp
                    {
                        Namn = reader.GetSqlString(0).Value,
                        Id = reader.GetSqlInt32(1).Value
                    };
                    list.Add(bp);
                }

                return list;
            }
        }

        public List<IEntity> GetAllStatus()
        {
            var sql = "SELECT * FROM Status";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<IEntity>();

                while (reader.Read())
                {
                    var bp = new Status
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Namn = reader.GetSqlString(1).Value                       
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
            var sql = "INSERT INTO Vara(SubTypId, Pris, Beskrivning, BildId, DatumInköpt, StatusId) VALUES(@SubTypId, @Pris, @Beskrivning, @BildId, @DatumInköpt, @StatusId)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("SubTypId", vara.SubTypId));
                command.Parameters.Add(new SqlParameter("Pris", (object)vara.Pris ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("Beskrivning", (object)vara.Beskrivning ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("BildId", (object)vara.BildId ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("DatumInköpt", (object)vara.DatumInköpt ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("StatusId", (object)vara.StatusId ?? DBNull.Value));
                command.ExecuteNonQuery();

               
            }
        }

        //public void AddTyp(Vara vara)
        //{
        //    var sql = "INSERT INTO Typ(Id) VALUES(@BildId)";

        //    using (SqlConnection connection = new SqlConnection(conString))
        //    using (SqlCommand command = new SqlCommand(sql, connection))
        //    {
        //        connection.Open();
        //        command.Parameters.Add(new SqlParameter("BildId", vara.BildId));
        //        command.ExecuteNonQuery();
        //    }
        //}

        //public void AddSubTyp(Vara vara)
        //{
        //    var sql = "INSERT INTO Subtyp(Id) VALUES(@SubTypId)";

        //    using (SqlConnection connection = new SqlConnection(conString))
        //    using (SqlCommand command = new SqlCommand(sql, connection))
        //    {
        //        connection.Open();
        //        command.Parameters.Add(new SqlParameter("SubTypId", vara.SubTypId));
        //        command.ExecuteNonQuery();
        //    }
        //}
    }
}