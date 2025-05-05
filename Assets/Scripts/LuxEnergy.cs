using UnityEngine;

public class LuxEnergy : PlayerEnergy
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
        inputSleep = KeyCode.Return;
    }

}
