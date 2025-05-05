using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{

    public int maxEnergy = 5000;
    public int currentEnergy;
    public EnergyBar energyBar;

    public bool isAwake = true;
    public KeyCode inputSleep;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
    }


    // Update is called once per frame
    void Update()
    {
        // activate or deactivate sleep
        if (Input.GetKeyDown(inputSleep)) {
            if (isAwake) {
                isAwake = false;
            } else {
                isAwake = true;
            }
        }

        // fall asleep if energy depletes
        if (currentEnergy <= 0) {
            isAwake = false;
        }

        // wake up if energy is full
        if (currentEnergy >= maxEnergy) {
            isAwake = true;
        }

        // lose or gain energy depending on whether player is awake
        if (isAwake) {
            LoseEnergy(1);
        } else {
            IncreaseEnergy(2);
        }

        // determine when player's energy decreases
    }


    void LoseEnergy(int energy) {
        currentEnergy -= energy;
        energyBar.SetEnergy(currentEnergy);
    }


    void IncreaseEnergy(int energy) {
        currentEnergy += energy;
        energyBar.SetEnergy(currentEnergy);
    }
}
