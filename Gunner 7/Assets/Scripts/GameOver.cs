using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;//Game object for script
    [SerializeField] GameObject mainUI;

    public void gameOver() //sets the ui on and allows user to use clicker
    {
        gameOverUI.SetActive(true);
        mainUI.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart() //button to restart the game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //loads the game from the start
        Time.timeScale = 1f;
    }

    public void MainMenu() //button to go back to main menu
    {
        SceneManager.LoadScene(0); //goes back to the main menu (Scene 0)
        Time.timeScale = 1f;
    }
}
