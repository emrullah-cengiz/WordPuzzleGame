using Assets._Game.Scripts.Runtime.Enums;
using UnityEngine.Events;

namespace Assets._Game.Scripts.Runtime.Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityEvent<UIPanel, bool> onPanelOpened;
        public UnityEvent<UIPanel> onPanelClosed;
        public UnityEvent onLevelMenuOpened;
    }
}
