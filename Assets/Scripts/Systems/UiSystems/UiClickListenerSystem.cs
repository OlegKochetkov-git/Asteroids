using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using Asteroids.Events;
using Asteroids.Tags;

namespace Asteroids.Systems
{
    sealed class UiClickListenerSystem : IEcsRunSystem
    {
        readonly EcsWorld ecsWorld;
        readonly EcsFilter<EcsUiClickEvent> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var bt = ref filter.Get1(item);

                if (bt.WidgetName == "StartButton")
                {
                    ecsWorld.NewEntity().Get<InitPlayerEvent>();
                    ecsWorld.NewEntity().Get<StartTimerAsteroidTag>();
                }  
            }
        }
    }
}

