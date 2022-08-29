using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class PlayerInput : MonoBehaviour
{
    public FrameInput Input { get; private set; }
    private void Update()
    {
        GatherInput();
    }

    private void GatherInput()
    {
        Input = new FrameInput
        {
            JumpDown = UnityEngine.Input.GetButtonDown("Jump"),
            JumpUp = UnityEngine.Input.GetButtonUp("Jump"),
            X = UnityEngine.Input.GetAxisRaw("Horizontal"),
            NormalAttack = UnityEngine.Input.GetMouseButtonDown(0),
            Talking = UnityEngine.Input.GetKeyDown(KeyCode.F)
        };
        InputDebug();
    }

    private void InputDebug()
    {
/*        if (Input.JumpDown)
        {
            Debug.Log("Jump");
        }

        if (Input.JumpUp)
        {
            Debug.Log("Jump Up");
        }

        if (Input.X != 0)
        {
            Debug.Log("Move");
        }

        if (Input.NormalAttack)
        {
            Debug.Log("Normal Attack");
        }*/
    }
}
