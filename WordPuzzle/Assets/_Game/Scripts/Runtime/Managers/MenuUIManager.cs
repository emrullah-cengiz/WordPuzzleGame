using Assets._Game.Scripts.Runtime.Actors;
using Assets._Game.Scripts.Runtime.Signals;
using System;
using UnityEngine;

namespace Assets._Game.Scripts.Runtime.Managers
{
    public class MenuUIManager : Manager<MenuUIManager>
    {
        [SerializeField] private LevelMenuUIController _levelMenuUIController;

        protected override void ConfigureSubscriptions(bool status)
        {
            CoreSignals.Instance?.onGameStarted.Subscribe(OnGameStarted, status);
        }

        private void OnGameStarted()
        {
            _levelMenuUIController.InitializeLevelMenu();
        }
    }
}
