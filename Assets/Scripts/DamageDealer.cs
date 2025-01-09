
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") )
        {
            collision.gameObject.GetComponent<Health_Other>().TakeDamage(damage);
        }
        
    }
}
