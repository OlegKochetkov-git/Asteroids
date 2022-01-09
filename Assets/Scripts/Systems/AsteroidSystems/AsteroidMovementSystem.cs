using UnityEngine;
using Leopotam.Ecs;
using Asteroids.Components;

namespace Asteroids.Systems
{
    sealed class AsteroidMovementSystem : IEcsRunSystem
    {
        readonly SceneData sceneData;

        readonly EcsFilter<AsteroidData, RigidBody2dData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var asteroid = ref filter.Get1(item);
                ref var rigidBody2dRef = ref filter.Get2(item);

                rigidBody2dRef.rb.AddForce(asteroid.direction.normalized *
                    Random.Range(sceneData.asteroidMinSpeed, sceneData.asteroidMaxSpeed) * Time.deltaTime, ForceMode2D.Force);
            }
        }   
    }
}

