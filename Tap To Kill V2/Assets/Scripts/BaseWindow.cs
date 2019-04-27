/**
 * BaseWindow.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Base class for windows in game
/// </summary>
public class BaseWindow : MonoBehaviour
{
    // Callback for action in window
    private Action windowCallback;
    // text in window
    [SerializeField]
    private Text textLabel;
    // window object
    [SerializeField]
    private GameObject panelObject;

    /// <summary>
    /// Displays the window with text and callback
    /// </summary>
    /// <param name="text">Text in window</param>
    /// <param name="windowAction">Callback for action</param>
    public void ShowWindow(string text, Action windowAction)
    {
        textLabel.text = text;
        windowCallback = windowAction;
        panelObject.SetActive(true);
    }
    /// <summary>
    /// Action button callback
    /// </summary>
    public void OnButtonClick()
    {
        panelObject.SetActive(false);
        if (windowCallback != null)
        {
            windowCallback();
            windowCallback = null;
        }
    }
}
