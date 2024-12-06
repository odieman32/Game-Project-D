using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YouWin : MonoBehaviour
{
    public GameObject winUI; //game object to use Win UI
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player") //if box collider touches player then the following will happen
        {
            winUI.SetActive(true); //win ui is set to true
            Time.timeScale = 0; //time will stop
            Cursor.lockState = CursorLockMode.None; //cursor is unlocked
            Cursor.visible = true; //cursor is visable
        }
    }
    public void MainMenu() //button to go back to main menu
    {
        SceneManager.LoadScene(0); //loads the Main Menu 
        Time.timeScale = 1f; //Sets time to normal
    }
}
