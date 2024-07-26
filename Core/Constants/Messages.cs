using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Core.Constants
{
    public class Messages
    {
        public static void ErrorOccuredMessage() { Console.WriteLine("Error Occured"); }
        public static void InputMessage(string message) { Console.WriteLine($"Please input {message}"); }
        public static void InvalidInputMessage(string message) { Console.WriteLine($"{message} is invalid"); }
        public static void SuccessMessage() { Console.WriteLine("Operation succesfully done!"); }
        public static void NotFoundMessage() { Console.WriteLine("Not found");}
    }
}
