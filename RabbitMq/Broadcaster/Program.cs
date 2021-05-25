using Shared;
using System;

namespace Broadcaster
{
    class Program
    {
        static void Main(string[] args)
        {
            string hostName = "localhost";
            var rabbitMQManager = new RabbitMQManager(hostName);
            while (true)
            {
                Console.WriteLine("Enter first name or type x to exit. ");
                string fullName = "";
                string firstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("Name cannot be empty");
                    continue;
                }
                else
                {
                    if (firstName == "x")
                    {
                        return;
                    }
                    else
                    {
                        fullName += firstName;
                    }
                   
                } Console.WriteLine("Enter last name or type x to exit. ");
                   string lastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Name cannot be empty");
                    continue;
                }
                else
                {
                    if (lastName == "x")
                    {
                        return;
                    }
                    else
                    {
                        fullName += " ";
                        fullName += lastName;
                    }
                   
                }

                Console.WriteLine("[Start]");
                try
                {
                    rabbitMQManager.SendMessage(QueueNames.HELLO_WORLD, fullName);
                    Console.WriteLine("[Done]");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Something went wrong: {ex.Message}]");
                    Console.ReadKey();
                    return;
                }
                
            }
        }


    }
}
