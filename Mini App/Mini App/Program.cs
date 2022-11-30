using System.Text.RegularExpressions; //allows for the regex method to be recognised

class Mini_Apps
{
    public static void Menu() //menu to return to after each section
    {

        Console.WriteLine("P4CS Mini Applications");
        Console.WriteLine("----------------------");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1) Keep Counting");
        Console.WriteLine("2) Square Root Calculator");
        Console.WriteLine("3) Encrypt Text (Caesar Cipher)");
        Console.WriteLine("4) Decrypt Text (Caesar Cipher) ");
        Console.WriteLine("9) Quit");

        SelectChoice();

    }//end of menu function


    public static void SelectChoice()
    {

        int Option; //decalare option as 0 so that it is within scope for the invalid inputs

        bool x = true;
        while (x == true) //loop until function is jumped to
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter option: ");

            Option = int.Parse(Console.ReadLine()); //takes user input as integer

            switch (Option) //jumps to method depending on option variable
            {
                case 1:
                    KeepCountingOnce(); //jumps to keep counting method
                    x = false;
                    Menu();
                    break;
                case 2:
                    SquareRoot(); //jumps to square root calculator method
                    x = false;
                    Menu();
                    break;
                case 3:
                    TextEncryption(); //jumps to encryption method
                    x = false;
                    Menu();
                    break;
                case 4:
                    TextDecryption(); //jumps to decryption method
                    x = false;
                    Menu();
                    break;
                case 9: //ends loop
                    x = false;
                    break;
                default: //for an option not declared repeat invalid input and repeat (please enter input line)
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }


    public static void KeepCountingOnce() //first loop to gather the first integer to be used as operand
    {
        Console.WriteLine("Keep Counting");
        Console.WriteLine("-------------");

        int CorrectAnsCount = 0; //keeps tally of correct answers

        Random rnd = new Random(); //declares random method

        int suboradd = rnd.Next(0, 100); //50 / 50 chance of question being an addition or subtraction


        int firstint = rnd.Next(1, 10); //first int for maths
        int secondint = rnd.Next(1, 10); //second int for maths

        int ans_addition = firstint + secondint; //addition answer of rnd numbers
        int ans_subtraction = firstint - secondint; //subtratction ans for rnd numbers

        Console.Write("Question 1: "); //always the first only question

        if (suboradd >= 50) //negative 5050 condition
        {
            Console.WriteLine("");
            Console.WriteLine("{0} - {1} = ", firstint, secondint); //asks subtraction question
            int userans = int.Parse(Console.ReadLine()); //user input as integer

            if (userans == ans_subtraction) //correct ans branch
            {
                CorrectAnsCount++; //correct answer count increment
                Console.WriteLine("");
            }
            else //wrong ans branch
            {
                Console.WriteLine("INCORRECT: ANSWER IS {0}", ans_subtraction); //gives correct answer after wrong input from user
                Console.WriteLine("");
            }

        }
        else //positive 5050 condition
        {
            Console.WriteLine("");
            Console.WriteLine("{0} + {1} = ", firstint, secondint); //asks addition question
            int userans = int.Parse(Console.ReadLine()); //takes user input

            if (userans == ans_addition) //correct ans branch
            {
                CorrectAnsCount++; //correct answer increment
                Console.WriteLine("");
            }
            else //incorrect ans branch
            {
                Console.WriteLine("INCORRECT: ANSWER IS {0}", ans_addition); //Gives correct answer
                Console.WriteLine("");
            }
        }

        if (suboradd == 1) //goes to the keep counting in order to use the operand as a new variable
        {
            KeepCounting(ans_subtraction, CorrectAnsCount); //jump to method KeepCounting passing subtraction ans, CorrectAnsCount
        }
        else
        {
            KeepCounting(ans_addition, CorrectAnsCount); //jump to method KeepCounting passing addition ans, CorrectAnsCount
        }

        //no return to menu here because we ALWAYS need to go to keep counting passing the parameters

    }//end of keepcounting once function


    public static void KeepCounting(int operand, int CorrectAnsCount) //method KeepCounting Passing through operand rule, CorrectAnsCount
    {

        Random rnd = new Random(); //declares random method


        for (int i = 0; i < 9; i++) //for loop to ask the 9 other questions
        {
            int secondint = rnd.Next(1, 10); //second int for maths
            int ans_addition = operand + secondint; //addition answer of rnd numbers
            int ans_subtraction = operand - secondint; //subtratction ans for rnd numbers
            int suboradd = rnd.Next(0, 100); //50 / 50 chance of question being an addition or subtraction

            Console.Write("Question {0} : ", i + 2); //question counter is 2 higher than 0, 1, 2 etc.. since its continuing from the last sections Q1


            if (suboradd >= 50) //negative 5050 condition
            {
                Console.WriteLine("");
                Console.WriteLine("{0} + {1} = ", operand, secondint); //asks addition question

                int userans = int.Parse(Console.ReadLine()); //user input as integer

                if (userans == ans_addition) //correct ans branch
                {
                    CorrectAnsCount++; //correct answer increment
                    operand = ans_addition; //changes value for operand for next iteration
                    Console.WriteLine("");

                }
                else //incorrect ans branch
                {
                    Console.WriteLine("INCORRECT: ANSWER IS {0}", ans_addition); //correct answer output
                    operand = ans_addition; //changes value for operand for next iteration
                    Console.WriteLine("");
                }

            }
            else //positive 5050 condition
            {
                Console.WriteLine("");
                Console.WriteLine("{0} - {1} = ", operand, secondint); //asks subtraction question

                int userans = int.Parse(Console.ReadLine()); //takes user input as integer

                if (userans == ans_subtraction) //correct ans branch
                {
                    CorrectAnsCount++; //correct answer count increment
                    operand = ans_subtraction; //changes value for operand for next iteration
                    Console.WriteLine("");
                }
                else //wrong ans branch
                {
                    Console.WriteLine("INCORRECT: ANSWER IS {0}", ans_subtraction); //correct answer output
                    operand = ans_subtraction; //changes value for operand for next iteration
                    Console.WriteLine("");
                }
            }
        }

        Console.WriteLine("You got {0} out of 10 questions correct", CorrectAnsCount); //outputs how many answers were right
        Console.WriteLine("");
        Console.WriteLine("");

    } //end of keep counting function


    public static void SquareRoot() //main square root base function for verification
    {
        Console.WriteLine("Square Root Calculator");
        Console.WriteLine("----------------------");
        Console.Write("Please enter a positive number: ");

        int Num = 0; //decalare to keep in valid scope

        bool y = true;
        while (y == true)
        {
            Num = int.Parse(Console.ReadLine()); //number thats going to be square rooted inputted
            if (Num < 0) //if number is smaller than 0
            {
                Console.WriteLine("Please enter a valid input: ");
            }
            else
            {
                y = false; //exits loop to continu asking for user input
            }
        }

        bool x = true;
        while (x == true)
        {

            Console.WriteLine("How many decimal places do you want the solution to be calculated to : ");
            int DecAsked = int.Parse(Console.ReadLine()); //number of decimal places inputted

            if (DecAsked < 1 || DecAsked > 6) //if decimal places are too small or big, restart the method statement
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("");
            }
            else
            {
                SquareRootCalc(Num, DecAsked); //jump to square root passing number and decasked
                x = false;
            }

        }

    } //end of square root function


    public static void SquareRootCalc(int Num, int DecAsked) //passes user inputs through to work on arithmetical calculations
    {

        double UpperBound = Num / 2; //upper bound largest number possible
        double LowerBound = 1; //lower bound smallest number possible
                               //declared outside the loop so that the value of upper and lower bound doesnt get reset back to this so that it is actually able to refine closer to the overall answer


        double DecPlaces = Math.Pow(0.1, DecAsked); //decplaces is 0.1 ^ (decasked), which is 0.1, 0.01, 0.001, etc...

        bool x = true;
        while (x == true) //iterates until the only condition that leaves the loop comes true
        {
            if (Math.Pow(Avg(UpperBound, LowerBound), 2) == Num) //if exact answer is reached
            {
                double Answer = Avg(UpperBound, LowerBound); // answer is given a variable name
                AnsReached(Num, DecAsked, Answer); //pass the answer through to the answer output function
                x = false; //end loop in case
            }
            else if ((UpperBound - LowerBound) < DecPlaces) //if difference of bounds is less than decimal places
            {
                double Answer = Avg(UpperBound, LowerBound); //answer is given variable name for easier use
                AnsReached(Num, DecAsked, Answer); //pass the answer through to the answer output function
                x = false;
            }
            else if (Math.Pow(Avg(UpperBound, LowerBound), 2) < Num) //Average squared is less than num
            {
                LowerBound = UpdateLower(LowerBound); //update the lower value to make it bigger

                //Console.WriteLine(Avg(UpperBound, LowerBound));  //used to test the method of getting closer to answer
            }
            else if (Math.Pow(Avg(UpperBound, LowerBound), 2) > Num) // Average squared is less than num
            {
                UpperBound = UpdateUpper(UpperBound); //update the upper value to make it smaller

                //Console.WriteLine(Avg(UpperBound, LowerBound)); //used to test the methood of getting closer to answer
            }

        }

    } //end of square root function


    public static double Avg(double Upper, double Lower) //returns average of upper and lower bounds
    {
        double x = Upper + Lower; //total of lower and upper bounds

        double y = x / 2; //total divided by 2

        return y; //return average

    } //end of avg function


    public static double UpdateUpper(double Upper) //updates upperbound by multiplying by ?/10
    {
        double x = Upper * 9.90000505 / 10; //the smaller the difference between 10 and operand = more accurate result
        return x;

    } //end of update upper function


    public static double UpdateLower(double Lower) //updates lowerbound by multiplying by ?/10
    {
        double x = Lower * 10.1000404 / 10; //the smaller the difference between 10 and operand = more accurate result
        return x;

    } //end of Update lower function


    public static void AnsReached(int Num, int DecAsked, double PassedDouble) //passes all relevent variables once the only condition which leaves the Square root calc while loop / outputs answer
    {
        Console.WriteLine("The square root of {0} to {1} decimal places is {2}", Num, DecAsked, Math.Round(PassedDouble, DecAsked)); //Outputs the final answer
        Console.WriteLine("");
        Console.WriteLine("");

    } //end of answer output function


    public static void TextEncryption() //main encryption function which works through verification
    {
        Console.WriteLine("Encrypt Text");
        Console.WriteLine("------------");
        Console.WriteLine("Please enter text to encrypt : ");
        string RawInput = Console.ReadLine(); //takes users raw input
        string UpperInput = RawInput.ToUpper(); //turns user input into all uppercase leaving the numbers alone


        Regex r = new Regex("[A-Z0-9 ]"); //checks valid range of inputs / URL: https://stackoverflow.com/questions/12350801/check-string-for-invalid-characters-smartest-way
                                          //has been modified to only allow 0 -> 9 and A -> Z, I have learnt the IsMatch method and ranges used in C# 

        if (!r.IsMatch(UpperInput)) //if r is not in Upper Input then: / URL: https://stackoverflow.com/questions/12350801/check-string-for-invalid-characters-smartest-way
        {
            Console.WriteLine("Validation Failed"); //error message
            TextEncryption(); //reload encryption method
        }

        bool x = true; //x is false for exit loop condition
        while (x == true) //loops until shift is within valid range
        {
            Console.WriteLine("Please enter how much you want to shift the encryption by (between 1 and 36) : ");
            int Shift = int.Parse(Console.ReadLine()); //integer input by user

            if (Shift < 1 || Shift > 36) //range disallowed
            {
                Console.WriteLine("Invalid Input");

            }
            else //exits loop
            {
                EncryptionCalc(UpperInput, Shift); //jumps to encryptioncalc function
                x = false;
            }
        }

        Console.WriteLine("");
        Console.WriteLine("");

    } //end of encryption function


    public static void EncryptionCalc(string Input, int Shift) //calculation function passing user input and shift
    {

        char[] Index = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' }; //character string for valid shifts
        int ind; //short for other  sort of index

        char[] Text_Encrypt = Input.ToCharArray(); //converts into an array

        Console.Write("The encoded string is : ");

        foreach (char c in Text_Encrypt) //for each input character
        {

            ind = Index[Array.IndexOf(Index, c)]; //handing the index of the new value
            ind = ind + Shift + 3; //error shift of 3 gets the shift to work

            if (ind >= 0) //if statement for each index over 36
            {
                Console.Write(Index[ind % 36]); //output the remainder of mod 36
            }
            else
            {
                Console.Write(Index[Array.IndexOf(Index, c) + Shift]); //outputs Character of the new character in Index moved by shift to the right
            }

        }

        Console.WriteLine("");
        Console.WriteLine("");

    } //end of function encryptioncalc


    public static void TextDecryption() //main decryption function that works through most the verification
    {

        Console.WriteLine("Decrypt Text");
        Console.WriteLine("------------");
        Console.WriteLine("Please enter the text to Decrpyt");
        string RawInput = Console.ReadLine(); //user raw input
        string UpperInput = RawInput.ToUpper(); //turns user raw input into all uppercase and leaving the numbers alone

        Regex r = new Regex("[A-Z0-9 ]");//checks valid range of inputs https://stackoverflow.com/questions/12350801/check-string-for-invalid-characters-smartest-way
                                         //has been modified to only allow 0 -> 9 and A -> Z, i have learnt the IsMatch method and ranges used in C# 

        if (!r.IsMatch(UpperInput)) //if r is not in Upper Input then: / URL: https://stackoverflow.com/questions/12350801/check-string-for-invalid-characters-smartest-way
        {
            Console.WriteLine("Validation Failed"); //Error Message
            TextDecryption(); //reload method text decryption
        }

        bool x = true;
        while (x == true) //loops until shift is within valid range
        {
            Console.WriteLine("Please enter how much you want to shift the encryption by (between 1 and 36) : ");
            int Shift = int.Parse(Console.ReadLine());

            if (Shift < 1 || Shift > 36) //range disallowed
            {
                Console.WriteLine("Invalid Input");

            }
            else //exits loop
            {
                DecrytpionCalc(UpperInput, Shift); //jumps to DecryptionCalc function passing input and shift
                x = false;
            }

        }

        Console.WriteLine("");
        Console.WriteLine("");

    } //end of function decryption


    public static void DecrytpionCalc(string Input, int Shift) //function where the operation is done passing input and shift /and outputs answer
    {

        char[] Index = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' }; //character string for valid shifts
        int Ind; //short for other  sort of index

        char[] Text_Decrypt = Input.ToCharArray(); //converts into an array

        foreach (char c in Text_Decrypt) //for each input character
        {
            Ind = Index[Array.IndexOf(Index, c)]; //handing the index of the new value
            Ind = Ind - Shift - 65; //error shifting gets it to work

            if (Ind >= 0)
            {
                Console.Write(Index[Array.IndexOf(Index, c) - Shift]); //outputs Character of the new character in Index moved by shift to the left
            }
            else
            {
                Ind = Ind + 37; //goes to top of array depending how -ve
                Console.Write(Index[Ind]); //outputs that new shift

            }

        }

    } //end of decryptioncalc function



    public static void Main()
    {
        Menu();

    } //end of main function

} //end of class