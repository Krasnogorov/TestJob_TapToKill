/**
 * IngameMenu.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Class for ingame interface
/// </summary>
public class IngameMenu : MonoBehaviour
{
    // Pause window
    [SerializeField]
    private PauseWindow PauseWindow = null;
    // Win window
    [SerializeField]
    private BaseWindow WinWindow = null;
    // Lose window
    [SerializeField]
    private BaseWindow LoseWindow = null;
    // timer label
    [SerializeField]
    private Text timerLabel = null;
    // hp label
    [SerializeField]
    private Text hpLabel = null;
    /// <summary>
    /// Pause button callback. Show pause window
    /// </summary>
    public void OnPauseClick()
    {
        // TODO: change it if needed to messages or actions
        Time.timeScale = 0.0f;
        PauseWindow.ShowWindow("", () => {
            Time.timeScale = 1.0f;
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
        Time.timeScale = 0.0f;
        WinWindow.ShowWindow(Constants.WIN_GAME_MESSAGE, () => {
            SceneManager.LoadScene(Constants.MAIN_MENU_SCENE);
        });
    }
    /// <summary>
    /// Method for displaying lose window
    /// </summary>
    public void LoseGame()
    {
        Time.timeScale = 0.0f;
        LoseWindow.ShowWindow(Constants.LOSE_GAME_MESSAGE, () => {
            SceneManager.LoadScene(Constants.MAIN_MENU_SCENE);
        });
    }

    private void LateUpdate()
    {
        timerLabel.text = ((int)LevelManager.Instance.CurrentTime).ToString();
        hpLabel.text = LevelManager.Instance.CurrentPlayerHP.ToString();
    }
}
