using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DungeonManager : MiniGameManager
{
    public static DungeonManager instance;

    public PlayerController player { get; private set; }
    private ResourceController _playerResourceController;

    [SerializeField] private int currentWaveIndex = 0;
    [SerializeField] private Text waveText;
    [SerializeField] private Text startInfoText;

    private EnemyManager enemyManager;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        enemyManager = GetComponentInChildren<EnemyManager>();
        enemyManager.Init(this);
    }

    public void StartGame()
    {
        startInfoText.gameObject.SetActive(false);
        StartNextWave();
    }

    void StartNextWave()
    {
        currentWaveIndex += 1;
        enemyManager.StartWave(1 + currentWaveIndex / 5);
    }

    public void EndOfWave()
    {
        waveText.text = "현재 웨이브 : " + currentWaveIndex;
        // 웨이브 번호에 따라 점수 계산
        int pointsForWave = 100 + (currentWaveIndex * 20);  // 웨이브 번호에 따라 점수 증가
        AddScore(pointsForWave); // 계산된 점수 추가
        StartNextWave();
    }

    public override void GameOver()
    {
        enemyManager.StopWave();
        waveText.gameObject.SetActive(false);
        base.GameOver();
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartGame();
        }
    }
    public override void AddScore(int points)
    {
        base.AddScore(points);
    }
}
