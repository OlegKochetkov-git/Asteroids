using UnityEngine;

namespace Asteroids.Components
{
    public struct AsteroidData
    {
        public GameObject asteroidGO;
        public Vector2 direction;
        public Vector2 spawnPoint;
        public Vector3 worldSpawnPoint;
        public int side;
    }
}