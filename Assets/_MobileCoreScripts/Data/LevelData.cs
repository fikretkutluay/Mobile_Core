using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    public string levelID;
    public string levelName;
    public Sprite levelIcon;
    public GameObject levelPrefab;
    
}
