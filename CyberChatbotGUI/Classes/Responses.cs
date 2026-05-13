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
        }using System;
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
                responses["password"] = new List<string>
            {
                "Use strong, unique passwords for every account.",
                "Consider using a password manager like Bitwarden or LastPass.",
                "Never reuse the same password across different websites."
            };

                responses["scam"] = new List<string>
            {
                "Be very careful with emails asking for personal information.",
                "Scammers often create fake urgency. Take your time to verify.",
                "Always check the sender's email address carefully."
            };

                responses["phishing"] = new List<string>
            {
                "Never click on suspicious links. Hover over them first to see the real URL.",
                "Phishing sites often have slight spelling mistakes in the domain name.",
                "If in doubt, don't click - verify through official channels."
            };

                responses["privacy"] = new List<string>
            {
                "Review your privacy settings on social media regularly.",
                "Enable two-factor authentication (2FA) on all important accounts.",
                "Be mindful of what personal information you share online."
            };
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

            // Bonus method for better marks
            public string GetRandomResponse()
            {
                if (responses.Count == 0) return "No responses available.";

                var keys = new List<string>(responses.Keys);
                string randomKey = keys[rnd.Next(keys.Count)];
                return responses[randomKey][rnd.Next(responses[randomKey].Count)];
            }
        }
    }

    public List<string> GetAllKeywords()
        {
            return new List<string>(responses.Keys);
        }
    }
}