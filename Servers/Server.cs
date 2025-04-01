using System;
using System.Collections.Generic;

/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 * Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

namespace Assi3
{
    //Server class, inherits AbstractServer,
    //holds the server information and processes various requests.
    class Server : AbstractServer
    {
        private Queue<Request> pendingRequests = new Queue<Request>();
        private Route handlerChain;

        //Server constructor
        public Server()
        {
            handlerChain = new MultiplyRoute("/mul",
                new Multiply4Route("/mul/4",
                    new AddRoute("/add")));
        }

        //ReceiveRequest Method, takes in a request then
        //enqueues it to the server's pending requests.
        public void ReceiveRequest(Request request)
        {
            pendingRequests.Enqueue(request);
        }

        //HandleRequest method, called after a request
        //has been completed, dequeues the current request.
        public Request HandleRequest()
        {
            if (pendingRequests.Count > 0)
            {
                return pendingRequests.Dequeue();
            }
            return null;
        }


        //HasPendingReuqests method, returns true or false depending
        //on if the pendingRequests count is greater than 0.
        public bool HasPendingRequests()
        {
            return pendingRequests.Count > 0;
        }
    }
}
