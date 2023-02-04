using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Astar
{
    public enum PossibleMoves
    {
        WALK,
        ATTACK,
        FALLBACK
    }


    /// <summary>
    /// AttackTeamNode represents the state of the attack team at each point of the game
    /// </summary>
    public class AttackTeamNode
    {
        // army's state
        public List<Soldier> soldiers;
        // king's state
        private Transform kingsCurrentLocation;
        private Transform kingsTargetgLocation;
        // a* parameters
        private float g;
        private float h;
        private float f;
        private AttackTeamNode parentNode;

        /// <summary>
        /// This constructor creates the root node for the a* graph, meaning the initial state of the attack team
        /// </summary>
        public AttackTeamNode(Transform kingsCurrentLocation, Transform kingsTargetgLocation, List<Soldier> soldiers)
        {
            //army's state
            this.soldiers = soldiers;
            //king's state
            this.kingsCurrentLocation = kingsCurrentLocation;
            this.kingsTargetgLocation = kingsTargetgLocation;
            //a* parameters 
            g = 0;
            h = ComputeH(kingsCurrentLocation, kingsTargetgLocation, soldiers);
            f = ComputeF(g, h);
        }

        /// <summary>
        /// This constructor creates neighbors of each given node, meaning all possible moves from this current team's state
        /// </summary>
        public AttackTeamNode(AttackTeamNode attackTeamNode, PossibleMoves move)
        {
            //new army's state
            HandleNewMove(move);

            //a* parameters 
            g = ComputeG(attackTeamNode.g);
            //h = ComputeH(kingsCurrentLocation, kingsTargetgLocation);
            f = ComputeF(g, h);
            parentNode = attackTeamNode;
        }

        private float ComputeH(Transform kingsCurrentLocation, Transform kingsTargetgLocation, List<Soldier> soldiers) 
        {
            float armysHealth = CalculateArmysHealth(soldiers);
            float kingsDistanceFromTarget = Vector3.Distance(kingsCurrentLocation.position, kingsTargetgLocation.position);
            return kingsDistanceFromTarget - armysHealth; // - or + 
        }

        private float ComputeG(float lastG)
        {
            return lastG + 1;
        }

        private float ComputeF(float g, float h)
        {
            return g + h;
        }

        private float CalculateArmysHealth(List<Soldier> army)
        {
            List<float> soldiersHealth = soldiers.Select(s => s.Helath).ToList();
            float armysHealth = 0;

            foreach (var soldierHealth in soldiersHealth)
            {
                armysHealth += soldierHealth;
            }

            return armysHealth;
        }

        private void HandleNewMove(PossibleMoves move)
        {
            switch(move)
            {
                case PossibleMoves.ATTACK:
                    break;
                case PossibleMoves.FALLBACK:
                    break;
                case PossibleMoves.WALK:
                    break;
            }
        }
        
        public float getF()
        {
            return f;
        }

        public float getG()
        {
            return g;
        }

        public float getH()
        {
            return h;
        }

        public bool TargetNodeFound()
        {
            return kingsCurrentLocation.Equals(kingsTargetgLocation);
        }
    }
}

