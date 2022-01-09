using UnityEngine;
using Leopotam.Ecs;
using Asteroids.Components;
using Asteroids.Events;

namespace Asteroids.Systems
{
    sealed class ChooseSideToSpawnSystem : IEcsRunSystem
    {
        readonly EcsFilter<AsteroidData, ChooseSideToSpawnEvent> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var asteroid = ref filter.Get1(item);

                ref var entity = ref filter.GetEntity(item);

                asteroid.side = Random.Range(0, 4);

                asteroid.spawnPoint = Vector2.zero;
                asteroid.direction = Vector2.zero;

                switch (asteroid.side)
                {
                    case 0:
                        asteroid.spawnPoint.x = 0;
                        asteroid.spawnPoint.y = Random.value;

                        Vector2 fromLeftSide = new Vector2(1f, Random.Range(-1f, 1f));
                        asteroid.direction = fromLeftSide;

                        break;

                    case 1:
                        asteroid.spawnPoint.x = 1;
                        asteroid.spawnPoint.y = Random.value;

                        Vector2 fromRightSide = new Vector2(-1f, Random.Range(-1f, 1f));
                        asteroid.direction = fromRightSide;

                        break;

                    case 2:
                        asteroid.spawnPoint.x = Random.value;
                        asteroid.spawnPoint.y = 0;

                        Vector2 fromBottomSide = new Vector2(Random.Range(-1f, 1f), 1f);
                        asteroid.direction = fromBottomSide;

                        break;

                    case 3:
                        asteroid.spawnPoint.x = Random.value;
                        asteroid.spawnPoint.y = 1;

                        Vector2 fromTopSide = new Vector2(Random.Range(-1f, 1f), -1f);
                        asteroid.direction = fromTopSide;

                        break;
                }
            }
        }
    }
}

