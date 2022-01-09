using Leopotam.Ecs;
using LeoEcsPhysics;
using Voody.UniLeo;
using Asteroids.Events;
using UnityEngine;
using Asteroids.Components;
using Leopotam.Ecs.Ui.Systems;

namespace Asteroids.Systems
{
    sealed class OnTriggerEnter2DSystem : IEcsRunSystem
    {
        readonly EcsFilter<OnTriggerEnter2DEvent> filter;

        ScoreService scoreService;
        SceneData sceneData;
        

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var eventData = ref filter.Get1(item);
                ref var entity = ref filter.GetEntity(item);

                var senderEntity = eventData.senderGameObject.gameObject.GetComponent<EntityReference>().entity;
                var collisionGameObject = eventData.collider2D.gameObject;
               
                if (collisionGameObject.CompareTag("DestroyCollider"))
                {
                    senderEntity.Get<DestroyEvent>();
                }
                
                if (collisionGameObject.CompareTag("Asteroid"))
                {
                    collisionGameObject.GetComponent<EntityReference>().entity.Get<DestroyEvent>();
                    senderEntity.Get<DestroyEvent>();
                    scoreService.AddScore(1);
                    sceneData.hud.SetScore(scoreService.Score);
                }

                if (collisionGameObject.CompareTag("Player"))
                {
                    collisionGameObject.GetComponent<EntityReference>().entity.Get<DeadEvent>();
                    senderEntity.Get<DestroyEvent>();
                }
   
                entity.Destroy();
            }
        }
    }
}

