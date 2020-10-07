//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configaration
    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "books", "self", "font", "fit" };
    string[] level2Passwords = { "handcuffs", "prisoner", "uniform", "arrest" };
    string[] level3Passwords = { "star", "telescope", "environment", "exploration" };
    // Game State
    int level;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        //print("Hello Console");
        // print(level1Passwords[0]);
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        //  string greeting   = "Hello";
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("What Whould You Like To Hack?");
        Terminal.WriteLine("Press 1 for local Library");
        Terminal.WriteLine("Press 2 for Police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter Your Selection: ");
    }


    void OnUserInput(string input)
    {
        // Terminal.WriteLine("You Typed" + input);
        if (input == "menu")
        {
            //  print("You Choose Level 1 ");
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" );
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }



        /*   if (input == "1")
           {
               level = 1;
               password = level1Passwords[2];
               StartGame();
           }
           else if (input == "2")
           {
               level = 2;
               password = level2Passwords[3];
               StartGame();
           }
           */
        else if (input == "007")
        {
            Terminal.WriteLine("Enter a Level");
        }
        else
        {
            Terminal.WriteLine("Enter a vaild Level");
            Terminal.WriteLine(menuHint);
        }
    }

    //void StartGame()
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        //  Terminal.WriteLine("You Have Chossen Level " + level);
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter Your Password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }
        void SetRandomPassword()
        {
            switch (level)
            {
                case 1:
                    //  int index1 = Random.Range(0, Level1Passwords.Length);
                    password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                    break;
                case 2:
                    //  int index2 = Random.Range(0, Level2Passwords.Length);
                    password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                    break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
                default:
                    Debug.LogError("Invaild Level Number");
                    break;
            }

        }
    

        void CheckPassword(string input)
        {
            if (input == password)
            {
                DisplayWinScreen();
            }
            else
            {
                AskForPassword();
                //Terminal.WriteLine("Sorry, wrong Password");
            }
        }

        void DisplayWinScreen()
        {
            currentScreen = Screen.Win;
            Terminal.ClearScreen();
            ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

        void ShowLevelReward()
        {
            switch (level)
            {
                case 1:
                    Terminal.WriteLine("Have a Book...");
                    Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/         
"
                   );
                    break;

                case 2:
                    Terminal.WriteLine("You got the Prison Key");
                    Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '          
"
                   );
                Terminal.WriteLine("Play again for a greater challenge");
                    break;
            case 3:
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___)\__,_|
"
                );
                Terminal.WriteLine("Welcome to NASA's internal system!");
                break; break;
            default:
                    Debug.LogError("Invalid level reached");
                    break;
            }
        }
    }
