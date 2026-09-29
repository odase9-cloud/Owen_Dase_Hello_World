using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public override void Start()
    {

    }
    public override void Update()
    {

    }
    public override void MakeDecisions()
    {
        if (Input.GetKey(KeyCode.moveForwardKey))
        {

        }
        if (Input.GetKey(KeyCode.moveBackwardKey))
        {

        }
        if (Input.GetKey(KeyCode.rotateClockwiseKey))
        {

        }
        if (Input.GetKey(KeyCode.rotateCounterClockwiseKey))
        {

        }
    }
}
