using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DodgeManager : MiniGameManager
{

    public static DodgeManager Instance;

    public GameObject car;
    public GameObject trash;
    public GameObject infoImg;

    public Text infoScoreTxt;
    public Text scoreTxt;
    public Text bestResultScoreTxt;

    // Trash.cs 에서도 참조를 해야하기때문에 public으로 변수생성
    public int dodgedCount = 0;
    int bestDodgedCount = 0;

    public void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
    }
    protected override void Start()
    {
        Time.timeScale = 0.0f;
        base.Start();
        // Update 함수에 입력하면 너무많이 생성하므로 Invoke를 걸어서 일정 시간마다 소환할 수 있게 반복함.
        InvokeRepeating("MakeTrash", 0.0f, 1.0f);
        //InvokeRepeating("MakeTrash", 0.0f, 5.0f);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            infoImg.gameObject.SetActive(false);
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMain();
        }

    }
    void MakeTrash()
    {
        Instantiate(trash);
    }
    public override void GameOver()
    {
        base.GameOver();
        scoreText.text = currentScore.ToString();
        // UpdateHighScore 메서드를 사용하여 최고 점수 갱신
        // GameManager 또는 다른 클래스에 이 메서드가 있다고 가정
        MainManager.Instance.UpdateHighScore("DodgeGame", dodgedCount);

        // HighScores 딕셔너리에서 최고 점수 가져오기
        bestDodgedCount = MainManager.Instance.HighScores.ContainsKey("DodgeGame")
            ? MainManager.Instance.HighScores["DodgeGame"]
            : 0;

        bestResultScoreTxt.text = bestDodgedCount.ToString();
    }

    // 쓰래기를 피하면(기준 : 쓰래기가 파괴되었을때 Trash.cs 참조) dodgedCount 1씩 상승
    public void DodgedTrash()
    {
        dodgedCount++;
        AddScore(1);
    }
    public void StartGame()
    {
        Time.timeScale = 1.0f;
    }
   
    // 
    /*
             * !! 최고점수 받아오기 !!
             * 1. 최고 점수가 없다면
             * 1-1. 현재 점수를 최고 점수로 변경
             * 2. 만약 최고점수가 있다면
             * 2-1. 최고 점수랑 현재 점수를 비교한다.
             * 3. 최고 점수가 현재 점수보다 클경우
             * 3-1. 최고 점수는 그대로 유지
             * 4. 최고 점수가 현재 점수보다 작을경우
             * 4-1. 현재 점수를 최고 점수로 변경
             * 5. 최고 생존 시간 변경도 1 ~ 4 로직이랑 동일.
             */

    /*
         * !! 랭킹보드를 생성하기위한 배열 만들기 !!
         * 1. 10개의 인자를 담을 수 있는 배열을 생성한다.
         * 2. 인자가 10개 이하일 경우
         * 2-1. 죽기 직전 점수를 배열 안에 넣는다.
         * 3. 인자가 10개 이상일 경우
         * 3-1. 배열 안에 있는 인자들을 비교한다.
         * 4. 배열 안 제일 작은 수가 죽기 직전 점수보다 클 경우
         * 4-1. 죽기 직전 점수는 배열 안에 못들어가게한다.
         * 5. 배열 안 제일 작은 수가 죽기 직전 점수보다 작을 경우
         * 5-1. 배열 안 제일 작은수를 없애고 죽기 직전 점수를 배열 안에 넣는다.
         */
}
