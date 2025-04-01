/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 * Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

using System;

namespace Assi3
{
    class AddRoute : Route
    {
        public AddRoute(string path, Route next = null) : base(path, next) { }
        public override int HandleRequest(int payload)
        {
            return Path == "/add" ? payload + 8 : base.HandleRequest(payload);
        }
    }
}
