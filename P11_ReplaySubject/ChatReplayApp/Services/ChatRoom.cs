using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Subjects;

namespace ChatReplayApp.Services
{
    public class ChatRoom
    {
        private readonly ReplaySubject<string> _messageHistory;
        private readonly List<IDisposable> _subscriptions;
        private readonly string _filePath = "ChatHistory.txt";

        public ChatRoom()
        {
            _messageHistory = new ReplaySubject<string>();
            _subscriptions = new List<IDisposable>();
            LoadChatHistory();
        }

        public IDisposable JoinChat(string userName)
        {
            Console.WriteLine($"{userName} dołączył do czatu.");
            var subscription = _messageHistory.Subscribe(message => Console.WriteLine($"{userName} otrzymał wiadomość: {message}"));
            _subscriptions.Add(subscription);
            return subscription;
        }

        public void SendMessage(string userName, string message)
        {
            string formattedMessage = $"{userName}: {message}";
            Console.WriteLine(formattedMessage);
            _messageHistory.OnNext(formattedMessage);
            SaveMessageToFile(formattedMessage);
        }

        public void LoadChatHistory()
        {
            if (File.Exists(_filePath))
            {
                var messages = File.ReadAllLines(_filePath);
                foreach (var message in messages)
                {
                    _messageHistory.OnNext(message);
                }
            }
        }

        public void SaveMessageToFile(string message)
        {
            using (var writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
