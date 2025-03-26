using System;
using System.Collections.Generic;

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

        public void HandleRequest()
        {
            if (pendingRequests.Count > 0)
            {
                Request req = pendingRequests.Dequeue();
                Console.WriteLine($"Response: {req.Execute()}");
            }
            else
            {
                Console.WriteLine("404");
            }
        }

        public bool HasPendingRequests()
        {
            return pendingRequests.Count > 0;
        }
    }

}
