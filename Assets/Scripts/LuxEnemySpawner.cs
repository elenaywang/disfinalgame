using UnityEngine;
using System.Collections;


public class LuxEnemySpawner : EnemySpawner
{

    [Header("Time-based Spawn Settings")]
    public float morningSpawnRate = 0.35f;    // 8AM-2PM
    public float afternoonSpawnRate = 0.3f;   // 2PM-8PM
    public float eveningSpawnRate = 0.07f;    // 8PM-2AM
    public float nightSpawnRate = 0.03f;      // 2AM-8AM


    public override void InitializeSpawnRate()
    {
        // set initial spawn rate based on current time
        UpdateSpawnRateBasedOnTime();
        // Debug.Log($"LuxEnemySpawner initialized with spawn rate: {spawnRate} at hour: {TimeManager.Hour}");
    }


    public override void ChangeSpawnRate() {
        UpdateSpawnRateBasedOnTime();
        // Debug.Log($"LuxEnemySpawner changed spawn rate to: {spawnRate} at hour: {TimeManager.Hour}");
    }


    private void UpdateSpawnRateBasedOnTime() {
        int currentHour = TimeManager.Hour;

        // set spawn rate based on time of day
        
        // morning (8am-2pm)
        if (currentHour >= 8 && currentHour < 14) {
            spawnRate = morningSpawnRate;
        } 
        
        // afternoon (2pm-8pm)
        else if (currentHour >= 14 && currentHour < 20) {
            spawnRate = afternoonSpawnRate;
        }
        
        // evening (8pm-2am)
        else if ((currentHour >= 20 && currentHour < 24) || (currentHour >= 0 && currentHour < 2)) {
            spawnRate = eveningSpawnRate;
        }
        
        // night (2am-8am)
        else{
            spawnRate = nightSpawnRate;
        }
    }

}
