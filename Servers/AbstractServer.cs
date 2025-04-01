/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 *  Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

using System;

namespace Assi3
{
    //AbstractServer Interface, Defines methods to be used within the server Class
    interface AbstractServer
    {
        Request HandleRequest();
        void ReceiveRequest(Request request);
        bool HasPendingRequests();
    }
}
