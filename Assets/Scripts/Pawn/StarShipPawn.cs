using UnityEngine;

public class StarShipPawn : Pawn
{
    private Transform tf;
    public KeyCode turbo;

    public override void Start()
    {
        tf = GetComponent<Transform>(); 
    }

    public override void Update()
    {
        
    }
    public override void Move(Vector3 direction)
    {
            tf.position = tf.position + direction.normalized * moveSpeed * Time.deltaTime;
    }

    public override void MoveWorldSpace(Vector3 direction)
    {
        tf.position = tf.position + direction.normalized;
    }

    public override void Teleport()
    {
      
    }

    public override void Rotate(float speed)
    {
        tf.Rotate(0.0f, 0.0f, speed * Time.deltaTime);
    }
}
