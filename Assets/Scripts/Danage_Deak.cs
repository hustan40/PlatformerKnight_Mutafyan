using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danage_Deak : MonoBehaviour
{
    [SerializeField] private GameObject deal_Damage;
    [SerializeField] private Animator anim;
    [SerializeField] private float time_to_attack;
    [SerializeField] private AudioSource sound;
    private float time_attack = 0;
    public bool stay = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            stay = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            stay = false;
        }
    }

    private void FixedUpdate()
    {
        
        if (stay == true)
        {
            time_attack += Time.deltaTime;
        }
        else
        {
            time_attack = 0;
        }

        if (time_attack > time_to_attack)
        {
            deal_Damage.SetActive(true);
            sound.Play();
            anim.SetTrigger("Attack");
            time_attack = 0;
        }

        if (time_attack > 0.1f && time_attack < 0.2f)
        {
            deal_Damage.SetActive(false);
        }

    }
}

