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
        bool traverseLeft = UnityEngine.Input.GetKeyDown(KeyCode.Q);
        bool traverseRight = UnityEngine.Input.GetKeyDown(KeyCode.E);
        int value = 0;

        if (traverseLeft) value = -1;
        if (traverseRight) value = 1;

        Input = new FrameInput
        {
            JumpDown = UnityEngine.Input.GetButtonDown("Jump"),
            JumpUp = UnityEngine.Input.GetButtonUp("Jump"),
            X = UnityEngine.Input.GetAxisRaw("Horizontal"),
            NormalAttack = UnityEngine.Input.GetMouseButtonDown(0),
            Talking = UnityEngine.Input.GetKeyDown(KeyCode.F),
            ChangeTransform = value
        };
    }
}
