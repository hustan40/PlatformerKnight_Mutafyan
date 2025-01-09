using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Перменные за перемещение")]
    [SerializeField] private int jumpForce;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float overlapRad, speedMove;
   
    [Header("Настройки")]
    [SerializeField] private Transform groundTrans;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private GameObject sword;
    [SerializeField] private AudioSource sound, sound_hit;

    private Animator anim;
    private Rigidbody2D rb;
    private float time_attack;
    private bool left = false;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosistion = groundTrans.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosistion, overlapRad, groundMask);
        if (rb.velocity.y < - 0.5f)
        {
            anim.SetBool("Fall", true);
        }
        else
        {
            anim.SetBool("Fall", false);
        }

        if(time_attack < 1)
        {
            time_attack += Time.deltaTime;
        }
        
        if (sword.activeSelf == true && time_attack > 0.3f)
        {
            sword.SetActive(false);
        }
    }

    public void Move(float direction, bool jumpBut, bool fireBut)
    {
        if (jumpBut)
        {
            Jump();
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }

        if (fireBut)
        {
            anim.SetBool("Attack", true);
            sword.SetActive(true);
            time_attack = 0;
        }
        else
        {
            anim.SetBool("Attack", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            sound_hit.Play();
        }

        if (Mathf.Abs(direction) > 0.01f)
        {
            HorizontalMovement(direction);

            if (isGrounded)
            {
                anim.SetBool("Horiz", true);
            }
        }
        else
        {
            anim.SetBool("Horiz", false);
        }

        if (direction <= -0.1f)
        {
            left = true;
        }

        if (direction >= 0.1f)
        {
            left = false;
        }


        if (direction < 0 || left) 
        { 
            transform.localScale =  new Vector2(-5, 5);
        }
        else
        {
            transform.localScale = new Vector2(5, 5);
        }
        
    }
    private void Jump()
    {
        if (isGrounded)
        {
            sound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }
    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(curve.Evaluate(direction) * speedMove, rb.velocity.y);  
    }
}

