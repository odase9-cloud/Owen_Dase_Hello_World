using UnityEngine;

public class ShooterBullet : Shooter
{
    public GameObject BulletPrefab;
    public Transform bulletSpawnPoint;
    public AudioSource audioSource;
    public override void Shoot()
    {
        if (audioSource != null)
        {
            
                audioSource.Play();
            
        }
        Instantiate(BulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
