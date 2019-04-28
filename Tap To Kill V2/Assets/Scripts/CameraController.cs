/**
 * CameraController.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using UnityEngine;
/// <summary>
/// Class for rotating camera to  Friendly NPC
/// </summary>
public class CameraController : MonoBehaviour
{
    // NPC object on scene
    [SerializeField]
    private GameObject target;

    void LateUpdate()
    {
        gameObject.transform.LookAt(target.transform);
    }
}
