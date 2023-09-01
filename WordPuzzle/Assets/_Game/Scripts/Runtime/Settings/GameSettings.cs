using Assets._Game.Scripts.Runtime.Actors;
using Assets.Scripts.Abstracts;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(GameSettings), menuName = "Settings/" + nameof(GameSettings))]
public class GameSettings : SingletonScriptableObject<GameSettings>
{
    [Header("Text")]
    public string noScoreText = "No Score";
    public string highScoreText = "High Score";

    [Header("Levels")]
    public string levelsDataPath = "Data/Levels";
    public string levelFileNameFormat = "Level_{0}";

    [Header("Player")]
    public string playerDataFileName = "PlayerData.json";

    [Header("Assets")]
    public string uiPanelsResourcePath = "Prefabs/UI/Panels";
    public string uiPanelPrefabNameFormat = "Panel_{0}";
    public LevelMenu_LevelObject levelMenu_LevelObjectPrefab;
    public Sprite lockedLevelIcon;
    public Sprite levelPlayIcon;

}
