using UnityEngine;
using System;
using Mono.Cecil.Cil;
using System.Globalization;
using TMPro;


// MODIFIED FROM: Comp-3 Interactive https://youtu.be/Y_AOfPupWhU?si=x2i-JWlNpj5-3Xjy 

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged; 
    public static Action OnHourChanged; 

    public static DateTime gameTime;            // for storing the time within the game
    public static int Minute { get; private set; }
    public static int Hour { get; private set; }

    private float quarterhourToRealTime = 1f;   // each real world second is 15 min in game time
    private float timer;                        // for tracking real world seconds


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameTime = new DateTime(2025, 1, 1, 8, 0, 0, new GregorianCalendar());
        Minute = gameTime.Minute;
        Hour = gameTime.Hour;
        timer = quarterhourToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            gameTime = gameTime.AddMinutes(15);
            OnMinuteChanged?.Invoke();

            if (Minute >= 60) {
                gameTime = gameTime.AddHours(1);
                Minute = 0; 
                OnHourChanged?.Invoke();
            }

            timer = quarterhourToRealTime;
        }

        // Debug.Log(gameTime);
    }

}
