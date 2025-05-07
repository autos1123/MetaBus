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

        // UI 초기화
        if (gameSelectionPanel != null)
            gameSelectionPanel.SetActive(false);

    }

    // 게임 선택 UI 표시
    public void ShowGameSelectionUI()
    {
        if (gameSelectionPanel != null)
        {
            // UI 표시
            gameSelectionPanel.SetActive(true);

            // 플레이어 이동 중지
            if (mainPlayer != null)
                mainPlayer.SetMovementEnabled(false);

            // 게임 목록 생성
            PopulateGameList();
        }
    }

    // 게임 선택 UI 닫기
    public void CloseGameSelectionUI()
    {
        if (gameSelectionPanel != null)
        {
            gameSelectionPanel.SetActive(false);

            // 플레이어 이동 다시 활성화
            if (mainPlayer != null)
                mainPlayer.SetMovementEnabled(true);
        }
    }

    private void PopulateGameList()
    {
        // 기존 목록 삭제
        foreach (Transform child in gameListContent)
        {
            Destroy(child.gameObject);
        }

        // 게임 관리자에서 게임 목록 가져와서 버튼 생성
        foreach (MiniGameInfo game in MainManager.Instance.availableGames)
        {
            GameObject buttonObj = Instantiate(gameButtonPrefab, gameListContent);
            Button button = buttonObj.GetComponent<Button>();
            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();

            // 버튼 텍스트 설정
            if (buttonText != null)
                buttonText.text = game.GameName;

            // 버튼 클릭 이벤트 추가
            if (button != null)
            {
                string gameId = game.GameId;
                button.onClick.AddListener(() => SelectGame(gameId));
                Debug.Log("PopulateGameList - gameId: " + gameId); // gameId 디버그 출력
            }
        }
    }

    // 게임 선택 처리
    public void SelectGame(string gameId)
    {
        Debug.Log("SelectGame - gameId: " + gameId); // gameId 디버그 출력

        // 게임 정보 찾기
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
            // 게임 정보 UI 업데이트
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

                highScoreText.text = "최고 점수: " + highScore;
            }

            // 게임 시작 (바로 시작하거나 시작 버튼을 눌러 시작)
            //MainManager.Instance.StartGame();
        }
        else
        {
            Debug.LogError("게임을 찾을 수 없습니다. gameId: " + gameId);
        }
    }
}
