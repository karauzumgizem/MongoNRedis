using FarmasiCase.Shared.Data.Abstract;
using System.Data;
using System.Data.SqlClient;

namespace FarmasiCase.Shared.Data.Concrete.Ado
{
    public class AdoRepositoryBase : IAdoRepository
    {
        private readonly SqlConnection _sqlConnection;
        public AdoRepositoryBase(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public DataSet GetDataSet(string query, SqlParameter[]? sqlParameters, CommandType sqlCommandType = CommandType.Text)
        {
            SqlCommand sqlcommand = new SqlCommand(query, _sqlConnection);
            sqlcommand.CommandType = sqlCommandType;
            if(sqlParameters != null)
            {
                sqlcommand.Parameters.AddRange(sqlParameters);
            }            
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);
            var ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            sqlDataAdapter.Dispose();
            sqlcommand.Dispose();
            _sqlConnection.Close();
            return ds;
        }

    }
}
