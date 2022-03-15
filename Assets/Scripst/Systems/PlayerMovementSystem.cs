using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using Unity.Entities;



public class PlayerMovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        
        float deltaTime = Time.DeltaTime;
        float2 Axis = new float2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Debug.Log($"{Axis.x} - {Axis.y}");
        Entities.ForEach((ref PlayerComponent player, ref LocalToWorld transform, ref PhysicsVelocity physics) =>
        {
            float3 movVectorAdd = transform.Forward * Axis.y * player.speed * deltaTime;
            physics.Linear += new float3(movVectorAdd.x,0, movVectorAdd.z);
            physics.Angular = new float3(0.0f, Axis.x * player.rotation * deltaTime, 0.0f);
        });
        
    }
    

}
