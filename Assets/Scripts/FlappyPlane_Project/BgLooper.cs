using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Pipes;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5; // 화면에 반복적으로 표시할 배경의 개수

    public int obstacleCount = 0; // 장애물 총 개수
    public Vector3 obstacleLastPosition = Vector3.zero; // 마지막 장애물의 위치 (초기값은 (0, 0, 0))

    // Start는 게임 시작 시 한 번 호출되는 Unity 메서드
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        // 씬에 존재하는 모든 Obstacle 컴포넌트를 가진 오브젝트를 찾아 배열로 저장

        obstacleLastPosition = obstacles[0].transform.position;
        // 첫 번째 장애물의 위치를 기준으로 장애물 배치를 시작

        obstacleCount = obstacles.Length;
        // 장애물 개수 저장

        for (int i = 0; i < obstacleCount; i++) // 모든 장애물을 순회하며
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
            // 장애물을 랜덤한 위치에 배치하고, 가장 마지막 배치된 위치를 갱신
        }
    }

    // 트리거 충돌이 발생했을 때 호출되는 Unity 이벤트 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BackGround")) // 충돌한 객체가 "BackGround" 태그를 가지고 있으면
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            // 충돌한 배경 오브젝트의 가로 길이 가져오기

            Vector3 pos = collision.transform.position;
            // 현재 배경 위치 저장

            pos.x += widthOfBgObject * numBgCount;
            // 배경의 x 위치를 다음 위치로 이동 (오른쪽 끝으로)

            collision.transform.position = pos;
            // 실제 배경 위치 갱신

            return; // 더 이상 처리하지 않고 함수 종료
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        // 충돌한 객체에서 Obstacle 컴포넌트를 가져옴

        if (obstacle) // 만약 Obstacle이 있다면
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
            // 장애물을 랜덤 위치에 재배치하고 위치 갱신
        }
    }
}
