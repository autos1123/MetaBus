using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public static MainUIManager Instance { get; private set; }

    [Header("Game Selection UI")]
    public GameObject gameSelectionPanel;
    public Transform gameListContent;
    public GameObject gameButtonPrefab;

    [Header("Game Info UI")]
    public Text gameTitle;
    public Text gameDescription;
    public Text highScoreText;

    private MainPlayer mainPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();

        // UI �ʱ�ȭ
        if (gameSelectionPanel != null)
            gameSelectionPanel.SetActive(false);

    }

    // ���� ���� UI ǥ��
    public void ShowGameSelectionUI()
    {
        if (gameSelectionPanel != null)
        {
            // UI ǥ��
            gameSelectionPanel.SetActive(true);

            // �÷��̾� �̵� ����
            if (mainPlayer != null)
                mainPlayer.SetMovementEnabled(false);

            // ���� ��� ����
            PopulateGameList();
        }
    }

    // ���� ���� UI �ݱ�
    public void CloseGameSelectionUI()
    {
        if (gameSelectionPanel != null)
        {
            gameSelectionPanel.SetActive(false);

            // �÷��̾� �̵� �ٽ� Ȱ��ȭ
            if (mainPlayer != null)
                mainPlayer.SetMovementEnabled(true);
        }
    }

    private void PopulateGameList()
    {
        // ���� ��� ����
        foreach (Transform child in gameListContent)
        {
            Destroy(child.gameObject);
        }

        // ���� �����ڿ��� ���� ��� �����ͼ� ��ư ����
        foreach (MiniGameInfo game in MainManager.Instance.availableGames)
        {
            GameObject buttonObj = Instantiate(gameButtonPrefab, gameListContent);
            Button button = buttonObj.GetComponent<Button>();
            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();

            // ��ư �ؽ�Ʈ ����
            if (buttonText != null)
                buttonText.text = game.GameName;

            // ��ư Ŭ�� �̺�Ʈ �߰�
            if (button != null)
            {
                string gameId = game.GameId;
                button.onClick.AddListener(() => SelectGame(gameId));
                Debug.Log("PopulateGameList - gameId: " + gameId); // gameId ����� ���
            }
        }
    }

    // ���� ���� ó��
    public void SelectGame(string gameId)
    {
        Debug.Log("SelectGame - gameId: " + gameId); // gameId ����� ���

        // ���� ���� ã��
        MiniGameInfo selectedGame = null;
        foreach (MiniGameInfo game in MainManager.Instance.availableGames)
        {
            if (game.GameId == gameId)
            {
                selectedGame = game;
                break;
            }
        }

        if (selectedGame != null)
        {
            // ���� ���� UI ������Ʈ
            if (gameId != null)
            {
                MainManager.Instance.selectId = gameId;
            }
            if (gameTitle != null)
                gameTitle.text = selectedGame.GameName;

            if (gameDescription != null)
                gameDescription.text = selectedGame.Description;

            if (highScoreText != null)
            {
                int highScore = 0;
                if (MainManager.Instance.HighScores.ContainsKey(gameId))
                    highScore = MainManager.Instance.HighScores[gameId];

                highScoreText.text = "�ְ� ����: " + highScore;
            }

            // ���� ���� (�ٷ� �����ϰų� ���� ��ư�� ���� ����)
            //MainManager.Instance.StartGame();
        }
        else
        {
            Debug.LogError("������ ã�� �� �����ϴ�. gameId: " + gameId);
        }
    }
}
