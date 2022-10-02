using System.Net;
using System.Text;
using System.IO;
using System;


namespace HttpServer
{
    public class HttpServer : IDisposable
    {
        private readonly string url;
        private readonly HttpListener listener;
        private HttpListenerContext? context;
        private bool isRunning = false;

        public HttpServer(string url)
        {
            this.url = url;
            listener = new HttpListener();
            listener.Prefixes.Add(url);
        }

        public void Start()
        {
            Console.WriteLine("Запуск сервера...");
            listener.Start();
            Console.WriteLine("Сервер запущен");
            isRunning = true;
            Listening();
        }
        private void Listening()
        {
            listener.BeginGetContext(new AsyncCallback(Listen), listener);
        }

        public void Listen(IAsyncResult result)
        {
            if (listener.IsListening)
            {
                context = listener.EndGetContext(result);
                HttpListenerRequest request = context.Request;
                // получаем объект ответа
                HttpListenerResponse response = context.Response;
                // создаем ответ в виде кода html
                var path = Directory.GetCurrentDirectory();
                byte[] buffer;
                if (Directory.Exists("C:\\Users\\alsu2\\source\\repos\\HttpServer"))
                {
                    response.Headers.Set("Content-Type", "text/html");
                    buffer = File.ReadAllBytes("C:\\Users\\alsu2\\Desktop\\study\\hw\\google\\google.html");
                }
                else
                {
                    response.Headers.Set("Content-Type", "text/plain");
                    buffer = Encoding.UTF8.GetBytes("404 - Not Found");
                }
                // получаем поток ответа и пишем в него ответ
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // закрываем поток
                output.Close();
                Listening();
            }
        }
        public void Stop()
        {
            listener.Stop();
            Console.WriteLine("Сервер остановлен");
            isRunning = false;
        }

        public void Dispose()
        {
            Stop();
        }

        public void Restart()
        {
            Stop();
            Start();
        }
    }
}