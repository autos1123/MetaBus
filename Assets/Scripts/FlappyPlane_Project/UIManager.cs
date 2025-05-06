using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    // 게임 시작 시 실행되는 초기화 함수
    public void Start()
    {
        // restartText가 연결되지 않았을 경우 오류 출력
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        // scoreText가 연결되지 않았을 경우 오류 출력하고 중단
        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        // 처음에는 "다시 시작" 텍스트를 숨겨둠
        restartText.gameObject.SetActive(false);
    }

    // 게임 오버 상태에서 다시 시작 메시지를 보이게 함
    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    // 현재 점수를 UI에 업데이트
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString(); // 정수를 문자열로 변환하여 출력
    }
}