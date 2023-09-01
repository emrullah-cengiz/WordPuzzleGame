using Assets._Game.Scripts.Runtime.Managers;
using Assets._Game.Scripts.Runtime.Models.DTOs;
using Assets._Game.Scripts.Runtime.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Game.Scripts.Runtime.Actors
{
    public class LevelsPanelController : Actor<UIManager>
    {
        [SerializeField] private Transform levelsParent;

        private void Start()
        {
            BindLevelViewDatasToObjects();
        }

        private void BindLevelViewDatasToObjects()
        {
            var viewDatas = PrepareLevelViewDatas(Manager.DataManager.LevelSummaryDatas,
                                                  Manager.DataManager.PlayerData);

            foreach (var levelViewData in viewDatas)
            {
                var levelObj = Instantiate(GameSettings.Instance.levelMenu_LevelObjectPrefab, levelsParent);

                levelObj.Setup(levelViewData);
            }
        }

        private HashSet<LevelMenu_LevelVM> PrepareLevelViewDatas(HashSet<LevelSummaryData> summarizedLevelDatas, PlayerData playerData)
        {
            HashSet<LevelMenu_LevelVM> levelViewDatas = new();

            foreach (var levelData in summarizedLevelDatas)
            {
                var levelProgress = playerData.levelProgresses.FirstOrDefault(x => x.levelId == levelData.id);

                levelViewDatas.Add(new()
                {
                    levelId = levelData.id,
                    title = levelData.title,
                    highScore = levelProgress?.highScore ?? 0,
                    isLocked = playerData.highestCompletedLevelId + 1 < levelData.id
                });
            }

            return levelViewDatas;
        }
    }
}