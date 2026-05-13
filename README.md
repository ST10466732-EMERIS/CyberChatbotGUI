using System;
using System.Collections.Generic;

namespace CyberChatbot
{
    public class ResponseManager
    {
        private Dictionary<string, List<string>> responses;
        private Random rnd = new Random();

        public ResponseManager()
        {
            responses = new Dictionary<string, List<string>>();
            InitializeResponses();
        }

        private void InitializeResponses()
        {
            // Add more responses here for better marks
            responses["password"] = new List<string> { /* your 3+ responses */ };
            responses["scam"] = new List<string> { /* ... */ };
            responses["phishing"] = new List<string> { /* ... */ };
            responses["privacy"] = new List<string> { /* ... */ };
        }

        public string GetResponse(string keyword)
        {
            if (responses.ContainsKey(keyword))
            {
                return responses[keyword][rnd.Next(responses[keyword].Count)];
            }
            return null;
        }

        public List<string> GetAllKeywords()
        {
            return new List<string>(responses.Keys);
        }
    }
}
