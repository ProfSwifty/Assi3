/*
 * Name: Logan McCallum Student Number: 1152955 Section: 2
 * Name: Spencer Martin Student Number: 1040415 Section: 2
 * Name: Ashley Burley-Denis Student Number: 0908968 Section: 1
 */

using System;
using System.Collections.Generic;

namespace Assi3
{
    //Program class, main method.
    class Program
    {
        static List<Server> Servers = new List<Server>();
        static Queue<Request> PendingRequests = new Queue<Request>();

        static void Main()
        {
            Console.WriteLine("Please enter a command.");
            string command;
            while ((command = Console.ReadLine()) != "quit")
            {
                string[] args = command.Split(":");
                Console.WriteLine();

                switch (args[0])
                {
                    //displays help
                    case "help":
                        Console.WriteLine("help\t\t\tDisplay this menu");
                        Console.WriteLine("createserver\t\tCreate a new server.");
                        Console.WriteLine("deleteserver:[id]\tDelete server #ID.");
                        Console.WriteLine("listservers\t\tList all servers.");
                        Console.WriteLine("new:[path]:[payload]\tCreate a new pending request.");
                        Console.WriteLine("dispatch\t\tSend a pending request to a server.");
                        Console.WriteLine("server:[id]\t\tHave server #ID execute its pending request and print the result.");
                        Console.WriteLine("quit\t\t\tQuit the application");
                        break;

                    //creates a new server
                    case "createserver":
                        Servers.Add(new Server());
                        Console.WriteLine($"Created server {Servers.Count - 1}.");
                        break;

                    //deletes a server
                    case "deleteserver":
                        if (int.TryParse(args[1], out int delId) && delId < Servers.Count)
                        {
                            Servers.RemoveAt(delId);
                            Console.WriteLine($"Deleted server {delId}.");
                        }
                        else
                            Console.WriteLine("Invalid server ID.");
                        break;

                    //lists all servers stored in local memory
                    case "listservers":
                        if (Servers.Count == 0)
                        {
                            Console.WriteLine("No servers available.");
                        }
                        else
                        {
                            for (int i = 0; i < Servers.Count; i++)
                                Console.WriteLine($"{i} Server");
                        }
                        break;


                    //creates a new request to be pushed onto the server.
                    case "new":
                        if (args.Length < 3 || !int.TryParse(args[2], out int payload))
                        {
                            Console.WriteLine("Invalid request format.");
                            break;
                        }
                        PendingRequests.Enqueue(new Request(args[1], payload,
                            new MultiplyRoute("/mul",
                                new Multiply4Route("/mul/4",
                                    new AddRoute("/add")))));
                        Console.WriteLine($"Created request with data {payload} going to {args[1]}.");
                        break;

                    //dispatches a request to a server
                    case "dispatch":
                        if (PendingRequests.Count == 0)
                        {
                            Console.WriteLine("No pending requests.");
                            break;
                        }

                        ServerQuery query = new ServerQuery();
                        for (int i = 0; i < Servers.Count; i++)
                        {
                            if (!query.Visit(Servers[i]) && PendingRequests.Count > 0)
                            {
                                Servers[i].ReceiveRequest(PendingRequests.Dequeue());
                                Console.WriteLine($"Request dispatched to Server {i}.");
                                break;
                            }
                        }
                        break;


                    //displays the results of the requests of a server
                    case "server":
                        if (int.TryParse(args[1], out int servId) && servId < Servers.Count)
                        {
                            var result = Servers[servId].HandleRequest();
                            if (result == null)
                            {
                                Console.WriteLine("No work to do.");
                            }
                            else
                            {
                                Console.WriteLine($"Path: {result.Route}\nInput: {result.Payload}\nResult: {result.Execute()}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid server ID.");
                        }
                        break;



                    //default output if no case matches.
                    default:
                        if (command != "")
                        {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}