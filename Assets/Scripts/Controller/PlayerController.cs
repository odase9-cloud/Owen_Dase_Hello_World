using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode teleportKey;
    public KeyCode escapeKey;
    public KeyCode moveForwardWorld;
    public KeyCode moveBackwardWorld;
    public KeyCode moveLeftWorld;
    public KeyCode moveRightWorld;
    public override void Start()
    {

    }
    public override void Update()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.Move(pawn.transform.up);
        }
        if (Input.GetKey(moveBackwardKey))
        {
            pawn.Move(-pawn.transform.up);
        }
        if (Input.GetKey(rotateClockwiseKey))
        {

        }
        if (Input.GetKey(rotateCounterClockwiseKey))
        {

        }
        if (Input.GetKeyDown(teleportKey))
        {

        }
        if (Input.GetKeyDown(moveForwardWorld))
        {
            pawn.MoveWorldSpace(Vector3.up);
        }
        if (Input.GetKeyDown(moveBackwardWorld))
        {
            pawn.MoveWorldSpace(-Vector3.up);
        }
        if (Input.GetKeyDown(moveRightWorld))
        {
            pawn.MoveWorldSpace(Vector3.right);
        }
        if (Input.GetKeyDown(moveLeftWorld))
        {
            pawn.MoveWorldSpace(-Vector3.right);
        }
    }
    public override void MakeDecisions()
    {
       
    }
}
