using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Diagnostics;




namespace Chatbot
{
    internal class Program
    {

        static void Main(string[] args)
        {

            VoiceGreeting();
            ImageDisplay();
            StartChat();
            UserInteraction();
        }
        //voice greeting method
        static void VoiceGreeting()
        {
            var myPlayer = new System.Media.SoundPlayer();
            myPlayer.SoundLocation = @"C:\Users\dineo\source\repos\Chatbot\Chatbot\PROG2A.wav.wav";
            myPlayer.Play();

        }
        //ASCII art text dislpay
        static void ImageDisplay()
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

        static string StartChat()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\nWhat is your name :)?");
                string name = Console.ReadLine();


                if (!string.IsNullOrEmpty(name))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Welcome " + name);
                    Console.ResetColor();
                    return name;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I didnt quite understand that,Could you rephrase ");
                Console.ResetColor();
            }
        }

        static void UserInteraction()
        {
            while (true) // Keep chatbot running until user exits
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nAsk me questions: ");
                string userInput = Console.ReadLine().ToLower();
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Type exit to leave this page");
                if (userInput == "exit")

                {
                    Console.WriteLine("\nGoodbye! Stay safe online. 😊");
                    Environment.Exit(0);


                }

                // Check if the question matches known questions

                if (userInput.Contains("how are you"))
                {
                    Console.WriteLine("I'm a robot; I don't have feelings.");
                }
                else if (userInput.Contains("purpose"))
                {
                    Console.WriteLine("I'm here to help you stay safe online.");
                }
                else if (userInput.Contains("what are basic things you can help me with"))
                {
                    Console.WriteLine("I can help with password safety, phishing, and safe browsing.");
                }
                else if (userInput.Contains("phishing"))
                {
                    Console.WriteLine("Phishing is the practice of sending fraudulent communications that appear to come from a legitimate and reputable source,usually through email and test messaging");
                }
                else if (userInput.Contains("password safety"))
                {
                    Console.WriteLine("Create strong, unique passwords for each account and use a password manager.");
                }
                else if (userInput.Contains("safe browsing"))
                {
                    Console.WriteLine("Safe browsing is practices that help protect you online by being cautious about the websites you visit, checking for secure connections (like \"HTTPS\"), avoiding suspicious links, keeping your software updated, and managing your privacy settings to minimize the information you share online.");
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm not sure about that. Try asking something related to cybersecurity.");
                    Console.ResetColor();

                }
                //Console.ForegroundColor = ConsoleColor.Yellow;
                // Console.WriteLine("\nYou can ask me another question or type 'exit' to leave.");
                //Console.ResetColor();

            }
        }
    }
}