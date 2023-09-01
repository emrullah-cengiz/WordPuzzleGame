using Assets._Game.Scripts.Runtime.Models.DTOs;
using Assets._Game.Scripts.Runtime.Signals;
using System;
using System.Collections.Generic;
using System.IO;
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

        private void Awake()
        {
            PlayerData = new();
        }

        #region Event Handlers

        private void OnGameStarted()
        {
            LoadPlayerData();

            LoadSummariezedLevelDatas();
        }

        #endregion

        private void LoadSummariezedLevelDatas()
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

            LevelSummaryDatas = levelDatas;
        }

        private void LoadPlayerData()
        {
            string playerDataPath = Path.Combine(Application.persistentDataPath, GameSettings.Instance.playerDataFileName);

            if (!File.Exists(playerDataPath))
                return;

            string jsonData = File.ReadAllText(playerDataPath);

            if (!string.IsNullOrWhiteSpace(jsonData))
                PlayerData = JsonUtility.FromJson<PlayerData>(jsonData);
        }

        private void SavePlayerData()
        {
            string playerDataPath = Path.Combine(Application.persistentDataPath, GameSettings.Instance.playerDataFileName);

            string playerDataJson = JsonUtility.ToJson(PlayerData);

            File.WriteAllText(playerDataPath, playerDataJson);
        }
    }
}
