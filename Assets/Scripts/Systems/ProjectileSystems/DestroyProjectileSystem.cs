using Leopotam.Ecs;
using UnityEngine;
using Asteroids.Components;
using Asteroids.Events;

namespace Asteroids.Systems
{
    sealed class DestroyProjectileSystem : IEcsRunSystem
    {
        readonly EcsFilter<ProjectileData, DestroyEvent> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var projectile = ref filter.Get1(item);

                ref var entity = ref filter.GetEntity(item);

                Object.Destroy(projectile.projectileGO);
                entity.Destroy();
            }
        }
    }
}

