/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 * Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

using System;

namespace Assi3
{
    abstract class Route
    {
        protected Route Next;
        protected string Path;

        protected Route(string path, Route next = null)
        {
            Path = path;
            Next = next;
        }

        public virtual int HandleRequest(int payload)
        {
            return Next?.HandleRequest(payload) ?? 404;
        }
    }
}
