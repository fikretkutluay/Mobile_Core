using UnityEngine;
using System;

public static class GameEvents
{
    public static event Action OnGameStarted;
    public static event Action OnLevelCompleted;
    public static event Action OnLevelFailed;
    public static event Action<int> OnEconomyChanged;

    public static void TriggerGameStarted()
    {
        OnGameStarted?.Invoke();
    }
}

