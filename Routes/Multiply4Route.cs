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
