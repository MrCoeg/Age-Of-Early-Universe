using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State currentState { get; protected set; }

    protected void ChangeStates(State newState)
    {
        currentState = newState;
    }
}


