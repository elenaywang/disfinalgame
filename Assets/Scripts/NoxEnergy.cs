using UnityEngine;


// written with some help from Claude AI

public class NoxEnergy : PlayerEnergy
{

    [Header("Time-based Energy Settings")]
    public int morningEnergyLoss = 60;      // 8am-2pm
    public int afternoonEnergyLoss = 30;    // 2pm-8pm
    public int eveningEnergyLoss = 10;      // 8pm-11pm
    public int nightEnergyLoss = 0;        // 11pm-5am (night boost period)
    public int lateNightEnergyLoss = 20;    // 5am-8am

    [Header("Energy Boost Settings")]
    public int nightBoostStartHour = 23;   // 11pm
    public int nightBoostEndHour = 5;      // 5am

    private bool hasReceivedNightBoost = false;

    public override void Initialize()
    {
        currentEnergy = maxEnergy/2;
        energyBar.SetMaxEnergy(maxEnergy);
        energyBar.SetEnergy(currentEnergy);
        inputSleep = KeyCode.Tab;

        // Initialize base rates
        BaseEnergyLossRate = morningEnergyLoss;
    }


    protected override void OnHourChanged()
    {
        // check for night energy boost when hour changes
        CheckNightEnergyBoost();
    }


    protected override int CalculateEnergyLossRate()
    {
        int hour = TimeManager.Hour;
        
        // Night boost period (11pm-5am)
        if ((hour >= nightBoostStartHour && hour < 24) || (hour >= 0 && hour < nightBoostEndHour)) {
            return nightEnergyLoss;
        }

        // late night period (5am-8am)
        else if (hour >= nightBoostEndHour && hour < 8) {
            return lateNightEnergyLoss;
        }

        // morning period (8am-2pm)
        else if (hour >= 8 && hour < 14) {
            return morningEnergyLoss;
        }

        // afternoon period (2pm-8pm)
        else if (hour >= 14 && hour < 20) {
            return afternoonEnergyLoss;
        }

        // Evening period (8pm-11pm)
        else {
            return eveningEnergyLoss;
        }
    }


    private void CheckNightEnergyBoost()
    {
        int currentHour = TimeManager.Hour;
        bool isNightTime = (currentHour >= nightBoostStartHour && currentHour < 24) || (currentHour >= 0 && currentHour < nightBoostEndHour);

        if (isNightTime)
        {
            // Night boost period
            if (!hasReceivedNightBoost)
            {
                // Apply the night boost
                currentEnergy = maxEnergy;
                energyBar.SetEnergy(currentEnergy);
                hasReceivedNightBoost = true;
                
                Debug.Log($"Nox received night energy boost at hour {currentHour}");
            }
        }
        else
        {
            // Reset the boost flag when outside night hours
            hasReceivedNightBoost = false;
        }
    }

}
