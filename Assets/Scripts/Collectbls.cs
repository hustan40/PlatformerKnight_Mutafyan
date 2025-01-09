using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectbls : MonoBehaviour
{
    [SerializeField] Score_Lvl score;
    [SerializeField] private AudioSource sound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            score.collect = true;
            sound.Play();
            Destroy(gameObject);
        }
    }
}
