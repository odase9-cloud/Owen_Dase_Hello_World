using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public KeyCode teleportKey;

    public KeyCode escapeKey;

    private Transform tf; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(teleportKey)) 
        {
         float randomX = Random.Range(minX, maxX);
         float randomY = Random.Range(minY, maxY);

            tf.position = new Vector3(randomX, randomY, 0.0f);
        }
        if (Input.GetKeyDown(escapeKey)) 
        {
            Application.Quit();        
        }
    }
}
