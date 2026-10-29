using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime;
    public float forceAmount;
    public Rigidbody2D rb;
    public float damageAmount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.AddForce(transform.up * forceAmount, ForceMode2D.Impulse);
        }

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damageAmount);
            Destroy(gameObject);
            return;
        }
        Death death = collision.GetComponent<Death>();

        if (death != null)
        {
            death.Die();
            Destroy(gameObject);
        }
    }
}