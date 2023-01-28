using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStart;
using System;

public class AttackTeamNode : Node
{
    private Transform kingsCurrentLocation;
    private Transform kingsStarttingPosition;
    private Transform kingsTargetgPosition;
    public List<Soldier> soldiers;
    
    /// <summary>
    /// A constructor for creating the beighbor nodes
    /// </summary>
    /// <param name="node"></param>
    public AttackTeamNode(AttackTeamNode node, int move) 
    {
        gCost = node.gCost + 1;
        hCost = ComputeH();
        //change soldiers position and behavior according to the move
    }

    /// <summary>
    /// A constructor for creating the root node
    /// </summary>
    /// <param name="kingsCurrentLocation"></param>
    /// <param name="kingsStarttingPosition"></param>
    /// /// <param name="kingsTargetgPosition"></param>
    /// <param name="soldiers"></param>
    public AttackTeamNode(Transform kingsCurrentLocation, Transform kingsStarttingPosition, Transform kingsTargetgPosition,
        List<Soldier> soldiers)
    {
        this.kingsCurrentLocation = kingsCurrentLocation;
        this.kingsStarttingPosition = kingsStarttingPosition;
        this.kingsTargetgPosition = kingsTargetgPosition;
        this.soldiers = soldiers;

        gCost = 0;
        hCost = ComputeH();
    }
   
    public override int ComputeH()
    {
        float distance = Vector3.Distance(kingsCurrentLocation.position, kingsStarttingPosition.position);
        //calculate soldiers health
        return (int)Math.Round(distance);
    }

    public override bool TargetNodeFound()
    {
        return kingsCurrentLocation.Equals(kingsTargetgPosition);
    }
}
