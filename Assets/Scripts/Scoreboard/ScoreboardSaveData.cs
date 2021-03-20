using System.Collections.Generic;

namespace Orbz.Scoreboards
{
    [System.Serializable]
    public class ScoreboardSaveData
    {
        public List<ScoreboardEntryData> highscores = new List<ScoreboardEntryData>();
    }
}