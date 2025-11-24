using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{
        public static Scoreboard instance;
        public int maxScoreboardEntries = 5;
        public Transform highscoresHolderTransform;
        public GameObject scoreboardEntryObject;
        public ScoreboardSaveData savedScores;

        private void Start() 
        {
            if (instance == null)
                instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }
            
            DontDestroyOnLoad(gameObject);
            savedScores = new ScoreboardSaveData();

            for(int i = 0; i < 5; i++)
            {
                AddEntry(0);
            }
        }

        private void Update() 
        {
            // disable if not in scoreboard scene
            if(SceneManager.GetActiveScene().name == "Scoreboard")
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        // add entry from int
        public void AddEntry(int score)
        {
            ScoreboardEntryData entryData = new ScoreboardEntryData();
            entryData.entryScore = score;
            AddEntry(entryData);
        }

        // add entry from entryDate object
        private void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            bool scoreAdded = false;
            
            for(int i = 0; i < savedScores.highscores.Count; i++)
            {
                if(scoreboardEntryData.entryScore > savedScores.highscores[i].entryScore)
                {
                    savedScores.highscores.Insert(i,scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            if(!scoreAdded && savedScores.highscores.Count < maxScoreboardEntries)
            {
                savedScores.highscores.Add(scoreboardEntryData);
            }

            if(savedScores.highscores.Count > maxScoreboardEntries)
            {
                savedScores.highscores.RemoveRange(
                    maxScoreboardEntries,
                    savedScores.highscores.Count - maxScoreboardEntries);                
            }
            UpdateUI(savedScores);

        }

        // update UI to reflect new scores
        private void UpdateUI(ScoreboardSaveData savedScores)
        {
            foreach(Transform child in highscoresHolderTransform)
            {
                Destroy(child.gameObject);
            }
            foreach(ScoreboardEntryData highscore in savedScores.highscores)
            {
                Instantiate(scoreboardEntryObject,highscoresHolderTransform).
                GetComponent<ScoreboardEntryUI>().Initialize(highscore);
            }
        }
}


