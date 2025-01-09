
using UnityEngine;

public class Damage_Enemy : MonoBehaviour
{
    [SerializeField] private float damage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

    }
}
