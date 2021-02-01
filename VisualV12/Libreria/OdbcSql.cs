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

        public int Select_Count_NoMail()
        {
            int cantidad = 0;

            try
            {
                using (OdbcConnection odbcConnection = new OdbcConnection(ConnectionString))
                {
                    OdbcCommand odbcCommand = new OdbcCommand();
                    odbcConnection.Open();
                    odbcCommand.Connection = odbcConnection;
                    odbcCommand.CommandText = "SELECT COUNT(db.id) AS 'Cantidad' FROM dbo.DocumentosBase db" +
                                              "\nWHERE id NOT IN(SELECT he.docBaseId FROM dbo.HistorialesEmail he) AND" +
                                              "\ndb.FechaEmision > DATEADD(DAY, -30, GETDATE()) AND EstadoId = 17";
                    OdbcDataReader dbReader = odbcCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        //source.Add($"{dbReader["id"]}", $"{dbReader["emailCliente"]}");
                        cantidad = Convert.ToInt32(dbReader["Cantidad"]);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return cantidad;
        }

        public Dictionary<string, string> Select_Resumen()
        {
            Dictionary<string, string> source = new Dictionary<string, string>();

            try
            {
                using (OdbcConnection odbcConnection = new OdbcConnection(ConnectionString))
                {
                    OdbcCommand odbcCommand = new OdbcCommand();
                    odbcConnection.Open();
                    odbcCommand.Connection = odbcConnection;
                    odbcCommand.CommandText = "SELECT e.titulo as Tipo, count(d.id) as 'Cantidad' FROM Estados e LEFT JOIN DocumentosBase d ON e.id=d.estadoid GROUP BY e.titulo HAVING COUNT(d.id) > 0 OR e.titulo = 'SIN ENVIAR'";
                    OdbcDataReader dbReader = odbcCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        source.Add($"{dbReader["Tipo"]}", $"{dbReader["Cantidad"]}");
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