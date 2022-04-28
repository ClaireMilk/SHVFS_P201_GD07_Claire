using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hackman_GD07
{
    public class LevelGeneratorSystem : MonoBehaviour
    {
        public BaseGridObject[] BaseGridObjectPrefabs;
        public static int[,] Grid = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,2,1,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1},
            {1,0,1,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1},
            {1,0,1,0,0,0,0,1,1,1,1,1,0,1,0,1,0,1},
            {1,0,0,0,0,0,0,0,3,0,0,0,0,1,0,3,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
        };
        public void Start()
        {
            var gridSizeY = Grid.GetLength(0);
            var gridSizeX = Grid.GetLength(1);
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int x = 0; x < gridSizeX; x++)
                {
                    var objectType = Grid[y, x]; // objectType - int
                    var gridObjectPrefab = BaseGridObjectPrefabs[objectType]; // gridObjectPrefab - BaseGridObject
                    var gridObjectClone = Instantiate(gridObjectPrefab);

                    gridObjectClone.GridPosition = new IntVector2(x, -y);

                    gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPosition.x, gridObjectClone.GridPosition.y, 0);
                }
            }
        }
    }
}
