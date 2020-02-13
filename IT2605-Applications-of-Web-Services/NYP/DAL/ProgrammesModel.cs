using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NYP.FLYTA_API;

namespace NYP.DAL
{
    public class ProgrammesModel
    {
        FLYTA_WSClient prog = new FLYTA_WSClient();
        SqlConnection CONNECTION = NYPSqlConn.GetConnection();

        public DataSet getProgrammes()
        {
            return prog.getAvailableProgrammes();
        }

        public int IncrementSeats(int id)
        {
            return prog.incrementSeats(id);
        }
    }
}