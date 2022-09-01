using System;
using DG.Tweening;
using Lean.Pool;
using ScriptableObjects.EventChannels;
using Unity.Mathematics;
using UnityEngine;

public class DiscSpawner : MonoBehaviour
{
    [SerializeField] private GameObject discPrefab;
    [SerializeField] private Vector3 spawnLocation = Vector3.zero;
    [SerializeField] private int timeBetweenSpawn;
    private float m_timeSinceSpawn = 0;

    [SerializeField] private VoidEventChannel initialiseEventChannel;

    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = .5f;
    [SerializeField] private SpriteRenderer spawnIndicator;
    
    
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
            SpawnDisc();
            Color temp = spawnIndicator.color;
            temp.a = 0;
            spawnIndicator.color = temp;
            m_timeSinceSpawn = timeBetweenSpawn;
        }
        else
        {
            Color temp = spawnIndicator.color;
            temp.a = 1 - (m_timeSinceSpawn / timeBetweenSpawn);
            spawnIndicator.color = temp;
        }
    }

    // private void FixedUpdate()
    // {
    //     var transform1 = transform;
    //     var pos = transform1.position;
    //     var targetDir = (target.position - pos).normalized;
    //     transform1.position = pos + targetDir * moveSpeed * Time.fixedDeltaTime;
    // }

    void SpawnDisc()
    {
        LeanPool.Spawn(discPrefab, transform.position, quaternion.identity);
    }

    private void Initialise()
    {
        m_timeSinceSpawn = timeBetweenSpawn;
    }
}
