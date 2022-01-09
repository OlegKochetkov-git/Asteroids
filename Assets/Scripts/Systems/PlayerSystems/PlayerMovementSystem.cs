using UnityEngine;
using Leopotam.Ecs;
using Asteroids.Components;

namespace Asteroids.Systems
{
    sealed class PlayerMovementSystem : IEcsRunSystem
    {
        readonly EcsFilter<RigidBody2dData, PlayerInputData, SpeedForceData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var RigidBody2dRef = ref filter.Get1(item);
                ref var input = ref filter.Get2(item);
                ref var force = ref filter.Get3(item);

                var rb = RigidBody2dRef.rb;

                rb.AddRelativeForce(input.direction.normalized * force.speed * Time.deltaTime);
            }
        }
    }
}

