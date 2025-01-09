using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private float speed, time_to_Revert, scale;
    [SerializeField] private Danage_Deak dmg;
    [SerializeField] private Health_Other hp;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform scale_Enemy;

    private const byte IDLE_STATE = 0;
    public const byte WALK_STATE = 1;
    private const byte REVERT_STATE = 2;
    private const byte ATTACK_STATE = 3;
    private const byte DEATH_STATE = 4;

    public byte current_state;
    private float current_time;


    private void Start()
    {
        current_state = WALK_STATE; 
        current_time = 0;
        scale_Enemy.transform.localScale = new Vector2(scale, Mathf.Abs(scale));
    }


    private void Update()
    {
        if (current_time >= time_to_Revert)
        {
            current_time = 0;
            current_state = REVERT_STATE;
        }

        if (dmg.stay == true)
        {
            current_state = ATTACK_STATE;
        }

        if (dmg.stay == false & current_state == ATTACK_STATE) 
        {
            current_state = REVERT_STATE;
        }

        if (hp.isAlive == false)
        {
            current_state = DEATH_STATE;
        }


        switch (current_state)
        {
            case IDLE_STATE:
                current_time += Time.deltaTime;
                animator.SetBool("Walk",false);
                break;
            case WALK_STATE:
                rb.velocity = Vector2.right * speed;
                animator.SetBool("Walk", true);
                break;
            case REVERT_STATE:
                scale *= -1;
                speed *= -1;
                scale_Enemy.localScale = new Vector2(scale, Mathf.Abs(scale));
                animator.SetBool("Walk", false);
                current_state = WALK_STATE;
                break;
            case ATTACK_STATE:
                rb.velocity = Vector2.zero;
                animator.SetBool("Walk", false);
                break;
            case DEATH_STATE:
                Destroy(rb);
                animator.SetTrigger("Death");
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper"))
        {
            current_state = IDLE_STATE; 
        }
        if (collision.CompareTag("Player"))
        {
            current_state = ATTACK_STATE;
        }
    }
}
