using System;
using System.Text;

namespace iceTask1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StringBuilder report = new StringBuilder();
            Console.Write("-------Student Grade Calculator-------");

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

         var average = (scores[0] + scores[1] + scores[2]) / 3;
         char grade = '\0';

         switch (average)
         {
           case int n when (n >= 90 && n <= 100):
               grade = 'A';
               break;
           case int n when (n >= 80 && n < 90):
               grade = 'B';
               break;
           case int n when (n >= 70 && n < 80):
               grade = 'C';
               break;
           case int n when (n >= 60 && n < 70):
               grade = 'D';
               break;
           case int n when (n < 60):
               grade = 'F';
               break;
         }
         
         
         report.AppendLine("\n----------GRADE REPORT----------");
         report.AppendLine($"Student Name: {nameInput}");
         report.AppendLine($"Scores: {scores[0]}%, {scores[1]}%, {scores[2]}%");
         report.AppendLine($"Average Score: {average}%");
         report.AppendLine($"Final Grade: {grade}");
         
         Console.WriteLine(report);
        }
    }
}