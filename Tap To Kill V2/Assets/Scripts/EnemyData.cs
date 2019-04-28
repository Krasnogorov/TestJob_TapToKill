/**
 * EnemyData.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using UnityEngine;

/// <summary>
/// Level of difficulty for enemy
/// </summary>
public enum EnemyDifficulty
{
    EnemyDifficultyLight = 0,
    EnemyDifficultyMedium,
    EnemyDifficultyHard
};
/// <summary>
/// Data of one enemy
/// </summary>
[System.Serializable]
public class EnemyData
{
    public GameObject Prefab;
    public EnemyDifficulty difficulty;
}
