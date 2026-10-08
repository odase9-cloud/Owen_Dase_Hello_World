using UnityEngine;

public class DeathVolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Death death = collision.GetComponent<Death>();

        if (death != null)
        {
            death.Die();
        }
    }
}
