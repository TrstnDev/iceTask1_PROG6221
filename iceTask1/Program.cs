using System;

namespace iceTask1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
         Console.Write("-------Student Grade Calculator-------\n");

         var flag = false;

         while (flag == false)
         {
             Console.Write("\nEnter student's name: ");
             var nameInput = Console.ReadLine();
             
             if (String.IsNullOrWhiteSpace(nameInput))
             {
                 Console.Write("\nNAME CANNOT BE EMPTY!\n");
             }
             else
             {
                 string[] names = nameInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                 if (names.Length < 2)
                 {
                     Console.WriteLine("Please enter BOTH a first name and a surname.");
                 }
                 else
                 {
                     var isCapitalised = true;

                     foreach (var part in names)
                     {
                         if (!char.IsUpper(part[0]))
                         {
                             isCapitalised = false;
                             break;
                         }
                     }

                     if (isCapitalised)
                     {
                         flag = true;
                     }
                     else
                     {
                         Console.WriteLine("Each part of the name must start with a capital letter!");
                     }
                 }
             }
         }

         var scores = new int[3];
         var input = "";
         flag = false;
         
         for (var i = 1; i < 4; i++)
         {
             Console.Write($"\nEnter score {i} (out of 100): ");
             input = Console.ReadLine();

             while (!int.TryParse(input, out scores[i]))
             {
                 Console.WriteLine("VALUE MUST BE A NUMBER!");
                 Console.Write($"Please try to enter score{i} again: ");
                 input = Console.ReadLine();
             }
         }
         
        }
    }
}