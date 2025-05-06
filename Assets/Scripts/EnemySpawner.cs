using UnityEngine;
using System.Collections;


// written with the help of Claude AI

public abstract class EnemySpawner : MonoBehaviour
{

    public float spawnWidth = 4f;
    public float spawnRate;
    public GameObject enemyPrefab;

    [Tooltip("Is this the left or right spawner")]
    public float whichSpawner;          // 1 is left, 2 is right

    private float lastSpawnTime = 0;
    protected bool initialized = false;


    protected virtual void Awake() {
        TimeManager.OnHourChanged += TimeCheck;
    }

    
    public abstract void InitializeSpawnRate();


    protected virtual void OnEnable() {
        if (!initialized) {
            InitializeSpawnRate();
            initialized = true;
        }
    }


    protected virtual void OnDisable() {
        TimeManager.OnHourChanged -= TimeCheck;     // unsubscribe from event
    }


    private void TimeCheck() {
        ChangeSpawnRate();
    }


    public abstract void ChangeSpawnRate();


    protected virtual void Update() {
        // only spawn if a valid spawn rate is set
        if (spawnRate > 0) {
            // spawns spawnRate enemies every second
            if (lastSpawnTime + 1 / spawnRate < Time.time) {
                lastSpawnTime = Time.time;
                SpawnEnemy();
            }
        }
    }


    protected virtual void SpawnEnemy() {
        GameObject newEnemy;

        Vector3 spawnPosition = transform.position;
        spawnPosition += new Vector3(0, Random.Range(-spawnWidth, spawnWidth), 0);

        if (whichSpawner == 1) {
            newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().SetDirection(Vector2.right);                 // left spawner creates enemies that move right
        } else {
            newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().SetDirection(Vector2.left);                 // right spawner creates enemies that move left
        }   
        
    }


    /// Helper function called by unity to draw gizmos for debugging and orientation in the scene view. Is not part of any game logic.
	void OnDrawGizmos(){
		Gizmos.DrawLine (transform.position - new Vector3 (0, spawnWidth, 0), transform.position + new Vector3 (0, spawnWidth, 0));
		Gizmos.DrawLine (transform.position - new Vector3 (1, spawnWidth, 0), transform.position - new Vector3 (-1, spawnWidth, 0));
		Gizmos.DrawLine (transform.position + new Vector3 (1, spawnWidth, 0), transform.position + new Vector3 (-1, spawnWidth, 0));
	}
}