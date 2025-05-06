using UnityEngine;
using System;
using System.Globalization;
using UnityEngine.SceneManagement; 


// MODIFIED FROM: Comp-3 Interactive https://youtu.be/Y_AOfPupWhU?si=x2i-JWlNpj5-3Xjy 

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged; 
    public static Action OnHourChanged; 

    public static DateTime gameTime;            // for storing the time within the game
    public static int Minute { get; private set; }
    public static int Hour { get; private set; }

    private float tenMinToRealTime = 1f;        // each real world second is 10 min in game time
    private float timer;                        // for tracking real world seconds


    void Start()
    {
        gameTime = new DateTime(2025, 1, 1, 8, 0, 0, new GregorianCalendar());
        Minute = gameTime.Minute;
        Hour = gameTime.Hour;
        timer = tenMinToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            gameTime = gameTime.AddMinutes(10);
            Minute = gameTime.Minute;
            OnMinuteChanged?.Invoke();

            if (gameTime.Hour != Hour) {
                Hour = gameTime.Hour;
                OnHourChanged?.Invoke();
            }

            timer = tenMinToRealTime;
        }

        // end game after 3 days
        if (gameTime.Equals(new DateTime(2025, 1, 4, 8, 0, 0, new GregorianCalendar()))) {
            Time.timeScale = 1f;
            SceneManager.LoadScene("WinScreen");
        }
    }

}
