using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants 
{
    //Scenes Indexes
    public const int MedievalEnvironmentScene = 0;
    public const int CastleAScene = 1;
    public const int CastleBScene = 2;

    //Transition Time Between Scenes
    public const float TransitionTimeBetweenScenes = 1f;

    //Save Position On Exit Medieval Environment Scene To Castle A Scene
    public const int AdditionalOnXAxesLeavingMedievalEnviromentSceneToCastleAScene = 12;
    public const int AdditionalOnYAxesLeavingMedievalEnviromentSceneToCastleAScene = 3;

    //Save Position On Exit Medieval Environment Scene To Castle B Scene
    public const int AdditionalOnXAxesLeavingMedievalEnviromentSceneToCastleBScene = 9;
    public const int AdditionalOnYAxesLeavingMedievalEnviromentSceneToCastleBScene = 3;
    public const int AdditionalOnZAxesLeavingMedievalEnviromentSceneToCastleBScene = 12;

    //Gate Motion
    public const string GateMotionOpen = "GateOpen";

    //Door Motion
    public const string DoorMotionOpen = "openDoor";

    //NPC
    public const double DefenceSoldierWalkingDistance = 1.8f;
    public const double VillagerWalkingDistance = 2f;
}
