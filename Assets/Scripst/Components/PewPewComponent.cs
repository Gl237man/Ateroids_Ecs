using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct PewPewComponent : IComponentData
{
    public Entity LaserSource;
    public Entity Laser;
    public float RechargeTime;
    internal float LastPewTimeElapsed;
}
