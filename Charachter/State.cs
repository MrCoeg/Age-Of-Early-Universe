using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual void enterHandleState(StateMachine stateMachine)
    {

    }

    public virtual void inputHandleState(StateMachine stateMachine)
    {
    }

    public virtual void updateHandleState(StateMachine stateMachine)
    {

    }

    public virtual void exitHandleState(StateMachine stateMachine)
    {

    }
}
