using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlapManager : MiniGameManager
{
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private TextMeshProUGUI BestScore;
    [SerializeField] private Text startText;
    static FlapManager gameManager; // GameManager�� �̱��� �ν��Ͻ��� ������ ���� ����

    public static FlapManager Instance // �ܺο��� ���� ������ �̱��� �ν��Ͻ� ������Ƽ
    {
        get { return gameManager; } // �ν��Ͻ� ��ȯ
    }

    UIManager uiManager; // UIManager �ν��Ͻ��� ������ ����

    public UIManager UIManager // �ܺο��� UIManager�� ������ �� �ֵ��� �ϴ� ������Ƽ
    {
        get { return uiManager; } // UIManager �ν��Ͻ� ��ȯ
    }

    private void Awake() // ���� ������Ʈ�� ������ �� ���� ���� ȣ��Ǵ� �޼���
    {
        gameManager = this; // ���� �ν��Ͻ��� �̱������� ����
        uiManager = FindObjectOfType<UIManager>(); // ������ UIManager�� ã�� �Ҵ�
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartGame();
        }
    }
    protected override void Start()
    {
        Time.timeScale = 0.0f;
    }

    public void StartGame()
    {
        startText.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public override void GameOver()
    {
        base.GameOver();
        int highScore = MainManager.Instance.GetHighScore(gameId); // �ְ� ���� ��������
        Score.text = currentScore.ToString();
        BestScore.text = highScore.ToString();
    }

    public override void RestartGame()
    {
        base.RestartGame();
    }

    public override void AddScore(int points)
    {
        base.AddScore(points);
    }
}