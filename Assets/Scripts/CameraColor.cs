using UnityEngine;


// MODIFIED FROM: Into The 3D https://youtu.be/gaFbwu1e0rI?si=wzFPSmxdfmP7bTeK

public class CameraColor : MonoBehaviour
{
    [SerializeField] private Camera cameraRef;
    [SerializeField] private Color[] colors;
    [SerializeField] private float colorChangeSpeed = 0.7f;


    private void Awake()
    {
        cameraRef = Camera.main;
        cameraRef.backgroundColor = colors[0];      // initialize starting background color
    }


    void Update()
    {
        ColorChangeTime();
    }


    private void ColorChange(int index) {
        cameraRef.backgroundColor = Color.Lerp(cameraRef.backgroundColor, colors[index], colorChangeSpeed * Time.deltaTime);
    }


    private void ColorChangeTime() {
        int hour = TimeManager.Hour;

        if (hour == 20) {
            // sunset at 8pm -- change to the second color in colors array
            ColorChange(1);
        } else if (hour == 7) {
            // sunrise at 7am -- change color to the first color in colors array
            ColorChange(0);
        }
    }
}
