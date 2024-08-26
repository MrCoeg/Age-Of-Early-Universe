
# Snipping Code

## ✨ Base Abstract Class StateMachine and State

In any state-driven game architecture, it’s essential to have a flexible, scalable design. Below is the foundation of my state machine system, allowing characters to transition seamlessly between various states, such as idle, attacking, or transforming.
```csharp 
public abstract class State
{
    public string nameState { get; protected set; }
    public virtual void enterHandleState(StateMachine stateMachine){}
    public virtual void inputHandleState(StateMachine stateMachine){}
    public virtual void updateHandleState(StateMachine stateMachine){}
    public virtual void exitHandleState(StateMachine stateMachine){}
}

public abstract class StateMachine : MonoBehaviour
{
    public State currentState { get; protected set; }
    protected void ChangeStates(State newState){currentState = newState;}
}
```
The State class serves as the base for all specific states in the game, while StateMachine handles transitions between states. This design allows for dynamic behavior management with clear separation of concerns.


## ⚔️ CharacterStateMachine (State Machine Implementation)
Now, here’s an example of how i apply this state machine to a character. The character can dynamically switch between different states (such as fire transformation or idle), driven by input and internal game logic.

```csharp 
public class CharachterStateMachine : StateMachine
{
    private void Start()
    {
        currentState = new FireTransformIdle();
        playerInput = GetComponent<PlayerInput>()
        Input = playerInput.Input;
    }

    private void Update()
    {
        Input = playerInput.Input;
        currentState.inputHandleState(this);
        currentState.updateHandleState(this);
    }

    public void ChangeStateHandler(State newState)
    {
        currentState.exitHandleState(this);
        ChangeStates(newState);
        currentState.enterHandleState(this);
    }
}

```
In the CharachterStateMachine, each frame we evaluate the current state and handle input and logic accordingly. Changing states happens seamlessly with the ChangeStateHandler function, making the game feel fluid and responsive.

## 🔥 FireSkillFour — Ultimate Attack State (State Implementation)

In this state, the character performs a high-powered attack. The state machine transitions into FireSkillFour when the ultimate attack is activated, and transitions back to idle or movement states once the attack concludes or the player initiates movement.

- enterHandleState:

    Triggers the ultimate attack animation.
    Sets the character to an attacking state.

- inputHandleState:

    Continuously checks for player input to either maintain the attack or transition to movement.

    If no further attack is detected and movement input is given, it transitions to a movement state like FireMove.

    If the player does nothing, the character returns to an idle state (FireTransformIdle).

- exitHandleState:

    Resets important flags like isAttacking and isDashing to ensure that once the attack finishes, the character is back to a neutral state.

```csharp
public class FireSkillFour : State
{
    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        charachter.ChangeAnimation("Ultimate");
        charachter.isAttacking = true;
    }
    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = charachter.playerInput;

        if (charachter.isAttacking || playerInput.Input.NormalAttack)
        {
            return;
        }

        if (charachter.MovementDetected(new FireMove()))
        {
            return;
        }

        charachter.ChangeStateHandler(new FireTransformIdle());
    }

    public override void exitHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.isAttacking = false;
        character.comboCode = 0;
        character.isDashing = false;
    }

}
```

## ⚔️ Damage Handling
The provided code snippet demonstrates how to activate damage and apply it to enemies when they stay in contact with a certain game object.

```csharp
public void Activate(){activated = true;}

private void OnCollisionStay2D(Collision2D collision)
{
    if (collision.collider.gameObject.tag != "Enemy") return;
    if (activated)
    {
        activated = false;
        enemies.Add(collision.collider.gameObject.GetComponent<EnemyStateMachine>());
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null) continue;
            enemies[i].Damaged(charachter.damage, false, 0);
        }
        enemies.RemoveRange(0, enemies.Count - 1);
    }
}
```

- Activate Method: 
    Called by Unity’s Animation Event system to trigger damage application. 
- OnCollisionStay2D Method: 
    - Check Collision: Only processes collisions with objects tagged as "Enemy". 
    - Apply Damage: If activated, adds the enemy to a list and applies damage. Resets the activated flag and clears the list after applying damage.