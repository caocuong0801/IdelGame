using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySyncSystem : MonoBehaviour
{
    [SerializeField] private TextAsset settingsAsset;
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var settingsStr = settingsAsset.text;
        Debug.Log("Init enemy sync system with settings = " + settingsStr);
        var settings = JsonUtility.FromJson<AllEnemySettings>(settingsStr);
        if (settings != null && settings.Levels != null && settings.Levels.Any())
        {
            foreach (var item in settings.Levels)
            {
                Debug.Log("Level name = " + item.Name);
                Debug.Log("Wave count = " + item.Waves.Length);
                foreach (var wave in item.Waves)
                {
                    Debug.Log("Wave enemy type = " + wave.Type + " - Hp " + wave.Hp + " - Strength " + wave.Strength + " - Amout " + wave.Amount);
                }
                //createPlayerWithData(item);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[Serializable]
public class AllEnemySettings
{
    public Level[] Levels;
}

[Serializable]
public class Level
{
    public string Name;
    public Wave[] Waves;
}

[Serializable]
public class Wave
{
    public int Type;
    public int Hp;
    public int Strength;
    public int Amount;
}
