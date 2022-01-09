using UnityEngine;
using Leopotam.Ecs;
using Asteroids.Components;
using Asteroids.Tags;
using Asteroids.Events;

namespace Asteroids.Systems
{
    sealed class PlayerSpawnSystem : IEcsRunSystem
    {
        readonly EcsWorld ecsWorld;
        readonly StaticData staticData;
        readonly SceneData sceneData;

        readonly EcsFilter<InitPlayerEvent> filter;
            
        public void Run()
        {
            foreach (var item in filter)
            {
                ref var initEntity = ref filter.GetEntity(item);

                EcsEntity playerEntity = ecsWorld.NewEntity();

                ref var player = ref playerEntity.Get<PlayerData>();
                ref var playerSpeed = ref playerEntity.Get<SpeedForceData>();
                ref var rigidBody2dRef = ref playerEntity.Get<RigidBody2dData>();
                playerEntity.Get<PlayerInputData>();
                playerEntity.Get<HasWeaponTag>();

                GameObject playerGO = Object.Instantiate(staticData.playerPrefab, sceneData.playerSpawnPoint.position, Quaternion.identity);
                GameObject gunGO = playerGO.transform.GetChild(0).gameObject;
                playerGO.GetComponent<EntityReference>().entity = playerEntity;

                player.playerGO = playerGO;
                player.transform = playerGO.transform;
                player.gunTransform = gunGO.transform;
                playerSpeed.speed = sceneData.playerSpeed;
                rigidBody2dRef.rb = playerGO.GetComponent<Rigidbody2D>();

                initEntity.Destroy();
            }
        }
    }
}