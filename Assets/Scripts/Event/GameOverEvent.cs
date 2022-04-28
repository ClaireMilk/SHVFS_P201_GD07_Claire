using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverEvent
{
    public bool IsWinning;

    public GameOverEvent(bool isWinning)
    {
        IsWinning = isWinning;
    }
}
