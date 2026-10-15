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
    public KeyCode shootKey; 
    public override void Start()
    {
        GameManager gm = GameManager.instance;
        if (gm != null) 
        {
            gm.playerController = this;
        }
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
            pawn.Rotate(-pawn.rotateSpeed); 
        }
        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.Rotate(pawn.rotateSpeed);
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
        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
        }
    }
    public override void MakeDecisions()
    {
       
    }
}
