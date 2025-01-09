using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score_Lvl : MonoBehaviour
{
    public bool collect = false;
    public byte enemy = 0, enemy_all = 0;
    public float time_lvl = 0;
    [SerializeField] private GameObject end_menu, next_lvl_but, end_game;
    [SerializeField] private Text time_txt,enemy_txt, enemy_all_txt, collect_txt;


    private void Awake()
    {
        GameObject[] objectsWithScript = GameObject.FindGameObjectsWithTag("Enemy");
        time_lvl = Time.time;
        foreach (GameObject obj in objectsWithScript)
        {
            enemy_all++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject[] objectsWithScript = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject obj in objectsWithScript)
            {
                Animator anim = obj.GetComponent<Animator>();
                if (anim.GetBool("Death") == true)
                {
                    enemy++;
                }
            }
            end_menu.SetActive(true);
            DisplayTime(Time.time- time_lvl);
            enemy_txt.text = enemy.ToString();
            enemy_all_txt.text = enemy_all.ToString();
            Time.timeScale = 0;

            if (collect == true)
            {
                collect_txt.text = ("✓"); 
            }
            else
            {
                collect_txt.text = ("X");
            }

            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                next_lvl_but.SetActive(false);
                end_game.SetActive(true);
            }
            else
            {
                next_lvl_but.SetActive(true);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        time_txt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    public void Next_Lvl()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void End_Game()
    {
        Application.Quit();
    }
}
