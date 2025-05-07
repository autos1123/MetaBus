using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public abstract class MiniGameManager : MonoBehaviour
{
    public string gameId;
    public Text scoreText;
    public GameObject gameOverPanel;

    protected int currentScore = 0;
    protected bool isGameOver = false;

    protected virtual void Start()
    {
        // UI 초기화
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateScoreUI();

    }

    // 점수 업데이트
    public virtual void AddScore(int points)
    {
        if (!isGameOver)
        {
            currentScore += points;
            UpdateScoreUI();
        }
    }

    // 점수 UI 업데이트
    protected virtual void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "현재 점수 : " + currentScore;
    }

    // 게임 종료
    public virtual void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            scoreText.gameObject.SetActive(false);

            // 게임 종료 패널 표시
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);

            // 최고 점수 갱신
            MainManager.Instance.UpdateHighScore(gameId, currentScore);
            Time.timeScale = 0.0f;
        }
    }

    // 메인 화면으로 돌아가기
    public virtual void ReturnToMain()
    {
        MainManager.Instance.ReturnToMain();
    }

    // 게임 다시 시작
    public virtual void RestartGame()
    {
        MainManager.Instance.StartGame();
    }
}