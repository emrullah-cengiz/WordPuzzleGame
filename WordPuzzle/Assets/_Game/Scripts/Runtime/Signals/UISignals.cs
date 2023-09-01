using Assets._Game.Scripts.Runtime.Enums;
using System;
using UnityEngine.Events;

namespace Assets._Game.Scripts.Runtime.Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityEvent<UIPanel, bool> onPanelOpened;
        public UnityEvent<UIPanel> onPanelClosed;

        public UnityEvent onLevelMenuOpened;

        private void OnEnable()
        {
            onPanelOpened.Subscribe(OnPanelOpened, true);
        }

        private void OnPanelOpened(UIPanel uiPanel, bool closeCurrents)
        {
            var relatedEvent = uiPanel switch
            {
                UIPanel.LevelsMenu => onLevelMenuOpened,
                _ => null,
            };

            relatedEvent?.Invoke();
        }
    }
}
