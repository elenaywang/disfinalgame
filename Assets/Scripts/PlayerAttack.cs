using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerAttack : MonoBehaviour {

    public KeyCode shootButton;
    public float rateOfFire = 1;    // how fast it shoots
    public GameObject projectilePrefab;

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
}
