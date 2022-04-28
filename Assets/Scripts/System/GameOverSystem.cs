using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSystem : Singleton<GameOverSystem>
{
    private void OnEnable()
    {
        Evently.Instance.Subscribe<GameOverEvent>(OnGameOver);
    }

    private void OnDisable()
    {
        Evently.Instance.Ubsubscribe<GameOverEvent>(OnGameOver);
    }

    private void OnGameOver(GameOverEvent over)
    {

    }
}