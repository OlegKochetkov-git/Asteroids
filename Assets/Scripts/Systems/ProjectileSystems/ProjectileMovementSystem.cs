using Leopotam.Ecs;
using Asteroids.Components;
using UnityEngine;

namespace Asteroids.Systems
{
    sealed class ProjectileMovementSystem : IEcsRunSystem
    {
        readonly SceneData sceneData;

        readonly EcsFilter<ProjectileData, RigidBody2dData> filter;
        readonly EcsFilter<PlayerData> playerFilter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var projectile = ref filter.Get1(item);
                ref var player = ref playerFilter.Get1(item);

                ref var rb = ref filter.Get2(item).rb;

                rb.velocity = projectile.direction.normalized * sceneData.porjectileSpeed * Time.deltaTime;
            }
        }
    }
}