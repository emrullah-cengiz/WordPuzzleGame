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

        protected override void ConfigureSubscriptions(bool status)
        {
            UISignals.Instance.onLevelMenuOpened.Subscribe(OnLevelMenuOpened, status);
        }

        #region Event Handlers

        private void OnLevelMenuOpened()
        {
            BindLevelViewDatasToObjects();
        }
        #endregion

        private HashSet<LevelMenu_LevelVM> PrepareLevelViewDatas(HashSet<LevelSummaryData> summarizedLevelDatas, PlayerData playerData)
        {
            HashSet<LevelMenu_LevelVM> levelViewDatas = new();

            if (playerData.levelProgresses == null ||
                !playerData.levelProgresses.Any())
                return levelViewDatas;

            foreach (var levelData in summarizedLevelDatas)
            {
                var levelProgress = playerData.levelProgresses.FirstOrDefault(x => x.levelId == levelData.id);

                levelViewDatas.Add(new()
                {
                    levelId = levelData.id,
                    title = levelData.title,
                    highScore = levelProgress.highScore,
                    isLocked = playerData.highestCompletedLevelId + 1 < levelData.id
                });
            }

            return levelViewDatas;
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
    }
}