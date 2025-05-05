using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerAttack : MonoBehaviour {

    public KeyCode shootButton;
    public float rateOfFire = 1;    // how fast it shoots
    public GameObject projectilePrefab;
    // public GameObject explosionPrefab;
    // public AudioClip laserSound;

    private float lastTimeFired = 0;
	private bool isDead = false;
    private PlayerAnimation playerAnim;
    private PlayerEnergy pe;


    void Start()
    {
        playerAnim = GetComponent<PlayerAnimation>();
        pe = GetComponent<PlayerEnergy>();
    }


    /// checks if it should fire
    void Update() {

		if(isDead) return;
        if (!pe.isAwake) return;           // player doesn't attack if sleeping

        // if the fire button is pressed and we waited long enough since the last shot was fired, FIRE!
        if (Input.GetKey(shootButton) && (lastTimeFired + 1 / rateOfFire) < Time.time) {
            lastTimeFired = Time.time;
            Attack();
        }
    }


    // what happens when the player hits the enemy or enemy's attack
    void OnTriggerEnter2D(Collider2D other){

        // end game if player hits enemy
        if(other.GetComponent<Enemy>() != null)
        {
            // Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // TODO: dying animation


			// // load the active scene again, to restard the game. The GameManager will handle this for us. We use a slight delay to see the explosion.
			// StartCoroutine(RestartTheGameAfterSeconds(1));
			// we can not destroy the spaceship since it needs to run the coroutine to restart the game.
			// instead, disable update (isDead = true) and remove the renderer to "hide" the object while we reload.
			isDead = true;
			Destroy(GetComponent<SpriteRenderer>());
        }
    }


	/// shooting projectiles
    void Attack(){
        // AudioSource.PlayClipAtPoint(laserSound, transform.position);

        GameObject projectile;
        
        if (playerAnim.facingRight) {
            projectile = Instantiate(projectilePrefab, transform.position + Vector3.right, Quaternion.identity);
            projectile.GetComponent<Projectile>().SetDirection(Vector2.right);
        } else {
            projectile = Instantiate(projectilePrefab, transform.position + Vector3.left, Quaternion.identity);
            projectile.GetComponent<Projectile>().SetDirection(Vector2.left);
        }
    }


	// /// <summary>
	// /// Wait seconds and reload current scene.
	// /// </summary>
	// IEnumerator RestartTheGameAfterSeconds(float seconds){
	// 	yield return new WaitForSeconds (seconds);
	// 	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	// }


    // // when player gets hit, the level restarts
    // public void DeathByRay() {
    //     ReloadScene();      // level restarts when player gets hit
    // }


    // private void ReloadScene() {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
}
