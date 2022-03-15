using UnityEngine;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using Unity.Entities;

public class WarpSysytem : ComponentSystem
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.ForEach((ref Translation pos, ref OverScreenWarp wc, ref LocalToWorld transform) =>
        {
            
            if (pos.Value.x > wc.MaxX) pos.Value = new float3(wc.MinX, 0, pos.Value.z);
            if (pos.Value.x < wc.MinX) pos.Value = new float3(wc.MaxX, 0, pos.Value.z);
            if (pos.Value.z > wc.MaxY) pos.Value = new float3(pos.Value.x, 0, wc.MinY);
            if (pos.Value.z < wc.MinY) pos.Value = new float3(pos.Value.x, 0, wc.MaxY);
            
        });
    }
}
