/**
 * EnemyConfiguration.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using UnityEngine;
using System.IO;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;

[InitializeOnLoad]
#endif
public class EnemyConfiguration : ScriptableObject
{
    //data file name
    const string EnemyConfigurationAssetName = "EnemyConfiguration";
    //data file path
    const string EnemyConfigurationPath = "Resources";
    //file extension
    const string EnemyConfigurationAssetExtension = ".asset";
    // instance of object
    private static EnemyConfiguration msInstance;
    // static getter of instance, which can create asset file if it doesn't exist
    public static EnemyConfiguration Instance
    {
        get
        {
            if (msInstance == null)
            {
                msInstance = Resources.Load<EnemyConfiguration>(EnemyConfigurationAssetName);
                if (msInstance == null)
                {
                    // If not found, autocreate the asset object.
                    msInstance = CreateInstance<EnemyConfiguration>();
#if UNITY_EDITOR
                    string properPath = Path.Combine(Application.dataPath, EnemyConfigurationPath);
                    if (!Directory.Exists(properPath))
                    {
                        AssetDatabase.CreateFolder("Assets", EnemyConfigurationPath);
                    }

                    string fullPath = "Assets/Resources/EnemyConfiguration.asset";
                    AssetDatabase.CreateAsset(msInstance, fullPath);
#endif
                }
            }
            return msInstance;
        }
    }

    [SerializeField]
    private List<EnemyData> enemies = new List<EnemyData>();
    /// <summary>
    /// Returns random character from list with selected difficulty
    /// </summary>
    /// <param name="difficulty">Selected difficulty of character</param>
    /// <returns></returns>
    public EnemyData GetRandomEnemyWithDifficulty(EnemyDifficulty difficulty)
    {
        Random.InitState((int)Time.timeSinceLevelLoad);
        List<EnemyData> selected = enemies.FindAll((x) => { return x.difficulty == difficulty; });
        return selected[Random.Range(0, selected.Count - 1)];
    }
}
