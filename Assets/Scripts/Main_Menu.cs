using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    [SerializeField] GameObject selectd_lvl, main_menu;

    public void Lvl_sel_menu()
    {
        selectd_lvl.SetActive(true);
        main_menu.SetActive(false);
    }

    public void Main_menu()
    {
        selectd_lvl.SetActive(false);
        main_menu.SetActive(true);
    }

    public void Lvl_Sel(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void Quit_Game()
    {
        Application.Quit();
    }
}
