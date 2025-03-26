using System;

namespace Assi3
{
    class MultiplyRoute : Route
    {
        public MultiplyRoute(string path, Route next = null) : base(path, next) { }
        public override int HandleRequest(int payload)
        {
            return Path == "/mul" ? payload * 2 : base.HandleRequest(payload);
        }
    }
}
