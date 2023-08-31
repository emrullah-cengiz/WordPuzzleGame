using Assets._Game.Scripts.Runtime.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._Game.Scripts.Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            CoreSignals.Instance.onGameStarted?.Invoke();
        }
    }
}
