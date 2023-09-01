using Assets._Game.Scripts.Runtime.Actors;
using Assets._Game.Scripts.Runtime.Signals;
using System;
using UnityEngine;

namespace Assets._Game.Scripts.Runtime.Managers
{
    public class UIManager : Manager<UIManager>
    {
        #region Manager references

        public DataManager DataManager;

        #endregion

        #region Actors

        [SerializeField] private UIPanelsController _uiPanelsController;

        #endregion
    }
}
