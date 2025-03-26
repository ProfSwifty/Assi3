using System;

namespace Assi3
{
    interface AbstractServer
    {
        void HandleRequest();
        void ReceiveRequest(Request request);
        bool HasPendingRequests();
    }
}
