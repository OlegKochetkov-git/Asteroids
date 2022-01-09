using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using Asteroids.Systems;
using Asteroids.Events;
using LeoEcsPhysics;
using Leopotam.Ecs.Ui.Systems;

namespace Asteroids {
    sealed class EcsStartup : MonoBehaviour {

        EcsWorld world;
        EcsSystems updateSystem;
        EcsSystems fixedUpdateSystem;

        [SerializeField] StaticData staticData;
        [SerializeField] SceneData sceneData;
        [SerializeField] EcsUiEmitter uiEmitter;

        ScoreService scoreService;

        void Start () {
            
            world = new EcsWorld();
            updateSystem = new EcsSystems(world);
            fixedUpdateSystem = new EcsSystems(world);
            scoreService = new ScoreService();
            EcsPhysicsEvents.ecsWorld = world;

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (updateSystem);
#endif

            updateSystem.ConvertScene();

            updateSystem  
                .Add(new PlayerSpawnSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerMouseTrackerSystem())
                .Add(new KeepPlayerOnScreenSystem())
                .Add(new PlayerShootSystem())
                .Add(new ProjectileSpawnSystem())
                .OneFrame<ProjectileSpawnEvent>()
                .Add(new PlayerDeadSystem())
                
                .Add(new AsteroidTimeSpawnSystem())
                .Add(new ChooseSideToSpawnSystem())
                .Add(new AsteroidSpawnSystem())
                .OneFrame<ChooseSideToSpawnEvent>()
                .OneFrame<AsteroidSpawnEvent>()
                .Add(new OnTriggerEnter2DSystem())
                .Add(new DestroyAsteroidSystem())
                .Add(new DestroyProjectileSystem())

                .Add(new UiClickListenerSystem())

                .Inject(staticData)
                .Inject(sceneData)
                .InjectUi(uiEmitter)
                .Inject(scoreService)
                .Init();

            fixedUpdateSystem
                .Add(new PlayerMovementSystem())
                .Add(new AsteroidMovementSystem())
                .Add(new ProjectileMovementSystem())

                .Inject(staticData)
                .Inject(sceneData)
                .Init();
        }


        void Update () {
            updateSystem?.Run();
        }

        void FixedUpdate()
        {
            fixedUpdateSystem?.Run();
        }

        void OnDestroy () {
            if (updateSystem != null) {
                updateSystem.Destroy ();
                updateSystem = null;
                world.Destroy ();
                world = null;
            }
        }
    }
}