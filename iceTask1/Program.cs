//==========================================AUTHOR: T. Kriel (Student ID: ST10467193)================================================

using System;
using System.Text;

namespace iceTask1
{
    internal class Program
    {
        
        /// <summary>
        /// Receives, validates, and manipulates user input to display a summary grade report
        /// using string manipulation, math calculations, and looping logic.
        /// </summary>
        /// <param name="args"></param>
        
        public static void Main(string[] args)
        {
         //=========================================START OF MAIN PROGRAM LOGIC=================================================
        
        
        
         
         //=======================================VARIABLE & OBJECT INSTANTIATION===============================================
         
         
         StringBuilder report = new StringBuilder();   //create stringbuilder object to simplify final report generation
         var flag = false;  //general flag to assist with looping logic and checks
         var nameInput = "";  
         var scores = new int[3];  //integer array to store 3 student scores while looping logic is active
         var average = 0;
         var grade = '\0';
         
         
         //===========================================NAME & SURNAME INPUT LOGIC================================================
        
         
         Console.Write("-------Student Grade Calculator-------");
         
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
                 //Code adapted from Google Gemini Pro output; splits string input to see if a name AND surname were entered
                 //https://gemini.google.com
                 //Prompt: How would I validate if a string consists of two words, and if each is capitalised?
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

         
         
         
         //===========================================SCORE INPUT & MATH LOGIC==================================================
         
         
         //reset boolean flag to false so it can be reused for next loop
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
         average = (scores[0] + scores[1] + scores[2]) / 3;
        
         
         
         
         //=============================================GRADE ALLOCATION========================================================
         
         
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
         
         
         
         
         //===========================================FINAL REPORT GENERATION==================================================
         
         
         report.AppendLine("\n----------GRADE REPORT----------");
         report.AppendLine($"Student Name: {nameInput}");
         report.AppendLine($"Scores: {scores[0]}%, {scores[1]}%, {scores[2]}%");
         report.AppendLine($"Average Score: {average}%");
         report.AppendLine($"Final Grade: {grade}");
         
         Console.WriteLine(report);
         
         
         
         
         //=============================================END OF PROGRAM=========================================================
        }
    }
}