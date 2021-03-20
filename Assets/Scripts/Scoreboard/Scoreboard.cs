using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.SceneManagement;

namespace Orbz.Scoreboards
{
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform highscoreHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        [Header("Test")]
        [SerializeField] private ScoreboardEntryData testEntryData = new ScoreboardEntryData();

        private string SavePath => $"{Application.persistentDataPath}/scores.json";

        private void Start()
        {
            ScoreboardSaveData savedScores = GetSavedScores();
            UpdateUI(savedScores);
            SaveScores(savedScores);
        }

        [ContextMenu("Add Test Entry")]
        public void AddTestEntry()
        {
            AddEntry(testEntryData);
        }

        private ScoreboardSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardSaveData();
            }

            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreboardSaveData>(json);
            }
        }

        private void SaveScores(ScoreboardSaveData scoreboardSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json);
            }
        }

        private void UpdateUI(ScoreboardSaveData savedScores)
        {
            if (SceneManager.GetActiveScene().buildIndex > 0) return;
            foreach (Transform child in highscoreHolderTransform)
            {
                Destroy(child.gameObject);
            }

            foreach (ScoreboardEntryData highscore in savedScores.highscores)
            {
                var checkedHighscore = CheckHighScore(highscore);
                var child = Instantiate(scoreboardEntryObject, highscoreHolderTransform);
                child.GetComponent<ScoreboardEntryUI>().Initialise(checkedHighscore);
            }

            SaveScores(savedScores);
        }

        public void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();
            ScoreboardEntryData hashedScoreboardEntryData = CreateIntegrityHash(scoreboardEntryData);

            Debug.Log("Adding new score entry...");

            bool scoreAdded = false;

            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if (hashedScoreboardEntryData.entryScore > savedScores.highscores[i].entryScore)
                {
                    savedScores.highscores.Insert(i, hashedScoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            if (!scoreAdded && savedScores.highscores.Count < maxScoreboardEntries)
            {
                savedScores.highscores.Add(hashedScoreboardEntryData);
            }

            if (savedScores.highscores.Count > maxScoreboardEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreboardEntries, savedScores.highscores.Count - maxScoreboardEntries);
            }

            UpdateUI(savedScores);
            SaveScores(savedScores);

            Debug.Log("New entry added succesfully");
        }

        private ScoreboardEntryData CreateIntegrityHash(ScoreboardEntryData scoreboardEntryData)
        {
            string combinedValues = scoreboardEntryData.entryName + scoreboardEntryData.entryScore.ToString();
            scoreboardEntryData.entryHash = HashString(combinedValues);
            return scoreboardEntryData;
        }

        private string HashString(string stringToHash)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                var sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        private ScoreboardEntryData CheckHighScore(ScoreboardEntryData highscore)
        {
            string combinedValues = highscore.entryName + highscore.entryScore.ToString();
            string hashedString = HashString(combinedValues);

            if (highscore.entryHash != hashedString)
            {
                highscore.entryName = "1337Haxx0r";
                highscore.entryScore = 0;
                highscore.entryHash = HashString(highscore.entryName + highscore.entryScore.ToString());
            }

            return highscore;

        }
    }
}


