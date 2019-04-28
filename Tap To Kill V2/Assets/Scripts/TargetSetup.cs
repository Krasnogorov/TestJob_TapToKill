/**
 * TargetSetup.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
/// <summary>
/// Class for setup next target for friendly NPC
/// </summary>
public class TargetSetup : MonoBehaviour
{
    // next target
    [SerializeField]
    private Transform nextTarget = null;

    private void OnTriggerEnter(Collider other)
    {
        AICharacterControl characterControl = other.gameObject.GetComponent<AICharacterControl>();
        if (characterControl != null && other.tag == "Player")
        {
            characterControl.target = nextTarget;
        }
    }
}
