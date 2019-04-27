/**
 * IngameMenu.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Class for ingame interface
/// </summary>
public class IngameMenu : MonoBehaviour
{
    // Pause window
    [SerializeField]
    private PauseWindow PauseWindow;
    // Win window
    [SerializeField]
    private BaseWindow WinWindow;
    // Lose window
    [SerializeField]
    private BaseWindow LoseWindow;

    /// <summary>
    /// Pause button callback. Show pause window
    /// </summary>
    public void OnPauseClick()
    {
        // TODO: pause the game
        PauseWindow.ShowWindow("", () => {
            // TODO: resume the game
        }, 
        () => {
            SceneManager.LoadScene(Constants.MAIN_MENU_SCENE);
        });
    }
    /// <summary>
    /// Method for displaying win window
    /// </summary>
    public void WinGame()
    {
        WinWindow.ShowWindow(Constants.WIN_GAME_MESSAGE, () => {
            SceneManager.LoadScene(Constants.MAIN_MENU_SCENE);
        });
    }
    /// <summary>
    /// Method for displaying lose window
    /// </summary>
    public void LoseGame()
    {
        LoseWindow.ShowWindow(Constants.LOSE_GAME_MESSAGE, () => {
            SceneManager.LoadScene(Constants.MAIN_MENU_SCENE);
        });
    }
}
