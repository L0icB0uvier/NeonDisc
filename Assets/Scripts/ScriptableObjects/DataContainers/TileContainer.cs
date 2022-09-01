using System.Collections.Generic;
using ScriptableObjects.DataContainers;
using UnityEngine;

namespace GeneralScriptableObjects
{
    [CreateAssetMenu(fileName = "TileContainer", menuName = "ScriptableObjects/TileContainer", order = 0)]
    public class TileContainer : DescriptionBaseSO
    {
        public List<Vector3Int> Tiles = new List<Vector3Int>();

        public void ClearList()
        {
            Tiles.Clear();
        }

        public void AddItem(Vector3Int item)
        {
            Tiles.Add(item);
        }

        public void RemoveItem(Vector3Int item)
        {
            Tiles.Remove(item);
        }

        public Vector3Int GetRandomTile()
        {
            return Tiles[Random.Range(0, Tiles.Count)];
        }
    }
}