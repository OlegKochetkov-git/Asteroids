using UnityEngine;
using Leopotam.Ecs;
using Asteroids.Components;

namespace Asteroids.Systems
{
    sealed class KeepPlayerOnScreenSystem : IEcsRunSystem
    {
        readonly EcsFilter<PlayerData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var player = ref filter.Get1(item);

                Vector3 newPosition = player.transform.transform.position;

                Vector3 viewportPosition = Camera.main.WorldToViewportPoint(player.transform.transform.position);

                if (viewportPosition.x > 1)
                {
                    newPosition.x = -newPosition.x + 0.1f;
                }
                else if (viewportPosition.x < 0)
                {
                    newPosition.x = -newPosition.x - 0.1f;
                }

                if (viewportPosition.y > 1)
                {
                    newPosition.y = -newPosition.y + 0.1f;
                }
                else if (viewportPosition.y < 0)
                {
                    newPosition.y = -newPosition.y - 0.1f;
                }

                player.transform.transform.position = newPosition;
            }
        }
    }
}

