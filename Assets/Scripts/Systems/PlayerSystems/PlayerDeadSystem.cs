using Leopotam.Ecs;
using Asteroids.Components;
using Asteroids.Events;
using UnityEngine;

namespace Asteroids.Systems
{
    sealed class PlayerDeadSystem : IEcsRunSystem
    {
        readonly SceneData sceneData;

        readonly EcsFilter<PlayerData, DeadEvent> filter;
        public void Run()
        {
            foreach (var item in filter)
            {
                ref var player = ref filter.Get1(item);
                ref var entity = ref filter.GetEntity(item);

                sceneData.hud.ShowGameOver();

                Object.Destroy(player.playerGO);
                entity.Destroy();
            }
        }
    }
}