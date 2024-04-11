using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreClient.Protocols
{
    interface IProtocol
    {
        Task Send(string json);
    }


}
