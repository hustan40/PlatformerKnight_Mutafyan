using UnityEngine;
using UnityEngine.UI;

public class Health_Other : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    //[SerializeField] private Image healt_bar;
    [SerializeField] private GameObject toDestroy;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource sound_death;
    private float currentHealth;
    public bool isAlive = true;

    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
        //healt_bar.fillAmount = currentHealth / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //healt_bar.fillAmount = currentHealth / maxHealth;
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
            anim.SetTrigger("Hit");
        }
        else if(isAlive == true)
        {
            isAlive = false;
            anim.SetTrigger("Death");
            sound_death.Play();
            Destroy(toDestroy);
        }

    }
}
