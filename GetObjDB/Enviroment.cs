using GetObjDB.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetObjDB
{
    internal class Enviroment
    {
        public Enviroment() { }
        private int id;
        private string name;
        private string branchName;
        private string applicationBD;
        private string securityBD;
        private string transportBD;
        private string type;
        private string connectionString;
                
        public int Id { get; set; }
        public string Name { get; set; }
        public string BranchName { get; set; }
        public string ApplicationBD { get; set; }
        public string SecurityBD { get; set; }
        public string TransportBD { get; set; }
        public string Type { get; set; }

        public DataTable FindEnviromenById(int id_enviroment)
        {
            DataTable result = new DataTable();
            string connectionString = Program.Configuration.GetConnectionString("BHToolsConnectionString");
            if (connectionString != null)
            {
                ConnectionDALC dbConnection = new ConnectionDALC(connectionString);

                SqlParameter[] parametes = new SqlParameter[]
                {
                    new SqlParameter("@ENV_NCODE", SqlDbType.Int){Value = id_enviroment}
                };

                result = dbConnection.ExecuteStoredProcedure("PROC_BH_ENVIROMENT",parametes);
            }
            return result;
        }
    }
}
