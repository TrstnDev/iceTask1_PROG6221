using System;
using System.Text;

namespace iceTask1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Instantiate stringbuilder object for final output   
            StringBuilder report = new StringBuilder();
            Console.Write("-------Student Grade Calculator-------");

         var flag = false;
         var nameInput = "";

         //===========================================NAME & SURNAME INPUT LOGIC================================================
        
         while (flag == false)
         {
             Console.Write("\nEnter student's name: ");
             nameInput = Console.ReadLine();
             
             //checks if the name field is empty/null or contains only whitespace
             if (String.IsNullOrWhiteSpace(nameInput))   
             {
                 Console.Write("\nNAME CANNOT BE EMPTY!\n");
             }
             else
             {
                 //Code retrieved from Google Gemini Pro; splits string input to see if a name AND surname were entered
                 var names = nameInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                 //if the array containing the split string is less than 2, no surname was entered
                 if (names.Length < 2) 
                 {
                     Console.WriteLine("Please enter BOTH a first name and a surname.");
                 }
                 else
                 {
                     var isCapitalised = true;

                     //implicitly create 'part' var to check for capitals for each string array entry
                     foreach (var part in names)  
                     {
                         //if the first character of the string is NOT uppercase set bool to false
                         if (!char.IsUpper(part[0]))  
                         {
                             isCapitalised = false;
                             break;
                         }
                     }

                     if (isCapitalised)
                     {
                         //only once both array components are confirmed to start with an uppercase, can the while loop exit
                         flag = true;
                     }
                     else
                     {
                         Console.WriteLine("Each part of the name must start with a capital letter!");
                     }
                 }
             }
         }

         //===========================================SCORE INPUT & MATH LOGIC================================================
         
         //initialise a small int array to store values during looping logic
         var scores = new int[3];  
         
         //reset boolean to false so it can be reused for next loop
         flag = false;  
         
         //create a 'for' loop that repeats 3 times for score input
         for (var i = 0; i < 3; i++)  
         {
             //use i+1 since arrays start indexing at 0
             Console.Write($"Enter score {i + 1} (out of 100): ");  
             var input = Console.ReadLine();

             //error handling: if the input canNOT be parsed into the int array, keep looping
             while (!int.TryParse(input, out scores[i]))  
             {
                 Console.WriteLine("VALUE MUST BE A NUMBER!");
                 Console.Write($"Enter score {i + 1} (out of 100) again: ");
                 input = Console.ReadLine();
             }
         }

         //math logic to calculate average; for the purpose of this app truncation of numbers is acceptable
         var average = (scores[0] + scores[1] + scores[2]) / 3;
         
         //initialise char variable
         char grade = '\0';  

         //use switch case to neatly assign grades instead of inefficient nested 'if else' statements
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
         
         //===========================================FINAL REPORT GENERATION================================================
         
         report.AppendLine("\n----------GRADE REPORT----------");
         report.AppendLine($"Student Name: {nameInput}");
         report.AppendLine($"Scores: {scores[0]}%, {scores[1]}%, {scores[2]}%");
         report.AppendLine($"Average Score: {average}%");
         report.AppendLine($"Final Grade: {grade}");
         
         Console.WriteLine(report);
        }
    }
}