using UnityEngine;

public class NoxEnergy : PlayerEnergy
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        currentEnergy = maxEnergy/2;
        energyBar.SetMaxEnergy(maxEnergy);
        inputSleep = KeyCode.Tab;
    }

}
