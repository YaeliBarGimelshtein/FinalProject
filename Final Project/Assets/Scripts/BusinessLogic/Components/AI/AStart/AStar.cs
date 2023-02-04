using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Astar;

public class AStar : MonoBehaviour
{
    // the set of nodes to be evaluated
    private List<AttackTeamNode> openSet;
    // the set of nodes already evaluated
    private HashSet<AttackTeamNode> closedSet;
    // the starting node
    private AttackTeamNode rootNode;
    // logic for winning and finished move
    private bool win = false;
    private bool finishedMove = false;
    //unity needed information
    public Transform kingsLocation;
    public Transform kingsTargetLocation;
    public List<Soldier> soldiers;
    public List<int> options;

    void Start()
    {
        openSet = new List<AttackTeamNode>();
        closedSet = new HashSet<AttackTeamNode>();
        rootNode = new AttackTeamNode(kingsLocation, kingsTargetLocation, soldiers);
        //adding the root node to the open set
        openSet.Add(rootNode);
    }

    // Update is called once per frame
    void Update()
    {
        if(win)
        {
            print("WE WON"); //make ui message maybe
        }
        else if(finishedMove)
        {
            MakeNextMove();
        }
    }

    private void MakeNextMove()
    {
        AttackTeamNode nextMove = FindNextMove();
        //act according to node content --> give orders to army

        finishedMove = true;
    }

    private AttackTeamNode FindNextMove()
    {
        finishedMove = false;
        // node in OPEN with lowest f_cost
        AttackTeamNode current = GetLowestFcost();

        // remove current from open and add to CLOSED
        openSet.Remove(current);
        closedSet.Add(current);

        // if current is the terget node -> target reached
        if (current.TargetNodeFound())
        {
            win = true;
            return current;
        }

        // for each neighbour of the current node -> add it to open list
        foreach (int option in options)
        {
            PossibleMoves move = (PossibleMoves)option;
            CheckNeighbour(current, move);
        }
        return current;
    }

    private void CheckNeighbour(AttackTeamNode current, PossibleMoves move)
    {
        var neighbour = new AttackTeamNode(current, move);

        // neighbour already visited
        if (closedSet.Contains(neighbour))
        {
            return;
        }
        // neighbour is new and has smaller cost than current node
        if (!openSet.Contains(neighbour) && neighbour.getF() < current.getF())
        {
            openSet.Add(neighbour);
        }
    }

    private AttackTeamNode GetLowestFcost()
    {
        AttackTeamNode current = openSet[0];

        for (int i = 1; i < openSet.Count; i++)
        {
            if (openSet[i].getF() < current.getF() || openSet[i].getF() == current.getF())
            {
                current = openSet[i];
            }
        }
        return current;
    }
}
