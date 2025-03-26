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
