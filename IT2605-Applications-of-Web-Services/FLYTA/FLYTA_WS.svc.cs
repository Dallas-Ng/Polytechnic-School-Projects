using FLYTA.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FLYTA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FLYTA_WS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FLYTA_WS.svc or FLYTA_WS.svc.cs at the Solution Explorer and start debugging.
    public class FLYTA_WS : IFLYTA_WS
    {
        ProgrammesModel prog = new ProgrammesModel();

        public DataSet getProgrammes()
        {
            return prog.getAllProgrammes();
        }
        public DataSet getAvailableProgrammes()
        {
            return prog.getAllAvailableProgrammes();
        }

        public int incrementSeats(int Id)
        {
            return prog.IncrementSeat(Id);
        }
    }
}
