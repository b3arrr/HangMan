
//hangman game

string chosenWord = wordSelector(); //initializes string chosenWord with a randomly selected word.
Console.WriteLine("Welome to hangman, guess the righ word before the counter runs out!\nPress any key to continue");
Console.ReadKey(); 
Console.WriteLine();
bool gameOver = false;

while (gameOver == false) 
{
    bool selector = false;
    Console.WriteLine("--Select what you wish to do--");
    Console.WriteLine("1. Friend selects word\n2. Guess randomly selected word\n3. Quit game");
    
    
        while (!selector)
         {
            string userInput = Console.ReadLine(); 
            switch (userInput)
        {
            case "1":
                Console.WriteLine("Please enter word used for hangman");
                chosenWord = Console.ReadLine(); 
                selector = true;
            break;

            case "2":
                 chosenWord = wordSelector();
                 selector = true;
                 break;
            case "3":
                Console.WriteLine("Good bye");
                selector = true;
                gameOver = true; 
                break;
            default: 
                Console.WriteLine("Invalid input, please try again");
            
            break;
                
        }
         }
        
        
    

        

        string[] progressWord = initializeProgress(chosenWord); 


        int tryAmount = chosenWord.Length * 2 + 2; //calculates the amount of tries it takes to guess the right word. 
        bool lostGame = true;
        int counter = tryAmount; 


        for (int o = 0; o < tryAmount; o++)
        {
            Console.WriteLine($"You have {counter} attempts left");
                progressWord = guess(chosenWord,  progressWord); 
                foreach ( string x in  progressWord) //Displays the progress of the word.
                {
                    Console.Write(x);
                }
            Console.WriteLine();

            // Count the number of underscores in progressWord
            int underscoreCount = progressWord.Count(c => c == "_");

            // If there are no underscores left, all letters have been filled in
            if (underscoreCount == 0)
            {
                Console.WriteLine($"The chosen word was \"{chosenWord}\". Congratulations you won!");
                lostGame = false;
                break;
            }
            counter--; 
            Console.WriteLine();
        }
        if (lostGame == true)
        {
            Console.WriteLine("You lost, thanks for playing!");
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
} 











string[] initializeProgress(string chosenWord)
{
    string[] progressWord = new string[chosenWord.Length]; 

    for (int i = 0; i < chosenWord.Length; i++)
    {
        progressWord[i] = "_";
    }

    Console.Write("Current word is = ");
    foreach (string c in progressWord)
    {
        Console.Write(c);
    }
    Console.WriteLine("\n");
    

    return progressWord; 
}



string[] guess(string chosenWord,  string[] newGuessedWord) 
{
    char userInput;
    while (true)
    {
        Console.WriteLine("Guess a character");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        userInput = keyInfo.KeyChar;
        Console.WriteLine();
        Console.WriteLine($"\nYou guessed {userInput}\n");
        
        if (char.IsLetter(userInput)) //checks if the user input is indeed a character
        {
            int x = 0; 
            //codeblock to check if letter corresponds to chosen word.
            bool checkLetter = false;
            foreach (char o in chosenWord)
            {
                
                if(userInput == o)
                {
                    string userInputString = userInput.ToString(); 
                    /* Console.WriteLine("true"); */
                    newGuessedWord[x] = userInputString;
                    checkLetter = true; 
                    x++;

                }
                else
                {
                  /*   Console.WriteLine("False"); */
                    if(newGuessedWord[x] == null)
                    {
                        newGuessedWord[x] = "_";
                    }
                    
                    x++;
                }
                
                
            }
            if (checkLetter == true)
            {
                Console.WriteLine("Congrats you guessed the right letter");
            }
            else 
            {
                Console.WriteLine("Sorry you guessed the wrong letter"); 
            }





            break; // If it's a letter, break out of the loop
        }
        else
        {
            Console.WriteLine("Invalid input, please type again.");
        }
    }
    return newGuessedWord;
}




string wordSelector() //selects a random word and returns the word as a string.
{
string luckyWord;
Random word = new Random();
List<string> words = new List<string>();
words.Add("hello");
words.Add("life");
words.Add("alice");
words.Add("corn");
words.Add("list");

int count = words.Count; 
int x = word.Next(0,count);
luckyWord = words[x];
return luckyWord;
}

