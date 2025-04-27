using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public float spawnWidth = 1;
    public float spawnRate = 1;
    public GameObject enemyPrefab;

    private float lastSpawnTime = 0;



    // Update is called once per frame
    void Update()
    {
         // spawns spawnRate asteroids every second
        if (lastSpawnTime + 1 / spawnRate < Time.time) {
            lastSpawnTime = Time.time;
            Vector3 spawnPosition = transform.position;
            spawnPosition += new Vector3(0, Random.Range(-spawnWidth, spawnWidth), 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);        			// creates a new GameObject copy (clone) from a Prefab at a specific location and orientation.
        }
    }


    void ChangeSpawnRate() {
        // adjust spawn rate with array? check for tutorials
    }


    /// Helper function called by unity to draw gizmos for debugging and orientation in the scene view. Is not part of any game logic.
	void OnDrawGizmos(){
		Gizmos.DrawLine (transform.position - new Vector3 (0, spawnWidth, 0), transform.position + new Vector3 (0, spawnWidth, 0));
		Gizmos.DrawLine (transform.position - new Vector3 (1, spawnWidth, 0), transform.position - new Vector3 (-1, spawnWidth, 0));
		Gizmos.DrawLine (transform.position + new Vector3 (1, spawnWidth, 0), transform.position + new Vector3 (-1, spawnWidth, 0));
	}
}
