using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMesh _scoreText;

        private int score = 0;

        public void IncreaseScore()
        {
            score += 1;
            _scoreText.text = "Score: " + score;
        }
    }
}