using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Diagnostics;

class CyberSecurityBot
{
    // Memory to store user info
    static string userName = null;
    static string userInterest = null;

    // Keyword-based tips (optimized using dictionary and lists)
    static Dictionary<string, List<string>> cybersecurityTips = new Dictionary<string, List<string>>()
    {
        {"password", new List<string> {
            "Use strong, unique passwords for each account. Avoid using personal details.",
            "Consider using a password manager to store your passwords safely.",
            "Change your passwords regularly and never share them."
        }},
        {"scam", new List<string> {
            "Never click on suspicious links or attachments in emails.",
            "Verify the identity of anyone asking for your personal information.",
            "Be cautious of deals that seem too good to be true—they often are."
        }},
        {"privacy", new List<string> {
            "Review privacy settings on your social media and email accounts.", 
            "Limit what personal information you share online.",
            "Use encrypted communication tools whenever possible."
        }},
        {"phishing", new List<string> {
            "Be cautious of emails asking for personal information.",
            "Don’t click on links from unknown senders.",
            "Check for poor grammar or suspicious links in emails.",
            "Go directly to websites rather than clicking on email links."
        }}
    };

    // Sentiment map
    static Dictionary<string, string> sentimentResponses = new Dictionary<string, string>() 
    {
        {"worried", "It's completely understandable to feel that way. Let me help ease your concerns."},
        {"frustrated", "I get that this can be frustrating. You're not alone—many face the same issue."},
        {"curious", "Curiosity is great! Let's explore more about this topic together."}
    };

    // Voice greeting method
    static void VoiceGreeting()
    {
        try
        {
            var myPlayer = new SoundPlayer();
            myPlayer.SoundLocation = @"C:\Users\dineo\source\repos\Chatbot\Chatbot\PROG2A.wav.wav"; // <-- Make sure this path is correct and file exists
            myPlayer.Load();  // Load sound to catch any file errors early
            myPlayer.Play();  // Play audio
        }
        catch (Exception ex)
        {
            Console.WriteLine("CyberSecurityBot: Audio could not be played. " + ex.Message);
        }
    }

    // ASCII welcome method
    static void DisplayWelcomeAscii()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        string tittle = @"  /$$$$$$  /$$     /$$ /$$$$$$$  /$$$$$$$$ /$$$$$$$  /$$   /$$ /$$$$$$$$ /$$$$$$$$
 /$$__  $$|  $$   /$$/| $$__  $$| $$_____/| $$__  $$| $$$ | $$| $$_____/|__  $$__/
| $$  \__/ \  $$ /$$/ | $$  \ $$| $$      | $$  \ $$| $$$$| $$| $$         | $$   
| $$        \  $$$$/  | $$$$$$$ | $$$$$   | $$$$$$$/| $$ $$ $$| $$$$$      | $$   
| $$         \  $$/   | $$__  $$| $$__/   | $$__  $$| $$  $$$$| $$__/      | $$   
| $$    $$    | $$    | $$  \ $$| $$      | $$  \ $$| $$\  $$$| $$         | $$   
|  $$$$$$/    | $$    | $$$$$$$/| $$$$$$$$| $$  | $$| $$ \  $$| $$$$$$$$   | $$   
 \______/     |__/    |_______/ |________/|__/  |__/|__/  \__/|________/   |__/   
                                                                                  
                                                                                  
                                                                                  
  /$$$$$$  /$$$$$$$$  /$$$$$$  /$$   /$$ /$$$$$$$  /$$$$$$ /$$$$$$$$ /$$     /$$  
 /$$__  $$| $$_____/ /$$__  $$| $$  | $$| $$__  $$|_  $$_/|__  $$__/|  $$   /$$/  
| $$  \__/| $$      | $$  \__/| $$  | $$| $$  \ $$  | $$     | $$    \  $$ /$$/   
|  $$$$$$ | $$$$$   | $$      | $$  | $$| $$$$$$$/  | $$     | $$     \  $$$$/    
 \____  $$| $$__/   | $$      | $$  | $$| $$__  $$  | $$     | $$      \  $$/     
 /$$  \ $$| $$      | $$    $$| $$  | $$| $$  \ $$  | $$     | $$       | $$      
|  $$$$$$/| $$$$$$$$|  $$$$$$/|  $$$$$$/| $$  | $$ /$$$$$$   | $$       | $$      
 \______/ |________/ \______/  \______/ |__/  |__/|______/   |__/       |__/      
 ";
        Console.WriteLine(tittle);
    }

    // Detect sentiment in user input
    static string DetectSentiment(string input) 
    {
        foreach (var sentiment in sentimentResponses)
        {
            if (input.ToLower().Contains(sentiment.Key))
                return sentiment.Value;
        }
        return null;
    }

    // Handle keyword recognition and responses
    static string HandleKeyword(string input) 
    {
        foreach (var entry in cybersecurityTips)
        {
            if (input.ToLower().Contains(entry.Key))
            {
                var tip = GetRandomTip(entry.Value);

                if (userInterest != null && userInterest.ToLower().Contains(entry.Key))
                {
                    return $"As someone interested in {entry.Key}, here's a tip: {tip}";
                }

                return tip;
            }
        }

        return null;
    }

    // Random tip selection
    static string GetRandomTip(List<string> tips) 
    {
        Random rand = new Random();
        int index = rand.Next(tips.Count);
        return tips[index];
    }

    // Main chatbot logic
    static void Chat()
    {
        VoiceGreeting(); // Play audio first
        DisplayWelcomeAscii(); // Then display ASCII

        Console.WriteLine("CyberSecurityBot: Hi! Ask me anything about cybersecurity.");

        while (true)
        {
            Console.Write("\nYou: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("CyberSecurityBot: Please enter something.");
                continue;
            }

            if (input.ToLower() == "exit" || input.ToLower() == "quit")
            {
                Console.WriteLine("CyberSecurityBot: Stay safe online. Goodbye!");
                break;
            }

            if (input.ToLower().StartsWith("my name is"))
            {
                userName = input.Substring(10).Trim();
                Console.WriteLine($"CyberSecurityBot: Nice to meet you, {userName}!");
                continue;
            }

            if (input.ToLower().Contains("i'm interested in"))
            {
                int index = input.ToLower().IndexOf("i'm interested in") + "i'm interested in".Length;
                userInterest = input.Substring(index).Trim();
                Console.WriteLine($"CyberSecurityBot: Great! I’ll remember that you're interested in {userInterest}.");
                continue;
            }

            string sentimentResponse = DetectSentiment(input);
            if (sentimentResponse != null)
            {
                Console.WriteLine("CyberSecurityBot: " + sentimentResponse);
                continue;
            }

            string response = HandleKeyword(input);
            if (response != null)
            {
                Console.WriteLine("CyberSecurityBot: " + response);
                continue;
            }

            Console.WriteLine("CyberSecurityBot: I'm not sure I understand. Can you try rephrasing?");
        }
    }

    static void Main(string[] args)
    {
        Chat();
    }
}

