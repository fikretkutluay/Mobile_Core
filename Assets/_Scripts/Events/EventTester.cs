using UnityEngine;

public class EventTester : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameEvents.TriggerGameStarted();
        }
    }
    private void GameStarted()
    {
        Debug.Log("Game Started Event Triggered");
    }
    private void OnEnable()
    {
        GameEvents.OnGameStarted += GameStarted;   
    }
    private void OnDisable()
    {
        GameEvents.OnGameStarted -= GameStarted;
    }
}
