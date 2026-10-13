using UnityEngine;

public class ShooterBullet : Shooter
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public override void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
