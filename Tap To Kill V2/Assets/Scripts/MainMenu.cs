/**
 * MainMenu.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Class for interfaces in main menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Callback for start button
    /// </summary>
    public void OnStartClick()
    {
        SceneManager.LoadScene(Constants.MAIN_GAME_SCENE);
    }
}
