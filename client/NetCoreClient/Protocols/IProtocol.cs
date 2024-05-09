using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreClient.Protocols
{
    interface IProtocol
    {
        Task Send(string data);
    }
}
