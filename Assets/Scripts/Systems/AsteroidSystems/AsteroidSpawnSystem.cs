using UnityEngine;
using Leopotam.Ecs;
using Asteroids.Components;
using Asteroids.Events;

namespace Asteroids.Systems
{
    sealed class AsteroidSpawnSystem : IEcsRunSystem
    {
        readonly StaticData staticData;

        readonly EcsFilter<AsteroidData, AsteroidSpawnEvent> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var asteroid = ref filter.Get1(item);

                ref var entity = ref filter.GetEntity(item);

                asteroid.worldSpawnPoint = Camera.main.ViewportToWorldPoint(asteroid.spawnPoint);
                asteroid.worldSpawnPoint.z = 0;

                asteroid.asteroidGO = Object.Instantiate(staticData.asteroidsPrefabs[Random.Range(0, staticData.asteroidsPrefabs.Length)],
                    asteroid.worldSpawnPoint, Quaternion.identity);
                asteroid.asteroidGO.GetComponent<EntityReference>().entity = entity;

                ref var asteroidRb = ref entity.Get<RigidBody2dData>();

                asteroidRb.rb = asteroid.asteroidGO.GetComponent<Rigidbody2D>();

            }
        }      
    }
}

