using UnityEngine;

public class SceneData : MonoBehaviour
{
    [Header("Player:")]
    public Transform playerSpawnPoint;
    public float playerSpeed;
    public float porjectileSpeed;

    [Header("Asteroid:")]
    public float secondsBetweenAsteroids;
    public float timer;
    public float asteroidMinSpeed;
    public float asteroidMaxSpeed;

    [Header("HUD:")]
    public GameHud hud;

}

