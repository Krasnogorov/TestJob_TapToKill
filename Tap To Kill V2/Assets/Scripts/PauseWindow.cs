/**
 * PauseWindow.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for pause window
/// </summary>
public class PauseWindow : MonoBehaviour
{
    // Callback for resume game
    private Action windowResumeCallback;
    // Callback for exit from game
    private Action windowBreakCallback;
    // text label
    [SerializeField]
    private Text textLabel;
    // window object
    [SerializeField]
    private GameObject panelObject;
    /// <summary>
    /// Displays the window
    /// </summary>
    /// <param name="pauseText">Text in window</param>
    /// <param name="windowResumeAction">Callback for resume action</param>
    /// <param name="windowBreakAction">Callback for exit action</param>
    public void ShowWindow(string pauseText, Action windowResumeAction, Action windowBreakAction)
    {
        textLabel.text = pauseText;
        windowResumeCallback = windowResumeAction;
        windowBreakCallback = windowBreakAction;
        panelObject.SetActive(true);
    }
    /// <summary>
    /// Resume button callback
    /// </summary>
    public void OnButtonResumeClick()
    {
        panelObject.SetActive(false);
        if (windowResumeCallback != null)
        {
            windowResumeCallback();
            windowResumeCallback = null;
        }
    }
    /// <summary>
    /// Exit button callback
    /// </summary>
    public void OnButtonExitClick()
    {
        panelObject.SetActive(false);
        if (windowBreakCallback != null)
        {
            windowBreakCallback();
            windowBreakCallback = null;
        }
    }
}
