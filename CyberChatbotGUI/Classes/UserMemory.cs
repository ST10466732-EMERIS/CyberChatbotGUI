using System;

namespace CyberChatbot
{
    public class UserMemory
    {
        public string UserName { get; private set; } = "Friend";
        public string FavouriteTopic { get; private set; } = "";

        // Update memory from user input
        public void UpdateName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                UserName = name.Trim();
        }

        public void UpdateFavouriteTopic(string topic)
        {
            if (!string.IsNullOrWhiteSpace(topic))
                FavouriteTopic = topic.Trim();
        }

        // Personalise message using memory
        public string Personalise(string message)
        {
            if (!string.IsNullOrEmpty(FavouriteTopic))
            {
                return message + $"\n\nSince you're interested in {FavouriteTopic}, this is especially relevant for you.";
            }
            return message;
        }

        public string GetGreeting()
        {
            return $"Hello, {UserName}!";
        }
    }
}