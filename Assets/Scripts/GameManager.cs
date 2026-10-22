using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController playerController;
    public List<astriod> asteriodList;
    public int score;

    public void AddToScore(int scoreToAdd)
    {
      score = score + scoreToAdd;
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        asteriodList = new List<astriod>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.pawn == null)
        {
            Debug.Log("Failure");
        }
        asteriodList.RemoveAll(asteroid => asteroid == null);
        if (asteriodList.Count == 0)
        {
            Debug.Log("Victory");
        }
    }
    
    

}
