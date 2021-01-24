using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace VisualV12.Libreria
{
    public class OdbcSql
    {
        private readonly OdbcConnection _dbConnection;
        private readonly OdbcCommand _dbCommand;
        private const string ConnectionString = "DSN=odbc_sqlfac;Uid=sa;Pwd=Sermatick3000;";

        public OdbcSql()
        {
            _dbConnection = new OdbcConnection(ConnectionString);
            _dbCommand = _dbConnection.CreateCommand();
        }

        public List<string> Select_Top25_NoAutorizado()
        {
            List<string> source = new List<string>();

            try
            {
                _dbConnection.Open();
                _dbCommand.CommandText = "SELECT db.id FROM dbo.DocumentosBase db" +
                                         "\nWHERE db.estadoId IN(11, 12, 14, 15, 18)" +
                                         "\nORDER BY db.fechaEmision";
                OdbcDataReader dbReader = _dbCommand.ExecuteReader();
                while (dbReader.Read())
                {
                    source.Add($"{dbReader["id"]}");
                }
                dbReader.Close();
            }
            catch (Exception ex)
            {

            }

            _dbConnection.Dispose();
            _dbCommand.Dispose();

            return source;
        }

        public List<string> Select_Top25_NoMail()
        {
            List<string> source = new List<string>();

            try
            {
                _dbConnection.Open();
                _dbCommand.CommandText = "SELECT TOP 10 db.id FROM dbo.DocumentosBase db" +
                                         "\nWHERE db.id NOT IN(SELECT he.docBaseId FROM dbo.HistorialesEmail he) AND" +
                                         "\ndb.fechaEmision > DATEADD(DAY, -30, GETDATE()) AND" +
                                         "\ndb.estadoId = 17 ORDER BY db.fechaEmision DESC";
                OdbcDataReader dbReader = _dbCommand.ExecuteReader();
                while (dbReader.Read())
                {
                    source.Add($"{dbReader["id"]}");
                }
                dbReader.Close();
            }
            catch (Exception ex)
            {

            }

            _dbConnection.Dispose();
            _dbCommand.Dispose();

            return source;
        }

    }
}