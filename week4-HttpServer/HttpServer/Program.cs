﻿using System;
using System.Net;
using System.IO;


namespace HttpServer
{
    class Program
    {
        private static bool isRunning = true;
        static void Main(string[] args)
        {
            string url = "http://localhost:8888/google/";
            using (var server = new HttpServer(url))
            {
                server.Start();
                while (isRunning)
                    Handler(Console.ReadLine(), server);
            }
        }

        private static void Handler(string command, HttpServer server)
        {
            switch (command)
            {
                case "start":
                    server.Start();
                    break;
                case "restart":
                    server.Stop();
                    server.Start();
                    break;
                case "stop":
                    server.Stop();
                    break;
                case "exit":
                    isRunning = false;
                    break;
                default:
                    break;
            }
        }
    }
}
