using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime;
    public float forceAmount;
    public Rigidbody2D rb; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null )
        {
            rb.AddForce(transform.up * forceAmount, ForceMode2D.Impulse);
        }
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
