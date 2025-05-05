using UnityEngine;
using UnityEngine.SceneManagement; 


public class VaultHealth : MonoBehaviour
{

    public int maxHealth = 10;
	public int currentHealth;

	public EnergyBar healthBar;


    void Start()
    {
        currentHealth = maxHealth;
		healthBar.SetMaxEnergy(maxHealth);
    }


    void Update()
    {
        // check if the vault is dead
        if (currentHealth <= 0) {
            Time.timeScale = 1f;
            SceneManager.LoadScene("GameOver");
        }
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetEnergy(currentHealth);
    }


    void OnTriggerEnter2D (Collider2D other)
	{
		Enemy enemy = other.GetComponent<Enemy>();
		if (enemy != null) { 		    // checks if the enemy hit the center line
            enemy.OnHit(); 			    // notify the enemy it got hit
            TakeDamage(1);
		}
	}
}
