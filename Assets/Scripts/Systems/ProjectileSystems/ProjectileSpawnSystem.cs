using Leopotam.Ecs;
using Asteroids.Components;
using Asteroids.Events;
using UnityEngine;

namespace Asteroids.Systems
{
    sealed class ProjectileSpawnSystem : IEcsRunSystem
    {
        readonly StaticData staticData;

        readonly EcsFilter<ProjectileData, ProjectileSpawnEvent> filter;
        readonly EcsFilter<PlayerData> playerFilter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var projectile = ref filter.Get1(item);

                ref var player = ref playerFilter.Get1(item);

                ref var projectileEntity = ref filter.GetEntity(item);

                projectile.projectileGO = Object.Instantiate(staticData.projectilePrefab, player.gunTransform.position, player.gunTransform.rotation);
                projectile.projectileGO.GetComponent<EntityReference>().entity = projectileEntity;

                projectileEntity.Get<RigidBody2dData>().rb = projectile.projectileGO.GetComponent<Rigidbody2D>();

                projectile.direction = player.mouseLook;
            }
        }
    }
}