using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Button : MonoBehaviour
{
    [SerializeField] private GameObject pause_menu;

    public void PauseButton()
    {
        
        if (pause_menu.activeSelf == true )
        {
            pause_menu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pause_menu.SetActive(true);
            Time.timeScale = 0;
        }    
        
    }
    public void RestarLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
