using Assets._Game.Scripts.Runtime.Enums;
using Assets._Game.Scripts.Runtime.Managers;
using Assets._Game.Scripts.Runtime.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Game.Scripts.Runtime.Actors
{
    public class IntroPanelController : Actor<UIManager>
    {
        [SerializeField] private Button LevelsPanelButton;

        protected override void ConfigureSubscriptions(bool status)
        {
            LevelsPanelButton.onClick.Subscribe(OnLevelsPanelBtnClicked, status);
        }

        private void OnLevelsPanelBtnClicked()
        {
            UISignals.Instance.onPanelOpened?.Invoke(UIPanel.LevelsMenu, true);
        }
    }
}