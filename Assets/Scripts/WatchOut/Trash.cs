using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public SpriteRenderer image;

    float[] choose = { -4.15f, -1.95f, 0.23f, 2.7f };
    void Start()
    {
        /*
        * !! 쓰래기 오브젝트 랜덤하게 소환하기 !!
        * 1. 원하는 위치의 좌표를 따서 배열에 넣는다.
        * 2. 배열생성후 배열 길이만큼 범위를 설정하고 랜덤 인덱스 뽑기
        * 3. 랜덤 인덱스를 뽑으면 그 값으로 Vector2를 초기화하여 값을 설정한다.
        * 4. 소환이나 게임 오버는 게임 매니저에서 관리 해야하므로 게임 매니저에서 소환 기능을 추가한다.
        */
        int randomChoose = Random.Range(0, choose.Length);
        float resultChoose = choose[randomChoose];
        float y = 6.0f;
        transform.position = new Vector2(resultChoose, y);
        Debug.Log(resultChoose);

        // 쓰래기가 소환되는 시간만큼 이미지 변경속도 조정
        SelectImg();
    }
    void Update()
    { 
        float speed = Time.deltaTime * 5.0f;
        transform.position += Vector3.down * speed;
        DestroyTrash();
    }
    /*
     * !! 쓰래기 오브젝트 이미지를 랜덤하게 소환하기 !!
     * 1. 프리팹 하나만들어서
     * 2. 리소스 폴더 만들어서 이미지 넣고
     * 3. 배열생성후 배열 길이만큼 범위를 설정하고 랜덤 인덱스 뽑기
     * 4. 랜덤 인덱스를 뽑으면 리소스파일에 접근해서 사진을 불러온다.
     */
    public void SelectImg()
    {
        int[] selectTrash = { 0, 1, 2, 3, 4, 5 };
        int randomTrash = Random.Range(0, selectTrash.Length);
        int resultTrash = selectTrash[randomTrash];
        Debug.Log("쓰래기 : " + resultTrash);
        image.sprite = Resources.Load<Sprite>($"trash{resultTrash}");
    }
    // 쓰래기와 자동차간에 충돌체크
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DodgeManager.Instance.GameOver();
        }
    }
    // 쓰래기가 파괴되는지 체크하고 GameManager에있는 DadgedTrash함수를 불러온다음 객체를 파괴.
    public void DestroyTrash()
    {
        if (gameObject.transform.position.y <= -5.5f)
        {
            DodgeManager.Instance.DodgedTrash();
            Destroy(gameObject);
        }
    }
}
