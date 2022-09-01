using GeneralScriptableObjects;
using Lean.Pool;
using ScriptableObjects.EventChannels;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PowerUp
{
    public class PowerUpSpawner : MonoBehaviour
    {
        [SerializeField] private PowerUp[] powerUp;
        [SerializeField] private int minTimeBetweenSpawn = 15;
        [SerializeField] private int maxTimeBetweenSpawn = 25;
        private float m_timeSinceSpawn = 0;

        [SerializeField] private TileContainer tiles;
        
        [SerializeField] private VoidEventChannel initialiseEventChannel;
        
        private void Awake()
        {
            initialiseEventChannel.onEventRaised += Initialise;
        }
    
        private void OnDestroy()
        {
            initialiseEventChannel.onEventRaised -= Initialise;
        }
        
        void Start()
        {
            Initialise();
        }
        
        void Update()
        {
            m_timeSinceSpawn -= Time.deltaTime;

            if (m_timeSinceSpawn <= 0)
            {
                SpawnPowerUp();
                GetSpawnTime();
            }
        }

        private void GetSpawnTime()
        {
            m_timeSinceSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        }

        private Vector3 GetRandomSpawnLocation()
        {
            Vector3 spawnPos = tiles.GetRandomTile();
            spawnPos.x += .5f;
            spawnPos.y += .5f;
            return spawnPos;
        }
        
    
        void SpawnPowerUp()
        {
            var spawnPos = 
            LeanPool.Spawn(powerUp[Random.Range(0, powerUp.Length)].gameObject,
            GetRandomSpawnLocation(), 
            quaternion.identity);
        }
    
        private void Initialise()
        {
            GetSpawnTime();
        }
    }
}