using UnityEngine;

namespace Asteroids.Components
{
    public struct PlayerData
    {
        public GameObject playerGO;
        public Transform transform;
        public Transform gunTransform;
        public Vector2 direction;
        public Vector2 mouseLook;
    }
}