using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <para>An abstract implementation of a state machine. The specific state machine implemented in the project are derived from this. </para>
/// NOTE: in unity life cycle there are a several updates in a frame. 
/// Update called in the beginning of a frame,
/// FixedUpdate and LateUpdate that are called later on in a frame.
/// There are a way of separating logic so that everything runs smoothly and in the proper order.
/// <para>To mimic this, we will have 2 types of update methods.</para>
/// </summary>
public class StateMachine : MonoBehaviour
{
    BaseState currentState;

    /// <summary>
    /// Gets the initial state and enters it.
    /// </summary>
    void Start()
    {
        currentState = GetInitialState();
        if(currentState != null)
        {
            currentState.Enter();
        }
    }

    /// <summary>
    /// Update the logic in a current state 
    /// </summary>
    void Update()
    {
        if(currentState != null)
        {
            currentState.UpdateLogic();
        }
    }

    /// <summary>
    /// Update the physics in a current state 
    /// </summary>
    void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();
        }
    }

    /// <summary>
    /// Exit one state, assign new state and enter it. 
    /// </summary>
    public void ChangeState(BaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    /// <summary>
    /// Get the initial state of the state machine. Should be implemented in the derived state machine. 
    /// </summary>
    protected virtual BaseState GetInitialState()
    {
        return null;
    }
}
