using System;
using System.Collections.Generic;

namespace Assi3
{
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
                switch (args[0])
                {
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

                    case "createserver":
                        Servers.Add(new Server());
                        Console.WriteLine("Server created.");
                        break;

                    case "deleteserver":
                        if (int.TryParse(args[1], out int delId) && delId < Servers.Count)
                        {
                            Servers.RemoveAt(delId);
                            Console.WriteLine("Server deleted.");
                        }
                        else
                            Console.WriteLine("Invalid server ID.");
                        break;

                    case "listservers":
                        for (int i = 0; i < Servers.Count; i++)
                            Console.WriteLine($"Server {i}");
                        break;

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
                        Console.WriteLine("Request added.");
                        break;

                    case "dispatch":
                        ServerQuery query = new ServerQuery();
                        foreach (var server in Servers)
                        {
                            if (!query.Visit(server) && PendingRequests.Count > 0)
                            {
                                server.ReceiveRequest(PendingRequests.Dequeue());
                                Console.WriteLine("Request dispatched.");
                                break;
                            }
                        }
                        break;

                    case "server":
                        if (int.TryParse(args[1], out int servId) && servId < Servers.Count)
                        {
                            Servers[servId].HandleRequest();
                        }
                        else
                            Console.WriteLine("Invalid server ID.");
                        break;

                    default:
                        if (command != "")
                        {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                }
            }
        }
    }
}
