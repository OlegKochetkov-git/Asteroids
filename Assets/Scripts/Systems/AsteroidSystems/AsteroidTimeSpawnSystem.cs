using UnityEngine;
using Leopotam.Ecs;
using Asteroids.Components;
using Asteroids.Events;
using Asteroids.Tags;

namespace Asteroids.Systems
{
    sealed class AsteroidTimeSpawnSystem : IEcsRunSystem
    {
        readonly EcsWorld ecsWorld;
        readonly SceneData sceneData;

        readonly EcsFilter<StartTimerAsteroidTag> filter;
        public void Run()
        {
            foreach (var item in filter)
            {
                sceneData.timer -= Time.deltaTime;

                if (sceneData.timer <= 0)
                {
                    EcsEntity asteroid = ecsWorld.NewEntity();

                    asteroid.Get<AsteroidData>();
                    asteroid.Get<ChooseSideToSpawnEvent>();
                    asteroid.Get<AsteroidSpawnEvent>();

                    sceneData.timer += sceneData.secondsBetweenAsteroids;
                }
            }
        }
    }
}

