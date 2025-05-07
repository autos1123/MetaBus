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
        // UI �ʱ�ȭ
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateScoreUI();

    }

    // ���� ������Ʈ
    public virtual void AddScore(int points)
    {
        if (!isGameOver)
        {
            currentScore += points;
            UpdateScoreUI();
        }
    }

    // ���� UI ������Ʈ
    protected virtual void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "���� ���� : " + currentScore;
    }

    // ���� ����
    public virtual void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            scoreText.gameObject.SetActive(false);

            // ���� ���� �г� ǥ��
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);

            // �ְ� ���� ����
            MainManager.Instance.UpdateHighScore(gameId, currentScore);
            Time.timeScale = 0.0f;
        }
    }

    // ���� ȭ������ ���ư���
    public virtual void ReturnToMain()
    {
        MainManager.Instance.ReturnToMain();
    }

    // ���� �ٽ� ����
    public virtual void RestartGame()
    {
        MainManager.Instance.StartGame();
    }
}