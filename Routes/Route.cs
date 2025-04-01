/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 * Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

using System;

namespace Assi3
{
    //Abstract Route class, holds the path and route information
    abstract class Route
    {
        protected Route Next;
        protected string Path;

        //Protected route constructor
        protected Route(string path, Route next = null)
        {
            Path = path;
            Next = next;
        }

        //HandleRequest method, base implementation to be
        //used on the different types of routes,
        //returns the payload after processing based on what route the payload was push on.
        public virtual int HandleRequest(int payload)
        {
            return Next?.HandleRequest(payload) ?? 404;
        }
    }
}
