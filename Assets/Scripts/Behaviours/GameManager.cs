using System;
using UnityEngine;

internal class GameManager
{
    private int life = 3;

    internal void GameOver()
    {
        Debug.LogError("GameOver");
    }

    internal void LoseLife()
    {
        life--;
        if (life <= 0)
            GameOver();
    }
}