using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>BaseState</c> is a blueprint or pattern for all the actual states that are going to inherit from this class
/// </summary>
public class BaseState
{
    /// <summary>
    /// perform all initializations needed when transition to the state
    /// </summary>
    public virtual void Enter() { }

    /// <summary>
    /// <para>perform the logic of the state and happens continuously while entity in this state. </para>
    /// <remarks>
    /// in unity life cycle there are a several updates in a frame. <c>Update</c> called in the beginning of a frame,
    /// <c>FixedUpdate</c> and <c>LateUpdate</c> that are called later on in a frame.
    /// There are a way of separating logic so that everything runs smoothly and in the proper order.
    /// To mimic this, we will have 2 types of update methods.
    /// </remarks>
    /// </summary>
    public virtual void UpdateLogic() { }

    /// <summary>
    /// <para>perform the physics of the state and happens continuously while entity in this state. </para>
    
    /// </summary>
    public virtual void UpdatePhysics() { }

    /// <summary>
    /// perform all cleanups needed when transition from the state
    /// </summary>
    public virtual void Exit() { }
}
