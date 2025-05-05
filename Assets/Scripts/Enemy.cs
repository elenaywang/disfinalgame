using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 0.5f;
    
    [Tooltip("Which player can kill this enemy")]
    public float player;                // 1 is Lux, 2 is Nox

    Vector2 direction = Vector2.right;  // default direction


    void Start()
    {
		// normalize direction so it does not impact the travel speed
		direction.Normalize();
    }

    void Update()
    {
        transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
    }

    // sets the direction from the EnemySpawner script
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    /// evaluates a hit on the enemy. Is called by another instance when it collides with the enemy.
    public void OnHit(){ 
        Destroy(gameObject);
    }
}
