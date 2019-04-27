/**
 * InitializeGame.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class InitializeGame : MonoBehaviour
{
    /// <summary>
    /// Starts the script
    /// </summary>
    void Start()
    {
        ConnectToServer();
    }
    /// <summary>
    /// Tries to connect to hardcoded server. 
    /// If connection fails display window with error.
    /// </summary>
    private void ConnectToServer()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            ShowError(Constants.ERROR_TEXT_UNREACHEABLE_INTERNET, ConnectToServer);
        }
        else
        {
            StartCoroutine(SendRequest(Constants.WEB_SERVER_URL, (text, error) => {
                if (error != null)
                {
                    ShowError(error, ConnectToServer);
                }
                else
                {
                    Debug.Log(string.Format("Text of response is {0}", text));
                    LoadMainGame();
                }
            }));
        }
    }
    /// <summary>
    /// Sends request to necessary url and return response and error text
    /// </summary>
    /// <param name="url">Url to server</param>
    /// <param name="response">Action with two string parameters : text and error. Any of them can be null.</param>
    /// <returns></returns>
    private IEnumerator SendRequest(string url, Action<string, string> response)
    {
        var request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (!request.isHttpError && !request.isNetworkError)
        {
            response(request.downloadHandler.text, null);
        }
        else
        {
            response(null, request.error);
        }

        request.Dispose();
    }
    /// <summary>
    /// Loads next level 
    /// </summary>
    private void LoadMainGame()
    {
        SceneManager.LoadScene(Constants.MAIN_MENU_SCENE);
    }
    /// <summary>
    /// Displays error in necessary format - Debug.Log or any alert windows 
    /// </summary>
    /// <param name="text">Text of error</param>
    /// <param name="retryCallback">callback for alert window</param>
    private void ShowError(string text, Action retryCallback)
    {
        // TODO: implement alert window here
        Debug.LogError(text);
    }
}
