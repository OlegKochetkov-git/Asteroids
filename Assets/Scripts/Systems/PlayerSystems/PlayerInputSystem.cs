using UnityEngine;
using Leopotam.Ecs;
using Asteroids.Components;

namespace Asteroids.Systems
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        readonly EcsFilter<PlayerInputData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var input = ref filter.Get1(item);

                input.direction.x = Input.GetAxis("Horizontal");
                input.direction.y = Input.GetAxis("Vertical");
                input.fireButton = Input.GetMouseButtonDown(0);
            }
        }
    }
}