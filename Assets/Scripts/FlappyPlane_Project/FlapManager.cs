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
    static FlapManager gameManager; // GameManager의 싱글톤 인스턴스를 저장할 정적 변수

    public static FlapManager Instance // 외부에서 접근 가능한 싱글톤 인스턴스 프로퍼티
    {
        get { return gameManager; } // 인스턴스 반환
    }

    UIManager uiManager; // UIManager 인스턴스를 저장할 변수

    public UIManager UIManager // 외부에서 UIManager에 접근할 수 있도록 하는 프로퍼티
    {
        get { return uiManager; } // UIManager 인스턴스 반환
    }

    private void Awake() // 게임 오브젝트가 생성될 때 가장 먼저 호출되는 메서드
    {
        gameManager = this; // 현재 인스턴스를 싱글톤으로 지정
        uiManager = FindObjectOfType<UIManager>(); // 씬에서 UIManager를 찾아 할당
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
        int highScore = MainManager.Instance.GetHighScore(gameId); // 최고 점수 가져오기
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