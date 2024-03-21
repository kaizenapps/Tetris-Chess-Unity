using UnityEngine;
using System.Collections;

using Tetris.Engine;

public class PlayControls : MonoBehaviour
{
    private ManagerUser manager;

    void Start()
    {
        this.manager = this.GetComponent<ManagerUser>();
    }

    void Update()
    {
        var horizontalMovement = Vector3.left * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        if (Input.GetKeyDown("left")) //(horizontalMovement.x > 0)
        {
            this.manager.MoveBlock(Move.Left);
        }
        else if (Input.GetKeyDown("right")) //(horizontalMovement.x < 0)
        {
            this.manager.MoveBlock(Move.Right);
        }

        if (Input.GetKeyDown("up"))
        {
            this.manager.MoveBlock(Move.RotateLeft);
        }

        if (Input.GetKeyDown("down"))
        {
            this.manager.MoveBlock(Move.Fall);
        }
    }
}
