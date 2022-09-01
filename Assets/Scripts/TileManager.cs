using GeneralScriptableObjects;
using ScriptableObjects.EventChannels;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Grid grid;
    private Tilemap m_tilemap;

    [SerializeField] private VoidEventChannel onRestartGameEventChannel;
    [SerializeField] private Vector2EventChannel destroyWallEventChannel;
    
    [SerializeField] private int gridSize = 200;
    [SerializeField] private int startSize = 5;
    [SerializeField] private TileBase tile;

    [SerializeField] private TileContainer tileContainer;
    
    private void Awake()
    {
        m_tilemap = GetComponent<Tilemap>();
        destroyWallEventChannel.onEventRaised += DestroyTile;
        onRestartGameEventChannel.onEventRaised += ResetTilemap;
    }
    
    private void OnDestroy()
    {
        destroyWallEventChannel.onEventRaised -= DestroyTile;
        onRestartGameEventChannel.onEventRaised -= ResetTilemap;
    }

    private void Start()
    {
        ResetTilemap();
    }
    
    private void ResetTilemap()
    {
        m_tilemap.ClearAllTiles();
        tileContainer.ClearList();
        
        int gridStart = (-gridSize / 2) - 1;
        int gridEnd = gridSize / 2;
        int minX = -(startSize / 2) - 1;
        int maxX = startSize / 2;
        
        for (int x = gridStart; x <= gridEnd; x++)
        {
            for (int y = gridStart; y <= gridEnd; y++)
            {
                if (x >= minX && x <= maxX && y >= minX && y <= maxX)
                {
                    tileContainer.AddItem(new Vector3Int(x, y, 0));
                    continue;
                }

                Vector3Int pos = new Vector3Int(x, y, 0);
                m_tilemap.SetTile(pos, tile);
            }
        }
    }
    
    private void DestroyTile(Vector2 tileLocation)
    {
        var tilePos = grid.WorldToCell(tileLocation);
        tileContainer.AddItem(tilePos);
        m_tilemap.SetTile(tilePos, null);
    }
}
