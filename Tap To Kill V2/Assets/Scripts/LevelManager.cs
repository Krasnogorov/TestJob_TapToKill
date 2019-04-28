/**
 * LevelManager.cs
 * This code is part of demo project.
 * Created by Sergey Krasnogorov.
 * All rights reserved.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Level manager for control time and lifes
/// </summary>
public class LevelManager : MonoBehaviour
{
    // static instance of manager
    private static LevelManager msInstance = null;
    // current timer
    private float timer = 0.0f;
    // current player HP
    private int PlayerHP = 100;
    // ingame UI 
    [SerializeField]
    private IngameMenu IngameMenu = null;
    // getter for current time 
    public float CurrentTime
    {
        get
        {
            return timer;
        }
    }
    // getter for current HP
    public int CurrentPlayerHP
    {
        get
        {
            return PlayerHP;
        }
    }
    // getter for difficulty of new enemies
    public EnemyDifficulty CurrentDificulty
    {
        get
        {
            return (timer < Constants.LEVEL_TIME * 0.33f) ? EnemyDifficulty.EnemyDifficultyLight :
                   (timer < Constants.LEVEL_TIME * 0.67f) ? EnemyDifficulty.EnemyDifficultyMedium :
                    EnemyDifficulty.EnemyDifficultyHard;
            
        }
    }
    // instance of manager
    public static LevelManager Instance
    {
        get
        {
            return msInstance;
        }
    }

    public void Awake()
    {
        msInstance = this;
        Time.timeScale = 1.0f;
    }

    public void OnDisable()
    {
        msInstance = null;
    }
    /// <summary>
    /// Makes damage to NPC.
    /// Variable has int value because there is no sence to make it float in demo.
    /// </summary>
    /// <param name="damage">Size of damage</param>
    public void DamageToNPC(int damage)
    {
        PlayerHP -= damage;
        if (PlayerHP <= 0)
        {
            IngameMenu.LoseGame();
        }
    }

    /// <summary>
    /// Updates timer and display win or lose window by timer
    /// </summary>
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit curHit in hits)
            {
                if (curHit.collider != null && curHit.collider.gameObject.tag == "Enemy")
                {
                    DestroyImmediate(curHit.collider.gameObject);
                }
            }
        }

        timer += Time.deltaTime;
        if (timer >= Constants.LEVEL_TIME)
        {
            CancelInvoke();
            if (PlayerHP > 0)
            {
                IngameMenu.WinGame();
            }
            else
            {
                IngameMenu.LoseGame();
            }
        }
        
    }
}
