using Assets._Game.Scripts.Runtime.Managers;
using System;
using UnityEngine;

namespace Assets._Game.Scripts.Runtime.Actors
{
    public class LevelMenuUIController : Actor<MenuUIManager>
    {
        internal void InitializeLevelMenu()
        {
            var levelDatas = Resources.LoadAll<TextAsset>(GameSettings.Instance.LevelsDataPath);
        }
    }
}