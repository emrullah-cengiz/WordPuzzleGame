using Assets._Game.Scripts.Runtime.Models.DTOs;
using Assets._Game.Scripts.Runtime.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Game.Scripts.Runtime.Managers
{
    public class DataManager : Manager<DataManager>
    {
        #region Properties

        public PlayerData PlayerData { get; private set; }
        public HashSet<LevelSummaryData> LevelSummaryDatas { get; private set; }

        #endregion

        protected override void ConfigureSubscriptions(bool status)
        {
            CoreSignals.Instance.onGameStarted.Subscribe(OnGameStarted, status);
        }

        #region Event Handlers

        private void OnGameStarted()
        {
            LoadPlayerData();

            LoadSummariezedLevelDatas();
        }

        #endregion

        private HashSet<LevelSummaryData> LoadSummariezedLevelDatas()
        {
            HashSet<LevelSummaryData> levelDatas = new();

            var levelDataAssets = Resources.LoadAll<TextAsset>(GameSettings.Instance.levelsDataPath);

            foreach (var leveldata in levelDataAssets)
            {
                LevelSummaryData viewData = JsonUtility.FromJson<LevelSummaryData>(leveldata.text);

                var levelId = leveldata.name.Split('_')[1];

                viewData.id = Convert.ToUInt32(levelId);

                levelDatas.Add(viewData);
            }

            return levelDatas;
        }

        private void LoadPlayerData()
        {
            string jsonData = PlayerPrefs.GetString(GameSettings.Instance.playerDataFileName, null);

            if (!string.IsNullOrWhiteSpace(jsonData))
                PlayerData = JsonUtility.FromJson<PlayerData>(jsonData);
            else
                PlayerData = new();
        }
    }
}
