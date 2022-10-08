using System.Data;
using System.Data.SqlClient;

namespace FarmasiCase.Shared.Data.Abstract
{
    public interface IAdoRepository
    {
        DataSet GetDataSet(string query, SqlParameter[]? sqlParameters, CommandType sqlCommandType = CommandType.Text);
    }
}
