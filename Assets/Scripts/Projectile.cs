using UnityEngine;
using System.Collections;


public class Projectile : MonoBehaviour
{

    public float speed = 2;
	public float lifeTime = 3;
	public Vector2 direction = new Vector2 (1, 0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // normalize direction so it does not impact the travel speed
		direction.Normalize ();
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
		if (enemy != null) { // checks if we hit the enemy
			enemy.OnHit (); // notify the enemy it got hit
			Destroy (gameObject); // destroy this projectile
		}
	}
}
