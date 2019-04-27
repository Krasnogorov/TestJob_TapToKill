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
    private static ErrorWindow msInstance = null;
    private Action retryCallback;
    [SerializeField]
    private Text textLabel;
    [SerializeField]
    private GameObject panelObject;

    public void Awake()
    {
        msInstance = this;
    }

    public static void ShowError(string errorText, Action retryWindowCallback)
    {
        msInstance.DisplayErrorWindow(errorText, retryWindowCallback);
    }

    public void DisplayErrorWindow(string errorText, Action retryWindowCallback)
    {
        textLabel.text = errorText;
        retryCallback = retryWindowCallback;
        panelObject.SetActive(true);
    }

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
