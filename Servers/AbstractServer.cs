using System;

namespace Assi3
{
    interface AbstractServer
    {
        Request HandleRequest();
        void ReceiveRequest(Request request);
        bool HasPendingRequests();
    }
}
