using FLYTA.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FLYTA.BLL
{
    public class ProgrammesBLL
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