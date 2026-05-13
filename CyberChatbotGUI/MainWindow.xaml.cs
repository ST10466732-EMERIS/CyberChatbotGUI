using System;
using System.Media;
using System.Security.Claims;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CyberChatbot
{
    public partial class MainWindow : Window
    {
        private Chatbot chatbot;

        public MainWindow()
        {
            InitializeComponent();
            chatbot = new Chatbot();
            LoadInitialMessages();
        }

        private void LoadInitialMessages()
        {
            AppendMessage("CyberGuard", "Hello! Welcome to CyberGuard - Your Cybersecurity Assistant.", true);

            // === ASCII ART (Required for Part 1 & 2) ===
            string asciiArt = @"
   ██████╗██╗   ██╗██████╗ ███████╗██████╗  ██████╗ ██╗   ██╗ █████╗ ██████╗ ██████╗ 
  ██╔════╝██║   ██║██╔══██╗██╔════╝██╔══██╗██╔═══██╗██║   ██║██╔══██╗██╔══██╗██╔══██╗
  ██║     ██║   ██║██████╔╝█████╗  ██████╔╝██║   ██║██║   ██║███████║██║  ██║██████╔╝
  ██║     ██║   ██║██╔══██╗██╔══╝  ██╔══██╗██║   ██║██║   ██║██╔══██║██║  ██║██╔══██╗
  ╚██████╗╚██████╔╝██║  ██║███████╗██║  ██║╚██████╔╝╚██████╔╝██║  ██║██████╔╝██████╔╝
   ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═════╝ ╚═════╝ 

                  CYBERSECURITY AWARENESS CHATBOT
            ";

            AppendMessage("CyberGuard", asciiArt, true);

            AppendMessage("CyberGuard",
                "I can help you with passwords, scams, phishing, privacy, and more.\n" +
                "Try saying: 'My name is Joy' or 'I'm worried about scams'", true);
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string userInput = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(userInput)) return;

            AppendMessage("You", userInput, false);

            // Get response from chatbot
            string response = chatbot.GetResponse(userInput);
            AppendMessage("CyberGuard", response, true);

            txtInput.Clear();
            chatDisplay.ScrollToEnd();
        }

        private void AppendMessage(string sender, string message, bool isBot)
        {
            // This format works well for ASCII art and normal messages
            chatDisplay.AppendText($"{sender}:\n{message}\n\n");
            chatDisplay.ScrollToEnd();
        }
    }
}
//References

//Microsoft. (2023) * WPF(Windows Presentation Foundation) *.Microsoft Docs.Available at: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/ (Accessed: 13 May 2026).

//Microsoft. (2024) * SoundPlayer Class *.Microsoft Docs.Available at: https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer (Accessed: 13 May 2026).

//Microsoft. (2024) * Dictionary < TKey,TValue > Class *.Microsoft Docs.Available at: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 (Accessed: 13 May 2026).

//Troelsen, A.and Japikse, P. (2022) *Pro C# 10 with .NET 6*. 11th edn. New York: Apress.