
using UnityEngine;

public class astriod : MonoBehaviour

{
    public float damageAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GameManager gm = GameManager.instance;

        if (gm != null && gm.asteriodList != null &&
            !gm.asteriodList.Contains(this))
        {
            gm.asteriodList.Add(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<astriod>() != null)
            return;

        Health health = collision.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damageAmount);
        }
    }

}

