using System;

namespace Assi3
{
    class ServerQuery : Query
    {
        public bool Visit(Server server)
        {
            return server.HasPendingRequests();
        }
    }
}
