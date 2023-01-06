using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.ChatLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chatLog = new List<string>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];
                string message = cmdArgs[1];

                int index = -1;
                switch (action)
                {
                    case "Chat":
                        chatLog.Add(message);
                        break;
                    case "Delete":
                        chatLog.Remove(message);
                        break;
                    case "Edit":
                        string editedVersion = cmdArgs[2];
                        if (chatLog.Any(x => x == message))
                        {
                            index = chatLog.IndexOf(message);
                            chatLog[index] = editedVersion;
                        }
                        break;
                    case "Pin":
                        if (chatLog.Any(x => x == message))
                        {
                            index = chatLog.IndexOf(message);
                            chatLog.RemoveAt(index);
                            chatLog.Add(message);
                        }
                        break;
                    case "Spam":
                        for (int i = 1; i < cmdArgs.Length; i++)
                        {
                            index = chatLog.IndexOf(cmdArgs[i]);
                            chatLog.Add(cmdArgs[i]);
                            if (index != -1)
                            {
                                chatLog.RemoveAt(index);
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, chatLog));
        }
    }
}
