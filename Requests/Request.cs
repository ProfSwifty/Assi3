/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 * Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

using System;

namespace Assi3
{
    //Request Class, implements Command, Holds the request, route and payload
    //information to be passed to the Route type's HandleRequest method.
    class Request : Command
    {
        public string Route { get; }
        public int Payload { get; }
        private Route Handler;

        //Request constructor
        public Request(string route, int payload, Route handler)
        {
            Route = route;
            Payload = payload;
            Handler = handler;
        }

        public int Execute()
        {
            return Handler?.HandleRequest(Payload) ?? 404;
        }

    }
}
