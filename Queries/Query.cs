/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 * Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

using System;

namespace Assi3
{
    //Query interface, holds base definition of Visit method to be used in ServerQuery Class
    interface Query
    {
        bool Visit(Server server);
    }
}
