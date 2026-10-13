using UnityEngine;

public class ShooterBullet : Shooter
{
    public GameObject BulletPrefab;
    public Transform bulletSpawnPoint;
    public override void Shoot()
    {
        Instantiate(BulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
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
