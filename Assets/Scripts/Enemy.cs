using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 1;
    // public GameObject enemyDeathPrefab;

    Vector2 direction = new Vector2();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = new Vector2(1,0);
		// normalize direction so it does not impact the travel speed
		direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
    }

    /// evaluates a hit on the asteroid. Is called by another instance when it collides with the asteroid.
    public void OnHit(){ 
        // Instantiate(enemyDeathPrefab, transform.position, transform.rotation);
        // TODO: death animation
        Destroy(gameObject);
    }
}
