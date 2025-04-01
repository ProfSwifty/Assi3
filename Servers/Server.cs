using System;
using System.Collections.Generic;

/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 * Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

namespace Assi3
{
    class Server : AbstractServer
    {
        private Queue<Request> pendingRequests = new Queue<Request>();
        private Route handlerChain;

        public Server()
        {
            handlerChain = new MultiplyRoute("/mul",
                new Multiply4Route("/mul/4",
                    new AddRoute("/add")));
        }

        public void ReceiveRequest(Request request)
        {
            pendingRequests.Enqueue(request);
        }

        public Request HandleRequest()
        {
            if (pendingRequests.Count > 0)
            {
                return pendingRequests.Dequeue();
            }
            return null;
        }



        public bool HasPendingRequests()
        {
            return pendingRequests.Count > 0;
        }
    }
}
