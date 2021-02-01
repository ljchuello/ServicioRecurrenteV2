using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace VisualV12.Libreria
{
    public class OdbcSql
    {
        //private readonly OdbcConnection _dbConnection;
        //private readonly OdbcCommand _dbCommand;
        private const string ConnectionString = "DSN=odbc_sqlfac;Uid=sa;Pwd=Sermatick3000;";

        public List<string> Select_Top25_NoAutorizado()
        {
            List<string> source = new List<string>();

            try
            {
                using (OdbcConnection sqlConnection = new OdbcConnection(ConnectionString))
                {
                    OdbcCommand odbcCommand = new OdbcCommand();
                    sqlConnection.Open();
                    odbcCommand.Connection = sqlConnection;
                    odbcCommand.CommandText = "SELECT db.id FROM dbo.DocumentosBase db" +
                                              "\nWHERE db.estadoId IN(11, 12, 14, 15, 18)" +
                                              "\nORDER BY db.fechaEmision";
                    OdbcDataReader dbReader = odbcCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        source.Add($"{dbReader["id"]}");
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return source;
        }

        public Dictionary<string, string> Select_Top25_NoMail()
        {
            Dictionary<string, string> source = new Dictionary<string, string>();

            try
            {
                using (OdbcConnection odbcConnection = new OdbcConnection(ConnectionString))
                {
                    OdbcCommand odbcCommand = new OdbcCommand();
                    odbcConnection.Open();
                    odbcCommand.Connection = odbcConnection;
                    odbcCommand.CommandText = "SELECT db.id, db.emailCliente FROM dbo.DocumentosBase db" +
                                              "\nWHERE id NOT IN(SELECT he.docBaseId FROM dbo.HistorialesEmail he) AND" +
                                              "\ndb.FechaEmision > DATEADD(DAY, -30, GETDATE()) AND EstadoId = 17" +
                                              "\nORDER BY db.fechaEmision DESC";
                    OdbcDataReader dbReader = odbcCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        source.Add($"{dbReader["id"]}", $"{dbReader["emailCliente"]}");
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return source;
        }

    }
}