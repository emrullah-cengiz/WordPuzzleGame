﻿using Assets._Game.Scripts.Runtime.Enums;
using Assets._Game.Scripts.Runtime.Managers;
using Assets._Game.Scripts.Runtime.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Game.Scripts.Runtime.Actors
{
    public class UIPanelsController : Actor<UIManager>
    {
        [SerializeField] private Transform _panelsParent;

        private Dictionary<UIPanel, GameObject> _openPanels;

        protected override void ConfigureSubscriptions(bool status)
        {
            CoreSignals.Instance.onGameStarted.Subscribe(OnGameStarted, status);
            UISignals.Instance.onPanelOpened.Subscribe(OpenPanel, status);
            UISignals.Instance.onPanelClosed.Subscribe(ClosePanel, status);
        }

        private void Awake() => _openPanels = new();

        private void OnGameStarted()
        {
            UISignals.Instance.onPanelOpened?.Invoke(UIPanel.Intro, false);
        }

        private void OpenPanel(UIPanel uiPanel, bool closeCurrents)
        {
            if (_openPanels.ContainsKey(uiPanel))
                return;

            var gameSettings = GameSettings.Instance;

            if (closeCurrents)
            {
                foreach (var panel in _openPanels)
                    Destroy(panel.Value);

                _openPanels.Clear();
            }

            string panelPrefabPath = $"{gameSettings.uiPanelsResourcePath}/" +
                                     $"{string.Format(gameSettings.uiPanelPrefabNameFormat, uiPanel.ToString())}";

            Debug.Log(panelPrefabPath);

            _openPanels.Add(uiPanel, Instantiate(Resources.Load<GameObject>(panelPrefabPath), _panelsParent));
        }

        private void ClosePanel(UIPanel uiPanel)
        {
            if (!_openPanels.TryGetValue(uiPanel, out var panel))
                return;

            Destroy(panel);

            _openPanels.Remove(uiPanel);
        }
    }
}