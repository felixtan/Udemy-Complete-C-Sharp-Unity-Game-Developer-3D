using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game config
    string level1Name = "neighbor's Wi-Fi";
    string level2Name = "the Government";
    string level3Name = "the Gate";
    string[] level1Passwords = { "dog", "password", "cat", "name", "birthday" };
    string[] level2Passwords = { "alpha", "bravo",  "charlie", "delta", "echo" };
    string[] level3Passwords = { "steiner", "quantum", "cern", "relativity", "fate" };

    // Game state
    int level;
    string userName = "User";
    enum Screen { MainMenu, WaitingForPassword, Win };    // ui state
    Screen currentScreen = Screen.MainMenu;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + userName + ", what would you like to hack?\n");
        Terminal.WriteLine("1: " + level1Name);
        Terminal.WriteLine("2: " + level2Name);
        Terminal.WriteLine("3: " + level3Name);
        Terminal.WriteLine("\nEnter your selection:");
    }

    void OnUserInput(string input)
    {
        if (currentScreen == Screen.MainMenu)
        {
            HandleMainMenuScreen(input);
        }
        else if (currentScreen == Screen.WaitingForPassword)
        {
            HandleWaitingForPasswordScreen(input);
        }
        else if (currentScreen == Screen.Win)
        {
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        }
        else
        {
            throw new InvalidOperationException(String.Format("{0} is an invalid Screen", currentScreen));
        }
    }

    string GetLevelName()
    {
        if (level == 1)
        {
            return level1Name;
        }
        else if (level == 2)
        {
            return level2Name;
        }
        else if (level == 3)
        {
            return level3Name;
        }
        else
        {
            throw new ArgumentException(String.Format("{0} is an invalid level", level), "level");
        }
    }

    void HandleMainMenuScreen(string input)
    {
        if (input == "menu")
        {
            level = 0;
            ShowMainMenu();
        } 
        else if (input == "1" | input == "2" | input == "3")
        {
            level = Int16.Parse(input);
            currentScreen = Screen.WaitingForPassword;
            StartGame();
        }
        else
        {
            print("sorry, you can't hack that yet.");
        }
    }

    void HandleWaitingForPasswordScreen(string input)
    {
        if (input == password)
        {
            currentScreen = Screen.Win;
            HandleWinScreen();
        }
        else
        {
            Terminal.WriteLine("Incorrect password");
        }
    }

    void SetPassword() {
        if (level == 1)
        {
            password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
        }
        else if (level == 2)
        {
            password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
        }
        else if (level == 3)
        {
            password = level3Passwords[UnityEngine.Random.Range(0, level3Passwords.Length)];
        }
        else
        {
            throw new InvalidOperationException(String.Format("{0} is an invalid level", level));
        }
    }

    void HandleWinScreen()
    {
        Terminal.WriteLine("\nHacked into " + GetLevelName() + "!");
        Terminal.WriteLine("\nPress any key to return to menu");
    }

    void StartGame()
    {
        SetPassword();
        Terminal.WriteLine("\nPlease enter the password:");
    }
}
