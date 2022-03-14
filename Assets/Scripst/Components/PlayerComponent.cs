using Unity.Entities;
using Unity.Mathematics;
[GenerateAuthoringComponent]
public struct PlayerComponent : IComponentData
{
    public float speed;
    public float rotation;
    public float3 vectorMovement;
}
