using System.IO;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;


// CREDIT: Brackeys https://youtu.be/BLfNP4Sc_iA?si=IqENoMUrI9NdiDrx

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    
    public void SetMaxEnergy(int energy) {
        slider.maxValue = energy;
        slider.value = energy;

        // change color of energy bar's fill
        fill.color = gradient.Evaluate(1f);
    }

    public void SetEnergy(int energy) {
        slider.value = energy;

        // change color of energy bar's fill
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
