using UnityEngine;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using Unity.Entities;

public class PewPewSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        bool pew = Input.GetButton("Fire1");
        Debug.Log($"button:{pew}");
        Entities.ForEach((Entity entyty,ref PewPewComponent pewComponent, ref LocalToWorld transform) =>
        {
            pewComponent.LastPewTimeElapsed += deltaTime;
            if (pew & pewComponent.LastPewTimeElapsed>pewComponent.RechargeTime)
            {
                
                Debug.Log("pew");
                pewComponent.LastPewTimeElapsed = 0f;
                Entity laser = EntityManager.Instantiate(pewComponent.Laser);
                
                var x = transform.Position + EntityManager.GetComponentData<Translation>(pewComponent.LaserSource).Value;
                Debug.Log(x);
                // при присвоении translation обьект не всегда рендерится
                EntityManager.SetComponentData<Translation>(laser, new Translation {Value = x});
                //EntityManager.SetComponentData<Rotation>(laser, new Rotation {Value  = ps.LaserSource.});
            }
        });
    }
}
