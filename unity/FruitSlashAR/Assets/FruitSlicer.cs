using UnityEngine;
using TMPro;

public class FruitSlicer : MonoBehaviour
{
    public GameObject slashEffect;        // Optional particle effect for slicing
    public TextMeshProUGUI scoreText;     // Reference to the ScoreText UI element
    public GameTimer gameTimer;           // Reference to GameTimer script
    private int score = 0;                // Player's current score

    void Update()
    {
        // Handle touch input (works for mobile/WebXR and simulates with mouse in Editor)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                HandleHit(hit);
            }
        }
        // Simulate touch with mouse click in Editor
        else if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                HandleHit(hit);
            }
        }
    }

    private void HandleHit(RaycastHit hit)
    {
        if (hit.collider.CompareTag("Fruit"))
        {
            Destroy(hit.collider.gameObject);
            if (slashEffect != null)
            {
                Instantiate(slashEffect, hit.point, Quaternion.identity);
            }
            score++;
            UpdateScoreText();
        }
        else if (hit.collider.CompareTag("Bomb"))
        {
            Destroy(hit.collider.gameObject);
            if (slashEffect != null)
            {
                Instantiate(slashEffect, hit.point, Quaternion.identity);
            }
            score -= 5;
            score = Mathf.Max(0, score); // Ensure score doesn’t go negative
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    public int GetScore()
    {
        return score;
    }
}