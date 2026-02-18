using System;
using System.Text;

namespace iceTask1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StringBuilder report = new StringBuilder();
            Console.Write("-------Student Grade Calculator-------\n");

         var flag = false;
         var nameInput = "";

         while (flag == false)
         {
             Console.Write("\nEnter student's name: ");
             nameInput = Console.ReadLine();
             
             if (String.IsNullOrWhiteSpace(nameInput))
             {
                 Console.Write("\nNAME CANNOT BE EMPTY!\n");
             }
             else
             {
                 var names = nameInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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
         flag = false;
         
         for (var i = 0; i < 3; i++)
         {
             Console.Write($"Enter score {i + 1} (out of 100): ");
             var input = Console.ReadLine();

             while (!int.TryParse(input, out scores[i]))
             {
                 Console.WriteLine("VALUE MUST BE A NUMBER!");
                 Console.Write($"Enter score {i + 1} (out of 100) again: ");
                 input = Console.ReadLine();
             }
         }

         report.AppendLine("\n-------GRADE REPORT-------");
         report.AppendLine($"Student Name: {nameInput}");
         report.AppendLine($"Scores: {scores[0]}%, {scores[1]}%, {scores[2]}%");
         report.AppendLine($"Average Score: ");
         report.AppendLine($"Final Grade: ");
         
         Console.WriteLine(report);
        }
    }
}