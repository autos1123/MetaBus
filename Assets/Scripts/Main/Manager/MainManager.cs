using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    // 게임 정보 저장
    public Dictionary<string, int> HighScores { get; private set; } = new Dictionary<string, int>();
    public string PlayerName { get; set; } = "Player";

    public string selectId { get; set; }

    // 미니게임 목록
    public List<MiniGameInfo> availableGames = new List<MiniGameInfo>();

    private void Awake()
    {
        Time.timeScale = 1.0f;
        // 싱글톤 패턴 적용
        if (Instance == null)
        {
            Instance = this;
            InitializeGames();
            LoadHighScores();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        // ESC 키를 눌렀을 때 애플리케이션 종료
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC 키 눌림 - 애플리케이션 종료");

            // 에디터에서 게임을 종료하는 코드
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            // 빌드된 게임에서는 어플리케이션 종료
            Application.Quit();
#endif
        }
    }

    private void InitializeGames()
    {
        // 게임 목록 초기화 (실제 프로젝트에서는 이 부분을 확장)
        availableGames.Add(new MiniGameInfo("FlapScene", "FlappyPlane", "비행기를 조종(스페이스바, 마우스 클릭)해 장애물을 피하세요!"));
        availableGames.Add(new MiniGameInfo("DungeonScene", "TopDown_Survival", "몰려오는 몬스터를 처치(W, A, S, D로 움직이고)" +
            "마우스로 조종, 클릭으로 발사)하고 살아남으세요!"));
        availableGames.Add(new MiniGameInfo("DodgeScene", "Watch_Out!", "운전중(방향키)에 길바닥에 있는 쓰래기를 피하고 안전운전 하세요!"));
    }

    // 게임 시작
    public void StartGame()
    {
        Debug.Log($"[StartGame] gameId: {selectId}");
        SceneManager.LoadScene(selectId);
    }


    // 메인 화면으로 돌아가기
    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    // 최고 점수 갱신
    public void UpdateHighScore(string gameId, int score)
    {
        if (!HighScores.ContainsKey(gameId) || score > HighScores[gameId])
        {
            HighScores[gameId] = score;
            SaveHighScores();
        }
    }

    // 점수 저장
    private void SaveHighScores()
    {
        foreach (var score in HighScores)
        {
            PlayerPrefs.SetInt(score.Key, score.Value);
        }
        PlayerPrefs.Save();
    }
    public int GetHighScore(string gameId)
    {
        if (HighScores.ContainsKey(gameId))
            return HighScores[gameId];
        else
            return 0;
    }

    // 점수 불러오기
    private void LoadHighScores()
    {
        HighScores.Clear();
        foreach (var game in availableGames)
        {
            int score = PlayerPrefs.GetInt(game.GameId, 0);
            HighScores[game.GameId] = score;
        }
    }
}

// 미니게임 정보를 저장하는 클래스
[System.Serializable]
public class MiniGameInfo
{
    public string GameId;
    public string GameName;
    public string Description;

    public MiniGameInfo(string id, string name, string desc)
    {
        GameId = id;
        GameName = name;
        Description = desc;
    }

}
