using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameOverMenu : MonoBehaviour
{
    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Loaded main menu from game over menu");
    }

    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
