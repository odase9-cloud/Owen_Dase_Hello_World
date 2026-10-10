using UnityEngine;

public class astriod : MonoBehaviour
    
{
    public float damageAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with" + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     Health health = collision.GetComponent<Health>();
       if (health != null)
        {
          health.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
        
    }
}
