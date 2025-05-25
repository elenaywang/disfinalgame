using UnityEngine;
using UnityEngine.SceneManagement; 


public class VaultHealth : MonoBehaviour
{

    public int maxHealth = 16;
	public int currentHealth;

	public EnergyBar healthBar;

    public Sprite[] vaultAnim;
    public GameObject vault;
    private SpriteRenderer sr;
    private int frameIndex = 0;     // for vault animation


    void Start()
    {
        currentHealth = maxHealth;
		healthBar.SetMaxEnergy(maxHealth);

        sr = vault.GetComponent<SpriteRenderer>();
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

        // vault animation
        if (currentHealth > 0 && currentHealth % 2 == 0) {
            frameIndex++;
            sr.sprite = vaultAnim[frameIndex];
        }
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
