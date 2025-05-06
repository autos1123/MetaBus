using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Pipes;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5; // ȭ�鿡 �ݺ������� ǥ���� ����� ����

    public int obstacleCount = 0; // ��ֹ� �� ����
    public Vector3 obstacleLastPosition = Vector3.zero; // ������ ��ֹ��� ��ġ (�ʱⰪ�� (0, 0, 0))

    // Start�� ���� ���� �� �� �� ȣ��Ǵ� Unity �޼���
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        // ���� �����ϴ� ��� Obstacle ������Ʈ�� ���� ������Ʈ�� ã�� �迭�� ����

        obstacleLastPosition = obstacles[0].transform.position;
        // ù ��° ��ֹ��� ��ġ�� �������� ��ֹ� ��ġ�� ����

        obstacleCount = obstacles.Length;
        // ��ֹ� ���� ����

        for (int i = 0; i < obstacleCount; i++) // ��� ��ֹ��� ��ȸ�ϸ�
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
            // ��ֹ��� ������ ��ġ�� ��ġ�ϰ�, ���� ������ ��ġ�� ��ġ�� ����
        }
    }

    // Ʈ���� �浹�� �߻����� �� ȣ��Ǵ� Unity �̺�Ʈ �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BackGround")) // �浹�� ��ü�� "BackGround" �±׸� ������ ������
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            // �浹�� ��� ������Ʈ�� ���� ���� ��������

            Vector3 pos = collision.transform.position;
            // ���� ��� ��ġ ����

            pos.x += widthOfBgObject * numBgCount;
            // ����� x ��ġ�� ���� ��ġ�� �̵� (������ ������)

            collision.transform.position = pos;
            // ���� ��� ��ġ ����

            return; // �� �̻� ó������ �ʰ� �Լ� ����
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        // �浹�� ��ü���� Obstacle ������Ʈ�� ������

        if (obstacle) // ���� Obstacle�� �ִٸ�
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
            // ��ֹ��� ���� ��ġ�� ���ġ�ϰ� ��ġ ����
        }
    }
}
