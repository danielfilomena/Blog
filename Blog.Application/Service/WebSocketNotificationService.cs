using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace Blog.Application.Service
{
    public class WebSocketNotificationService : INotificationService
    {

        private static List<WebSocket> _socket = new();

        public static void AddSocket(WebSocket socket)
        {
            _socket.Add(socket);
        }

        public async Task NotifyNewPost(string title)
        {
            var message = Encoding.UTF8.GetBytes($"Novo Post? {title}");

            foreach (var socket in _socket.Where(s => s.State == WebSocketState.Open))
            {
                await socket.SendAsync(message, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
