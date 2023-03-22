using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants 
{
    //Scenes Indexes
    public const int MedievalEnvironmentScene = 1;

    //Transition Time Between Scenes
    public const float TransitionTimeBetweenScenes = 2f;

    //Gate Motion
    public const string GateMotionOpen = "GateOpen";

    //Door Motion
    public const string DoorMotionOpen = "openDoor";

    //NPC
    public const double DefenceSoldierWalkingDistance = 1.8f;
    public const double VillagerWalkingDistance = 2f;

    //Health Bar
    public const int MaxHealth = 100;

    //Animations
    public const string Attack = "attack";
    public const string Run = "run";
    public const string Defend = "defend";
    public const string Die = "die";
    public const string Walk = "walk";
    public const string LowAttack = "lowAttack";
    public const string JumpAttack = "jumpAttack";

    //Tags
    public const string CastleBPatrolTag = "CastleBPatrol";

    //Hits
    public const int HitAmount = 10;

}
