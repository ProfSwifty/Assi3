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
