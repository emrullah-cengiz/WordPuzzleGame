using Assets._Game.Scripts.Runtime.Managers;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Game.Scripts.Runtime.Actors
{
    public class LevelMenu_LevelObject : Actor<UIManager>
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _highScoreText;
        [SerializeField] private Button _playButton;
        [SerializeField] private Image _playIcon;

        public void Setup(LevelMenu_LevelVM viewData)
        {
            _titleText.text = viewData.title;
            _highScoreText.text = viewData.highScore.ToString();

            GameSettings gameSettings = GameSettings.Instance;
            _playIcon.sprite = viewData.isLocked ? gameSettings.lockedLevelIcon :
                                                   gameSettings.levelPlayIcon;

            _playButton.interactable = !viewData.isLocked;
        }
    }
}