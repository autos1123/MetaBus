using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    // ���� ���� ����
    public Dictionary<string, int> HighScores { get; private set; } = new Dictionary<string, int>();
    public string PlayerName { get; set; } = "Player";

    public string selectId { get; set; }

    // �̴ϰ��� ���
    public List<MiniGameInfo> availableGames = new List<MiniGameInfo>();

    private void Awake()
    {
        Time.timeScale = 1.0f;
        // �̱��� ���� ����
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
        // ESC Ű�� ������ �� ���ø����̼� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC Ű ���� - ���ø����̼� ����");

            // �����Ϳ��� ������ �����ϴ� �ڵ�
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            // ����� ���ӿ����� ���ø����̼� ����
            Application.Quit();
#endif
        }
    }

    private void InitializeGames()
    {
        // ���� ��� �ʱ�ȭ (���� ������Ʈ������ �� �κ��� Ȯ��)
        availableGames.Add(new MiniGameInfo("FlapScene", "FlappyPlane", "����⸦ ����(�����̽���, ���콺 Ŭ��)�� ��ֹ��� ���ϼ���!"));
        availableGames.Add(new MiniGameInfo("DungeonScene", "TopDown_Survival", "�������� ���͸� óġ(W, A, S, D�� �����̰�)" +
            "���콺�� ����, Ŭ������ �߻�)�ϰ� ��Ƴ�������!"));
        availableGames.Add(new MiniGameInfo("DodgeScene", "Watch_Out!", "������(����Ű)�� ��ٴڿ� �ִ� �����⸦ ���ϰ� �������� �ϼ���!"));
    }

    // ���� ����
    public void StartGame()
    {
        Debug.Log($"[StartGame] gameId: {selectId}");
        SceneManager.LoadScene(selectId);
    }


    // ���� ȭ������ ���ư���
    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    // �ְ� ���� ����
    public void UpdateHighScore(string gameId, int score)
    {
        if (!HighScores.ContainsKey(gameId) || score > HighScores[gameId])
        {
            HighScores[gameId] = score;
            SaveHighScores();
        }
    }

    // ���� ����
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

    // ���� �ҷ�����
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

// �̴ϰ��� ������ �����ϴ� Ŭ����
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
