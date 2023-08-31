using Assets.Scripts.Abstracts;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(GameSettings), menuName = "Settings/" + nameof(GameSettings))]
public class GameSettings : SingletonScriptableObject<GameSettings>
{
    [Header("Levels")]
    public string LevelsDataPath = "Data/Levels";
    public string LevelFileNameFormat = "Level_{0}";
}
