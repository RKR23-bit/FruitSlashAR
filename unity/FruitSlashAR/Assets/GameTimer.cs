using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour {
    public float totalTime = 120f;
    private float timeLeft = 120f;
    public TextMeshProUGUI timerText;
    public FruitSlicer slicer;
    public FruitSpawner spawner;
    public GameObject endScreen;
    public TextMeshProUGUI finalScoreText;
    private bool gameEnded = false;

    void Start() {
        timeLeft = totalTime;
    }

    void Update() {
        if (!gameEnded && timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            timerText.text = $"Time: {Mathf.Ceil(timeLeft)}";
            spawner.UpdateSpawnRate(timeLeft, totalTime);
        } else if (!gameEnded) {
            EndGame();
        }
    }

    public void EndGame() {
        gameEnded = true;
        int finalScore = slicer.GetScore();
        endScreen.SetActive(true);
        finalScoreText.text = $"Final Score: {finalScore}";
        Debug.Log($"Game Over! Score: {finalScore}");
    }
}