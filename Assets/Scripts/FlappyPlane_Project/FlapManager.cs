using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlapManager : MonoBehaviour
{
    static FlapManager gameManager; // GameManager의 싱글톤 인스턴스를 저장할 정적 변수

    public static FlapManager Instance // 외부에서 접근 가능한 싱글톤 인스턴스 프로퍼티
    {
        get { return gameManager; } // 인스턴스 반환
    }

    private int currentScore = 0; // 현재 점수를 저장할 변수
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

    private void Start() // 게임이 시작될 때 호출되는 메서드
    {
        uiManager.UpdateScore(0); // 초기 점수를 UI에 표시
    }

    public void GameOver() // 게임 오버 처리 메서드
    {
        Debug.Log("Game Over"); // 디버그 로그 출력
        uiManager.SetRestart(); // UIManager를 통해 재시작 UI 설정
    }

    public void RestartGame() // 게임을 재시작하는 메서드
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬을 다시 로드하여 게임 재시작
    }

    public void AddScore(int score) // 점수를 추가하는 메서드
    {
        currentScore += score; // 현재 점수에 전달된 점수를 추가
        uiManager.UpdateScore(currentScore); // 변경된 점수를 UI에 반영
        Debug.Log("Score: " + currentScore); // 현재 점수를 디버그 로그로 출력
    }
}