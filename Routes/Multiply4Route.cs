/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 * Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

using System;

namespace Assi3
{
    class Multiply4Route : Route
    {
        public Multiply4Route(string path, Route next = null) : base(path, next) { }
        public override int HandleRequest(int payload)
        {
            return Path == "/mul/4" ? payload * 4 : base.HandleRequest(payload);
        }
    }
}
