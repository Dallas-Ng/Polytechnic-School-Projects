using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FLYTA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFLYTA_WS" in both code and config file together.
    [ServiceContract]
    public interface IFLYTA_WS
    {
        [OperationContract]
        DataSet getProgrammes();

        [OperationContract]
        DataSet getAvailableProgrammes();

        [OperationContract]
        int incrementSeats(int Id);
    }
}
