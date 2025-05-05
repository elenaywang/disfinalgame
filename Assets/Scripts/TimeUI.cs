using TMPro;
using UnityEngine;


// MODIFIED FROM: Comp-3 Interactive https://youtu.be/Y_AOfPupWhU?si=x2i-JWlNpj5-3Xjy 

public class TimeUI : MonoBehaviour
{
    
    public TextMeshProUGUI timeText;


    private void OnEnable() {
        TimeManager.OnMinuteChanged += UpdateTime;
        TimeManager.OnHourChanged += UpdateTime;
    }

    private void OnDisable() {
        TimeManager.OnMinuteChanged -= UpdateTime;
        TimeManager.OnHourChanged -= UpdateTime;
    }

    private void UpdateTime() {
        timeText.text = $"{TimeManager.gameTime.ToShortTimeString()}";
    } 
}
