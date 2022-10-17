using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModListWithDataBase
{
    class DataBaseFunctions
    {
        public SqlConnection cnn; 
        public void ConnectToDb(string ConnectionString)
        {
            cnn = new SqlConnection(ConnectionString);
            cnn.Open();
        }
        public void DisconnectFromDb()
        {
            cnn.Close();
        }
        public void AddToDb(int ModNum, int ModTav, int TsStartTime, int TsEndTime, int TsWriteTime, DateTime StartTime, DateTime EndTime, DateTime WriteTime)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "INSERT INTO " + Globals.Unit + 
            " ([MOD Number], [MOD Tav], [Timestamp Start Time], [Timestamp End Time], [TimeStamp Write Time], [Start Time], [End Time], [Write Time])" +
            " VALUES(" + ModNum + "," + ModTav + "," + TsStartTime + "," + TsEndTime + "," + TsWriteTime + ", '" + StartTime + "' , '" + EndTime + "' , '" + WriteTime + "')";
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
        }
    }
}
