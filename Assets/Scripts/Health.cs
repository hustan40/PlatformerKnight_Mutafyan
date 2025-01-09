using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healt_bar;
    [SerializeField] private GameObject restart_Button;
    [SerializeField] private AudioSource sound_death;
    private float currentHealth;
    private bool isAlive = true;
    private PlayerInput playerInput;
    private Animator anim;


    private void Awake()
    {
        currentHealth = maxHealth;
        healt_bar.fillAmount = currentHealth / maxHealth;
        isAlive = true;
        playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        healt_bar.fillAmount = currentHealth/maxHealth;
        
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
            anim.SetTrigger("TakeDamage");
        }
        else if (isAlive == true)
        {
            isAlive = false;
            anim.SetBool("Death",true);
            sound_death.Play();
            playerInput.isAliveMov = false;
            restart_Button.gameObject.SetActive(true);
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
