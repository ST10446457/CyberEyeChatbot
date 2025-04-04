using System;
using System.Media; // Required for playing audio
using System.Threading; // Required for adding typing effect

class CyberEyeChatbot
{
    static void Main()
    {
        // Step 1: Play the Voice Greeting First
        PlayVoiceGreeting();

        // Step 2: Display the ASCII Logo
        DisplayAsciiLogo();

        // Step 3: Text-based Welcome Message
        Console.WriteLine("Welcome to Cyber Eye - Your Cybersecurity Awareness Bot!");
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        Console.WriteLine($"\nHello {userName}, I'm here to help you stay safe online!\n");

        // Step 4: Start the Chatbot
        StartChatbot();
    }

    // Method to Play the Greeting Audio
    static void PlayVoiceGreeting()
    {
        try
        {
            string filePath = @"C:\Users\RC_Student_lab\source\repos\CyberEyeChatbot\CyberEyeChatbot\CyberEyeChatbot\bin\Debug\greeting.wav"; // Update path if needed

            if (System.IO.File.Exists(filePath))
            {
                SoundPlayer player = new SoundPlayer(filePath);
                player.PlaySync(); // Ensures the sound plays before continuing
            }
            else
            {
                Console.WriteLine("Error: WAV file not found. Please check the file location.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error playing audio: {ex.Message}");
        }
    }

    // Method to Display the ASCII Art Logo
    static void DisplayAsciiLogo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
         ██████╗██╗   ██╗███████╗███████╗
        ██╔════╝██║   ██║██╔════╝██╔════╝
        ██║     ██║   ██║█████╗  ███████╗
        ██║     ██║   ██║██╔══╝  ╚════██║
        ╚██████╗╚██████╔╝███████╗███████║
         ╚═════╝ ╚═════╝ ╚══════╝╚══════╝
         Cyber Eye - Protecting You Online!
        ");
        Console.ResetColor();
    }

    // Method to Handle Chatbot Logic
    static void StartChatbot()
    {
        while (true) // Keeps the chatbot running
        {
            Console.Write("\nYou: ");
            string userInput = Console.ReadLine().ToLower(); // Convert input to lowercase for better matching

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Cyber Eye: Please enter a valid question.");
                continue;
            }

            switch (userInput)
            {
                case "what is phishing":
                    TypingEffect("Cyber Eye: Phishing is a type of online scam where attackers trick users into revealing sensitive information, such as passwords and credit card details, by pretending to be a trustworthy entity.");
                    break;

                case "how can i prevent phishing":
                    TypingEffect("Cyber Eye: You can prevent phishing by:\n" +
                                "1️⃣ Not clicking on suspicious links in emails or messages.\n" +
                                "2️⃣ Verifying the sender before sharing personal information.\n" +
                                "3️⃣ Using multi-factor authentication (MFA) for extra security.\n" +
                                "4️⃣ Keeping your software and antivirus updated.");
                    break;

                case "how are you":
                    TypingEffect("Cyber Eye: I'm just a chatbot, but I'm always here to assist you!");
                    break;

                case "what's your purpose":
                    TypingEffect("Cyber Eye: My purpose is to educate you on cybersecurity and help you stay safe online.");
                    break;

                case "what can i ask you about":
                    TypingEffect("Cyber Eye: You can ask me about:\n" +
                                "✔️ Phishing\n" +
                                "✔️ Password security\n" +
                                "✔️ Safe browsing tips\n" +
                                "✔️ Online threats");
                    break;

                case "exit":
                    TypingEffect("Cyber Eye: Stay safe online! Goodbye! 👋");
                    return; // Exits the loop and ends the chatbot

                default:
                    TypingEffect("Cyber Eye: I didn't quite understand that. Could you rephrase?");
                    break;
            }
        }
    }

    // Method to Simulate Typing Effect
    static void TypingEffect(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(30); // Creates a typing effect
        }
        Console.WriteLine();
    }
}
