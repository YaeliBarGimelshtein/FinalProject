using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class BaseState is a blueprint or pattern for all the actual states that are going to inherit from this class.
/// It has 3 main methods - Enter, Update and Exit.
/// </summary>
public class BaseState
{
    public string name;
    protected StateMachine stateMachine;

    public BaseState(string stateName, StateMachine machine)
    {
        name = stateName;
        stateMachine = machine;
    }

    /// <summary>
    /// perform all initializations needed when transition to the state
    /// </summary>
    public virtual void Enter() { }

    /// <summary>
    /// perform the logic of the state and happens continuously while entity in this state. 
    /// </summary>
    public virtual void UpdateLogic() { }

    /// <summary>
    /// perform the physics of the state and happens continuously while entity in this state.
    /// </summary>
    public virtual void UpdatePhysics() { }

    /// <summary>
    /// perform all cleanups needed when transition from the state
    /// </summary>
    public virtual void Exit() { }
}
