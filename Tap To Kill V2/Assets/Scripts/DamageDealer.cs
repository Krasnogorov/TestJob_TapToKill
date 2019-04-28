/**
 * DamageDealer.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using UnityEngine;
/// <summary>
/// Class to make damage to NPC
/// </summary>
public class DamageDealer : MonoBehaviour
{
    // current damage
    [SerializeField]
    public int CurrentDamage = 0;

    /// <summary>
    /// Make damage to NPC only on collide with it
    /// </summary>
    /// <param name="collision">Object which collided</param>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelManager.Instance.DamageToNPC(CurrentDamage);
        }
    }
}
