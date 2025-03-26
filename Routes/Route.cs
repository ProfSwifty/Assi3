using System;

namespace Assi3
{
    class Route
    {
        private Route Next;
        private string Path;

        public Route(string path, Route next = null) {
            this.Path = path;
            this.Next = next;
        }
    }
}
