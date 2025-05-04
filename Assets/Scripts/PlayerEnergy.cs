using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{

    public int maxEnergy = 100;
    public int currentEnergy;
    public EnergyBar energyBar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
    }


    // Update is called once per frame
    void Update()
    {
        // determine when player's energy decreases
    }


    void LoseEnergy(int energy) {
        currentEnergy -= energy;
        energyBar.SetEnergy(currentEnergy);
    }
}
