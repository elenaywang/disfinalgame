using UnityEngine;
using UnityEngine.SceneManagement;


// CREDIT: Brackeys https://youtu.be/zc8ac_qUXQY?si=UAwR5RGT-fQ-p8o6
public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }


    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
