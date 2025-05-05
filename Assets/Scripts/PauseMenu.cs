using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; 


// CREDIT: Brackeys https://youtu.be/JivuXdrIHK0?si=hY-hF44npcNaP-Ya

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; 

    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }


    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void LoadMenu() {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Loaded main menu from pause menu");
    }


    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
