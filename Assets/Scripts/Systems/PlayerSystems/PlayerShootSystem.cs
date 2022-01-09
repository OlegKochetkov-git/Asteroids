using Leopotam.Ecs;
using Asteroids.Components;
using Asteroids.Tags;
using Asteroids.Events;

namespace Asteroids.Systems
{
    sealed class PlayerShootSystem : IEcsRunSystem
    {
        readonly EcsWorld ecsWorld;

        readonly EcsFilter<PlayerInputData, HasWeaponTag> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var input = ref filter.Get1(item);

                if (!input.fireButton) { return; }

                EcsEntity entity = ecsWorld.NewEntity();
                entity.Get<ProjectileData>();
                entity.Get<ProjectileSpawnEvent>();
            }
        }
    }
}

