/**
 * ErrorWindow.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Window controller for simple window for error
/// </summary>
public class ErrorWindow : MonoBehaviour
{
    // static instance of window
    private static ErrorWindow msInstance = null;
    // callback for retry action
    private Action retryCallback;
    // text in window
    [SerializeField]
    private Text textLabel;
    // window object
    [SerializeField]
    private GameObject panelObject;

    public void Awake()
    {
        msInstance = this;
    }
    /// <summary>
    /// Static method for displaying error
    /// </summary>
    /// <param name="errorText">Text of error</param>
    /// <param name="retryWindowCallback">Callback for retry action</param>
    public static void ShowError(string errorText, Action retryWindowCallback)
    {
        msInstance.DisplayErrorWindow(errorText, retryWindowCallback);
    }
    /// <summary>
    /// Method for displaying error
    /// </summary>
    /// <param name="errorText">Text of error</param>
    /// <param name="retryWindowCallback">Callback for retry action</param>

    public void DisplayErrorWindow(string errorText, Action retryWindowCallback)
    {
        textLabel.text = errorText;
        retryCallback = retryWindowCallback;
        panelObject.SetActive(true);
    }
    /// <summary>
    /// Retry button callback
    /// </summary>
    public void OnRetryClick()
    {
        panelObject.SetActive(false);
        if (retryCallback != null)
        {
            retryCallback();
            retryCallback = null;
        }
        
    }

    private void OnDisable()
    {
        msInstance = null;
    }
}
