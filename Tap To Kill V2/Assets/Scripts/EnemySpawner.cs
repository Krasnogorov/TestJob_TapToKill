/**
 * EnemySpawner.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using UnityStandardAssets.Characters.ThirdPerson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for spawning enemies
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    //NPC
    [SerializeField]
    private GameObject npc = null;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", Constants.TIME_SPAWN, Constants.TIME_SPAWN); 
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    /// <summary>
    /// Spawn new enemy with random level of difficult
    /// </summary>
    private void SpawnEnemy()
    {
        EnemyData data = EnemyConfiguration.Instance.GetRandomEnemyWithDifficulty(EnemyDifficulty.EnemyDifficultyMedium);
        if (data != null)
        {
            GameObject enemy = GameObject.Instantiate(data.Prefab, gameObject.transform.position, Quaternion.identity);
            AICharacterControl control = enemy.GetComponent<AICharacterControl>();
            control.SetTarget(npc.transform);
        }
    }
}
