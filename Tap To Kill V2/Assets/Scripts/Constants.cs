/**
 * Constants.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */

/// <summary>
/// All constants in game
/// </summary>
public class Constants 
{
    // address of server 
    public const string WEB_SERVER_URL = "https://www.google.com/";
    // Error text - not avaliable internet connection
    public const string ERROR_TEXT_UNREACHEABLE_INTERNET = "Internet connection is not avaliable. Please connect to internet and try again";
    
    // Scene names 
    // Main menu scene name
    public const string MAIN_MENU_SCENE = "MainMenu";
    // Main game scene name
    public const string MAIN_GAME_SCENE = "MainGame";

    // Window messages
    // Win game
    public const string WIN_GAME_MESSAGE = "You win!";
    // Lose game
    public const string LOSE_GAME_MESSAGE = "You lose!";

    // Time for spawn enemy
    public const float TIME_SPAWN = 1.5f;
    // Time for level
    public const float LEVEL_TIME = 60.0f;
}
