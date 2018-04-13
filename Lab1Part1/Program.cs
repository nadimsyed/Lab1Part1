using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            //In Lab one instruction it asks the task be written in a seperate method, so I put all the code into a seperate method to make the Main as clean as possible

            Digits();
        }

        //Named the method Digits because it was a short name that fit with the application of checking the digits of inputted
        // numbers
        public static void Digits()
        {
            //input two numbers with SAME DIGIT AMOUNT
            //use dot length for digit amount check

            //check if the two digits in same spots add up to the same number as other digits in same spots

            //print true or false based off result

            //print quit to close task exit it out the console if possible

            /* Things to look for
                    -Do proper validation on the user’s input.(make sure numbers and make sure same digit amount)
                            when converting from string of readline to integer, you can catch if its not convertible to integer
                            if not convertible to integer catch error and print something saying invalid and enter digit and continue back
                    -Write  the task in a separate method.
                    -Provide adequate comments.
                    -Provide adequate user prompts.*/

            //This condition was made to be able to handle the while loop parameters in more than one way(use break and this)
            bool condition = true;

            //Using a while loop so user can input multiple pairs of digits they want to check and also so if they put an invalid input, they can easily get another try
            while (condition == true)
            {
                //This List is here so I have a place to store the digits that I add from the user inputted integers
                List<int> results = new List<int>();

                //Prompting user to input the first integer. I'm using a ToLower so that way any variation in the writing of "quit" allows for the funcion of "quit" to be executed. 
                Console.WriteLine("Please insert two integer numbers, with the same number of digits, that you want to check! OR type \"quit\" to exit out.");
                Console.Write("First Integer Number:  ");
                string num1 = Console.ReadLine().ToLower();

                //This quit break is here because I was running into the issue of the user being prompted for a second input even though they had already put a "quit"
                // in the first input. So for user ease and fluidity of the console app I inserted this to stop the application here if user desires.
                if (num1 == "quit")
                    break;

                //Prompting user to input second digit. I'm using a ToLower so that way any variation in the writing of "quit" allows for the funcion of "quit" to be executed. 
                Console.Write("Second Integer Number:  ");
                string num2 = Console.ReadLine().ToLower();

                //Using a try catch because I want to be able to handle errors and provide feedback to user when an error has occured
                try
                {
                    //This quit break is here so that if the user decides during the second integer entry they want to quit out the application, they can do so.
                    if (num2 == "quit")
                    {
                        condition = false;
                        break;
                    }

                    //The following conversion code lines are to check if the user inputted things other than numbers, if so the try
                    // will end here and go to the catch which will take whatever the error that happened and output what's inside
                    // the catch, but we'll get to the explicit of that once we get there
                    int numOne = Convert.ToInt32(num1);

                    int numTwo = Convert.ToInt32(num2);

                    //The following if statement here purely if someone inputs a single digit integer, even though the instructions
                    // say digits, I made this just in case a user does input two single digit inputs. Then it will print the following
                    // message and go back to the beginning allowing users to input two new integers
                    if (num1.Length == 1 || num2.Length == 1)
                    {
                        Console.WriteLine("Multiple Digits Required!");
                        continue;
                    }
                    //This else if statement checks if the user inputted integers that have the same amount of digits, if it does it does
                    // what is inside the brackets
                    else if (num1.Length == num2.Length)
                    {
                        //Console.WriteLine("Same number of digits!");

                        //This variable was made to store the added sums of the digits in there respective places
                        var total = 0;

                        //This for loop loops through each slot in both of the integers the user inputted and converts it to int32
                        // then it adds the two digits in the same slot of each digit and stores it in the total. After that, we store the new
                        // total into the list results that we made near the beginning of our code
                        for (int i = 0; i < num1.Length; i++)
                        {
                            //I used Char.GetNumericValue because if you convert the single char from the inputted string to int32
                            // you get the unicode value, which I found out the hard way. For example, 1 = 49 in unicode. So I found
                            // this GetNumericValue method inside the Char class that converts to proper english int32. Like 1 = 1
                            // also I did not go the numeric way to solve the problem by dividing with modular 10 and then divide
                            // by 10 so leaving it as an string then converting here is fine. 
                            int input1 = (int)Char.GetNumericValue(num1[i]);
                            int input2 = (int)Char.GetNumericValue(num2[i]);
                            total = input1 + input2;
                            results.Add(total);
                            //Console.WriteLine(total);
                            //Console.WriteLine(results[i]);
                        }

                        //I store the first sum of digits of the user inputs into first so that way I can easily check the other slots of
                        // the user inputs
                        int first = results[0];
                        //condition2 was made to print out the result which we'll go over soon
                        bool condition2 = true;

                        //This for loop cycles through every slot in the results that we stored and compares to the first sum stored
                        // in result 
                        for (int i = 1; i < results.Count; ++i)
                        {
                            // if any of the sums stored in results are not the same, condition2 is assigned false
                            if (first != results[i])
                            {
                                condition2 = false;
                            }
                        }

                        //So here based on the previous for loop condition2 gets its value of true or false. So if all the sums in the List
                        // results are the same "True" will be printed but if any of the sums are not the same "False" will be printed
                        if (condition2)
                        {
                            Console.WriteLine("True");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("False");
                            continue;
                        }
                    }
                    //This is here so if the user passed the check of if they have inputted digits and got passed entering single digit
                    // inputs but they are not of equal digit amount, the console lets the user know that they have inputted integers
                    // with different amount of digits
                    else
                    {
                        Console.WriteLine("Not the same number of digits! D:");
                        continue;
                    }
                }
                //This is the exception that if the user inputs get through all the other checks, and they input something outside
                // what we want like letters or symbols the user will be prompted that there input was invalid and they'll
                // get another try because they'll be cycled back to the beginning
                catch (Exception)
                {
                    Console.WriteLine("Invalid inputs!");
                }
            }
        }
    }
}