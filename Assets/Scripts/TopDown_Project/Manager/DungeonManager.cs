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
        waveText.text = "���� ���̺� : " + currentWaveIndex;
        // ���̺� ��ȣ�� ���� ���� ���
        int pointsForWave = 100 + (currentWaveIndex * 20);  // ���̺� ��ȣ�� ���� ���� ����
        AddScore(pointsForWave); // ���� ���� �߰�
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
