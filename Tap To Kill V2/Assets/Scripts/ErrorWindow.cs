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
/// Note: it was implemented as static method to simplify call of this window
/// </summary>
public class ErrorWindow : BaseWindow
{
    // static instance of window
    private static ErrorWindow msInstance = null;
 
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
        msInstance.ShowWindow(errorText, retryWindowCallback);
    }
    
    private void OnDisable()
    {
        msInstance = null;
    }
}
