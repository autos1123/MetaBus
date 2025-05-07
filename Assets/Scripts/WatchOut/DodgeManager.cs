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

    // Trash.cs ������ ������ �ؾ��ϱ⶧���� public���� ��������
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
        // Update �Լ��� �Է��ϸ� �ʹ����� �����ϹǷ� Invoke�� �ɾ ���� �ð����� ��ȯ�� �� �ְ� �ݺ���.
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
        // UpdateHighScore �޼��带 ����Ͽ� �ְ� ���� ����
        // GameManager �Ǵ� �ٸ� Ŭ������ �� �޼��尡 �ִٰ� ����
        MainManager.Instance.UpdateHighScore("DodgeGame", dodgedCount);

        // HighScores ��ųʸ����� �ְ� ���� ��������
        bestDodgedCount = MainManager.Instance.HighScores.ContainsKey("DodgeGame")
            ? MainManager.Instance.HighScores["DodgeGame"]
            : 0;

        bestResultScoreTxt.text = bestDodgedCount.ToString();
    }

    // �����⸦ ���ϸ�(���� : �����Ⱑ �ı��Ǿ����� Trash.cs ����) dodgedCount 1�� ���
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
             * !! �ְ����� �޾ƿ��� !!
             * 1. �ְ� ������ ���ٸ�
             * 1-1. ���� ������ �ְ� ������ ����
             * 2. ���� �ְ������� �ִٸ�
             * 2-1. �ְ� ������ ���� ������ ���Ѵ�.
             * 3. �ְ� ������ ���� �������� Ŭ���
             * 3-1. �ְ� ������ �״�� ����
             * 4. �ְ� ������ ���� �������� �������
             * 4-1. ���� ������ �ְ� ������ ����
             * 5. �ְ� ���� �ð� ���浵 1 ~ 4 �����̶� ����.
             */

    /*
         * !! ��ŷ���带 �����ϱ����� �迭 ����� !!
         * 1. 10���� ���ڸ� ���� �� �ִ� �迭�� �����Ѵ�.
         * 2. ���ڰ� 10�� ������ ���
         * 2-1. �ױ� ���� ������ �迭 �ȿ� �ִ´�.
         * 3. ���ڰ� 10�� �̻��� ���
         * 3-1. �迭 �ȿ� �ִ� ���ڵ��� ���Ѵ�.
         * 4. �迭 �� ���� ���� ���� �ױ� ���� �������� Ŭ ���
         * 4-1. �ױ� ���� ������ �迭 �ȿ� �������Ѵ�.
         * 5. �迭 �� ���� ���� ���� �ױ� ���� �������� ���� ���
         * 5-1. �迭 �� ���� �������� ���ְ� �ױ� ���� ������ �迭 �ȿ� �ִ´�.
         */
}
