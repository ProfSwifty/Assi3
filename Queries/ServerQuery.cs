/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 * Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

using System;

namespace Assi3
{
    //ServerQuery class, inherits Query
    //implements Visit method using Server class objects/methods 
    class ServerQuery : Query
    {
        public bool Visit(Server server)
        {
            return server.HasPendingRequests();
        }
    }
}
