using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

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
        public void Awake()
        {
            var fullFilePath = $"{Application.dataPath}/Hackman/StreamingAssets/Levels_1.json";

            var obj = JsonConvert.SerializeObject(Grid);
            var grid = JsonConvert.DeserializeObject<int[,]>(obj);

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

            LogGrid();
        }

        [ContextMenu("Log Grid")]
        public void LogGrid()
        {
            var obj = JsonConvert.SerializeObject(Grid);
            Debug.Log(obj);
        }

        [ContextMenu("Log Enemies")]
        public void LogEnemies()
        {
            var enemies = new List<ExampleEenemy>()
            {
                new ExampleEenemy() { HP = 20},
            };

            var obj = JsonConvert.SerializeObject(Grid);
            Debug.Log(obj);
        }

        [ContextMenu("Save Level")]
        public void SaveLevel()
        {
            if (!File.Exists(fullFilePath))
            {
                var fileStream = File.Create(fullFilePath);
                fileStream.Close();
            }

            //File.WriteAllText(fullFilePath, obj);

            //Debug.Log(obj);
        }
    }

    public class ExampleEenemy
    {
        public int HP = 8;
    }
}
