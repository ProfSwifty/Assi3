/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 * Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

using System;

namespace Assi3
{
    //AddRoute class, inherits Route. Implements the "/add" request, which adds 8 to the inputted int
    class AddRoute : Route
    {
        //Addroute constructor, reuses the base Route constructor
        public AddRoute(string path, Route next = null) : base(path, next) { }

        //HandleRequest override method, returns the int payload + 8,
        //otherwise uses the base implementation of HandleRequest.
        public override int HandleRequest(int payload)
        {
            return Path == "/add" ? payload + 8 : base.HandleRequest(payload);
        }
    }
}
