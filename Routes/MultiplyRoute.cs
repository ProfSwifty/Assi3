/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 * Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

using System;

namespace Assi3
{
    //MultiplyRoute Class, inherits Route. Implements the "/mul" request,
    //which multiplies the inputted int by 2.
    class MultiplyRoute : Route
    {
        //MultiplyRoute constructor, reuses the base Route constructor
        public MultiplyRoute(string path, Route next = null) : base(path, next) { }

        //HandleRequest override method, returns the int payload * 2,
        //otherwise uses the base implementation of HandleRequest.
        public override int HandleRequest(int payload)
        {
            return Path == "/mul" ? payload * 2 : base.HandleRequest(payload);
        }
    }
}
