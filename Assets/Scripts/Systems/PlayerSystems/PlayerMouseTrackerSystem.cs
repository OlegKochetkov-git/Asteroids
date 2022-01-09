using UnityEngine;
using Leopotam.Ecs;
using Asteroids.Components;

namespace Asteroids.Systems
{
    sealed class PlayerMouseTrackerSystem : IEcsRunSystem
    {
        readonly EcsFilter<PlayerData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var player = ref filter.Get1(item);

                player.mouseLook = Input.mousePosition - Camera.main.WorldToScreenPoint(player.transform.position);
                var angle = Mathf.Atan2(player.mouseLook.y, player.mouseLook.x) * Mathf.Rad2Deg;
                player.transform.eulerAngles = new Vector3(0f, 0f, angle - 90f);
            }
        }
    }
}

