using Leopotam.Ecs;
using UnityEngine;
using Asteroids.Components;
using Asteroids.Events;

namespace Asteroids.Systems
{
    sealed class DestroyAsteroidSystem : IEcsRunSystem
    {   
        readonly EcsFilter<AsteroidData, DestroyEvent> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var asteroid = ref filter.Get1(item);

                ref var entity = ref filter.GetEntity(item);

                Object.Destroy(asteroid.asteroidGO);
                entity.Destroy();
            }   
        }
    }
}

