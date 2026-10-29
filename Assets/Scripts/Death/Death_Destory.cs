using UnityEngine;

public class Death_Destory : Death
{
    public int scoreToAdd;
   
    
    public override void Die()
    {

        if (GameManager.instance != null)
        {
            GameManager.instance.AddToScore(scoreToAdd);
        }
        Destroy(gameObject);
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
