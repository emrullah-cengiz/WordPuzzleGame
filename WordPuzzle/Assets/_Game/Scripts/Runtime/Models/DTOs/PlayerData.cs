using System.Collections.Generic;

namespace Assets._Game.Scripts.Runtime.Models.DTOs
{
    public class PlayerData
    {
        public PlayerData()
        {
            levelProgresses = new();
        }

        public uint highestCompletedLevelId;

        public List<PlayerLevelProgressData> levelProgresses;
    }
}
