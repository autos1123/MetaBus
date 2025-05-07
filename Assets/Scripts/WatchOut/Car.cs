using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /*움직이는 로직짜기!
     * 1. Input.GetKey()을 조건문에 부여하여 좌, 우측 방향키가 입력되었을 경우
     * 1-1. GetKey()를 사용한이유 꾹 눌러서 유지시키기 위함!
     * 2. 정상적으로 입력이 되었다면 해당 방향키에 맞게 움직임
     * 3. 2D게임이므로 벡터는 Vector2로 사용
     * 4. transform.positon = 현재위치
     * 5. new Vector2(현재x의 위치 - 3 * 시간, y의 위치) --> 좌, 우측의 이동은 x값만 필요하므로 자동차의 y위치는 그대로 두기!
     * 6. 좌측인경우 현재위치의 x값에 -(빼기)를 부여, 우측인경우 현재위치의 x값에 +(더하기)를 부여해 의도에 맞게 이동
     * 7. 위, 아래로 움직이는 로직은 1 ~ 6번 로직에서 y축만 변경하면 됨.
     */
    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - 3f * Time.deltaTime, transform.position.y);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + 3f * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 3f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 5f * Time.deltaTime);
        }
    }
    
}
