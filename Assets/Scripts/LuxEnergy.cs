using UnityEngine;


// written with some help from Claude AI

public class LuxEnergy : PlayerEnergy
{

    [Header("Time-based Energy Settings")]
    public int dayEnergyLoss = 15;          // 8am-11pm
    public int nightEnergyLoss = 80;        // 11pm-8am

    [Header("Energy Calculation")]
    public float maxEnergyHour = 8;         // max energy at 8am
    public float minEnergyHour = 23;        // min energy at 11pm
    private const float HOURS_IN_DAY = 24f;     // hours in a full day cycle


    public override void Initialize() {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
        inputSleep = KeyCode.Return;

        // Initialize base rates
        BaseEnergyLossRate = dayEnergyLoss;
    }


    protected override int CalculateEnergyLossRate() {
        int hour = TimeManager.Hour;

        // energy loss rates at different times of day

        // morning (8am-11pm)
        if (hour >= maxEnergyHour && hour < minEnergyHour) {
            return dayEnergyLoss;
        }

        // night (11pm-8am)
        else{
            return nightEnergyLoss;
        }
    }

}
