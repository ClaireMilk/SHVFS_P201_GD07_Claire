using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Hackman_GD07;

public class LINQE : MonoBehaviour
{
    private void OnEnable()
    {
        var names = new[] { "1", "2", "3" };
        var namesWithAQuery = from name in names
                              where name.Contains('C')
                              select name;
        var namesWithAMethod = names.Where(name => name.Contains('c'));
        foreach(var name in namesWithAQuery)
        {
            Debug.Log($"QUERY: {name}");
        }
        foreach (var name in namesWithAMethod)
        {
            Debug.Log($"Method: {name}");
        }
        var enemies = new List<Enemy>()
        {
            new Enemy(){Name = "1", HP = 922},
            new Enemy(){Name = "1", HP = 922},
            new Enemy(){Name = "1", HP = 922},
            new Enemy(){Name = "1", HP = 922},

        };
        var deadEnemies = enemies.Where(enemy => enemy.HP <= 0);
        var deadEnemiesBORING = new List<Enemy>();
        foreach(var enemy in enemies)
        {
            if (enemy.HP <= 0)
            {
                deadEnemiesBORING.Add(enemy);
            }
        }
        foreach(var enemy in deadEnemies)
        {
            Debug.Log($"Dead enemy: {enemy.Name}");
        }
    }
    public class Enemy
    {
        public string Name;
        public int HP;
    }
}
