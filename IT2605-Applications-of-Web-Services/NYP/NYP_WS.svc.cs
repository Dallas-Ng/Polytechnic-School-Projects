using NYP.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NYP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NYP_WS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NYP_WS.svc or NYP_WS.svc.cs at the Solution Explorer and start debugging.
    public class NYP_WS : INYP_WS
    {
        public DataSet getStudents(int OSEP_ID)
        {
            StudentsBLL students = new StudentsBLL();
            return students.getStudents(OSEP_ID);
        }
    }
}
