using System;
using System.Collections.Generic;
using System.Media;

namespace CyberChatbot
{
    public class Chatbot
    {
        private Random rnd = new Random();
        private Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>();

        // Memory Variables (Section 5)
        private string userName = "Friend";
        private string favouriteTopic = "";

        public Chatbot()
        {
            LoadResponses();
            PlayGreeting();
            Console.WriteLine("Welcome to CyberGuard Chatbot!");
        }

        private void LoadResponses()
        {
            responses["password"] = new List<string>
            {
                "Use strong, unique passwords for every account.",
                "Consider using a password manager like Bitwarden or LastPass.",
                "Never reuse the same password on multiple websites."
            };

            responses["scam"] = new List<string>
            {
                "Be very careful with emails asking for personal information.",
                "Scammers often create fake urgency. Always take time to verify.",
                "Check the sender's email address carefully before replying."
            };

            responses["phishing"] = new List<string>
            {
                "Never click on suspicious links. Hover over them first to see the real URL.",
                "Phishing websites often have small spelling mistakes in the domain name."
            };

            responses["privacy"] = new List<string>
            {
                "Review your privacy settings on social media regularly.",
                "Enable two-factor authentication (2FA) on all important accounts."
            };
        }

        // ==================== VOICE GREETING (Important) ====================
        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play();                    // Plays asynchronously
                // Optional: You can also show a message in chat
            }
            catch (Exception)
            {
                // Silently fail if file is missing (prevents crash)
            }
        }

        public string GetResponse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "Sorry, I didn't catch that. Please type something.";

            string lower = input.ToLower();

            // Memory: Name
            if (lower.Contains("my name is") || lower.Contains("call me") || lower.Contains("i am "))
            {
                userName = ExtractName(input);
                return $"Nice to meet you, {userName}! I'll remember your name.";
            }

            // Memory: Favourite Topic
            if (lower.Contains("interested in") || lower.Contains("favourite") || lower.Contains("favorite"))
            {
                favouriteTopic = ExtractTopic(lower);
                return $"Got it, {userName}! I'll remember that you're interested in {favouriteTopic}.";
            }

            // Conversation Flow
            if (lower.Contains("more") || lower.Contains("another") || lower.Contains("tell me"))
            {
                return GetRandomTip() + $"\n\nAnything else I can help you with, {userName}?";
            }

            // Sentiment Detection (Section 6)
            string sentiment = DetectSentiment(lower);
            if (sentiment != null)
            {
                return sentiment + "\n\n" + GetRandomTip();
            }

            // Keyword Recognition + Random Response
            foreach (var key in responses.Keys)
            {
                if (lower.Contains(key))
                {
                    string reply = responses[key][rnd.Next(responses[key].Count)];
                    return PersonaliseResponse(reply);
                }
            }

            // Error Handling (Section 7)
            return $"I'm not sure I understand, {userName}. Can you try rephrasing?\n\n" +
                   "You can ask me about passwords, scams, phishing, or privacy.";
        }

        private string DetectSentiment(string lower)
        {
            if (lower.Contains("worried") || lower.Contains("scared") || lower.Contains("afraid") || lower.Contains("nervous"))
                return "I understand you're feeling worried. It's completely normal to feel that way about online threats.";

            if (lower.Contains("frustrated") || lower.Contains("angry"))
                return "I can see you're frustrated. Let's take it slow and clear.";

            if (lower.Contains("curious") || lower.Contains("interested"))
                return "That's great that you're curious! Knowledge is the best protection.";

            if (lower.Contains("confused") || lower.Contains("don't understand"))
                return "No problem at all! Let me explain it more simply.";

            return null;
        }

        private string GetRandomTip()
        {
            var tips = new List<string>
            {
                "Always enable two-factor authentication (2FA) when possible.",
                "Keep your software and operating system updated.",
                "Be cautious when using public Wi-Fi networks.",
                "Use strong antivirus software.",
                "Avoid downloading files from untrusted websites."
            };
            return tips[rnd.Next(tips.Count)];
        }

        private string PersonaliseResponse(string reply)
        {
            if (!string.IsNullOrEmpty(favouriteTopic) && favouriteTopic != "Cybersecurity")
                return reply + $"\n\nSince you're interested in {favouriteTopic}, this tip is especially important for you.";
            return reply;
        }

        private string ExtractName(string input)
        {
            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length - 1; i++)
            {
                string w = words[i].ToLower();
                if (w == "is" || w == "me" || w == "am")
                    return words[i + 1];
            }
            return "Friend";
        }

        private string ExtractTopic(string lower)
        {
            if (lower.Contains("privacy")) return "Privacy";
            if (lower.Contains("password")) return "Password Security";
            if (lower.Contains("scam") || lower.Contains("phishing")) return "Scams & Phishing";
            return "Cybersecurity";
        }
    }
}