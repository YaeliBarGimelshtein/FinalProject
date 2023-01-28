using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStart;

public class AStar : MonoBehaviour
{
    private List<AttackTeamNode> openSet;
    private HashSet<AttackTeamNode> closedSet;
    private AttackTeamNode rootNode;
    private bool win = false;

    public Transform kingsPosition;
    public Transform kingsWinPosition;
    public List<Soldier> soldiers;
    private List<int> options; // need to make better logic

    private bool finishedMove;
    
    void Start()
    {
        openSet = new List<AttackTeamNode>();
        closedSet = new HashSet<AttackTeamNode>();
        rootNode = new AttackTeamNode(kingsPosition, kingsPosition, kingsWinPosition, soldiers);
        openSet.Add(rootNode);
    }

    // Update is called once per frame
    void Update()
    {
        if(finishedMove)
        {
            MakeNextMove();
        }
    }

    private void MakeNextMove()
    {
        Node nextMove = GetFirstPriorityNode();
        //act according to node content
    }

    private void FindNextMove()
    {
        // node in OPEN with lowest f_cost
        AttackTeamNode current = openSet[0];
        current = GetFirstPriorityNode();

        // remove current from open and add to CLOSED
        openSet.Remove(current);
        closedSet.Add(current);

        // if current is the terget node -> path has been find
        if (current.TargetNodeFound())
        {
            win = true;
            return;
        }

        // for each neighbour of the current node -> add it to open list
        foreach (int option in options)
        {
            CheckNeighbour(current, option);
        }
        
    }

    private void CheckNeighbour(AttackTeamNode node, int option)
    {
        var neighbour = new AttackTeamNode(node, option);

        // neighbour already visited
        if (closedSet.Contains(neighbour))
        {
            return;
        }

        if (!openSet.Contains(neighbour) && neighbour.fCost < node.fCost)
        {
            openSet.Add(neighbour);
        }
    }

    private AttackTeamNode GetFirstPriorityNode()
    {
        AttackTeamNode current = openSet[0];

        for (int i = 1; i < openSet.Count; i++)
        {
            if (openSet[i].fCost < current.fCost || openSet[i].fCost == current.fCost)
            {
                if (openSet[i].hCost < current.hCost)
                    current = openSet[i];
            }
        }
        return current;
    }
}
