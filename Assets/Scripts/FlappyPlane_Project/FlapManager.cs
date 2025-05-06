using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlapManager : MonoBehaviour
{
    static FlapManager gameManager; // GameManager�� �̱��� �ν��Ͻ��� ������ ���� ����

    public static FlapManager Instance // �ܺο��� ���� ������ �̱��� �ν��Ͻ� ������Ƽ
    {
        get { return gameManager; } // �ν��Ͻ� ��ȯ
    }

    private int currentScore = 0; // ���� ������ ������ ����
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

    private void Start() // ������ ���۵� �� ȣ��Ǵ� �޼���
    {
        uiManager.UpdateScore(0); // �ʱ� ������ UI�� ǥ��
    }

    public void GameOver() // ���� ���� ó�� �޼���
    {
        Debug.Log("Game Over"); // ����� �α� ���
        uiManager.SetRestart(); // UIManager�� ���� ����� UI ����
    }

    public void RestartGame() // ������ ������ϴ� �޼���
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� ���� �ٽ� �ε��Ͽ� ���� �����
    }

    public void AddScore(int score) // ������ �߰��ϴ� �޼���
    {
        currentScore += score; // ���� ������ ���޵� ������ �߰�
        uiManager.UpdateScore(currentScore); // ����� ������ UI�� �ݿ�
        Debug.Log("Score: " + currentScore); // ���� ������ ����� �α׷� ���
    }
}