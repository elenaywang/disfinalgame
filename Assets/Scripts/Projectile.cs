using UnityEngine;
using System.Collections;


public class Projectile : MonoBehaviour
{

    public float speed = 5;
	public float lifeTime = 3;
	public Vector2 direction = Vector2.right;		// default direction


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		// playerAnim = player.GetComponent<PlayerAnimation>();
		// if (playerAnim.facingRight) {
		// 	direction = Vector2.right;
		// } else {
		// 	direction = Vector2.left;
		// }
		// normalize direction so it does not impact the travel speed
		direction.Normalize();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (direction.x, direction.y, 0) * speed * Time.deltaTime;
		
		lifeTime -= Time.deltaTime;
		if(lifeTime <= 0){
			Destroy(gameObject);
		}
    }


    void OnTriggerEnter2D (Collider2D other)
	{
		Enemy enemy = other.GetComponent<Enemy>();
		if (enemy != null) { 		// checks if we hit the enemy
			enemy.OnHit(); 			// notify the enemy it got hit
			Destroy(gameObject); 	// destroy this projectile
		}
	}


	// sets the direction from the PlayerAttack script
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
}
