using System;

namespace Assi3
{
    class Request : Command
    {
        public string Route { get; }
        public int Payload { get; }
        private Route Handler;

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
