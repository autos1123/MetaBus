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

    /*�����̴� ����¥��!
     * 1. Input.GetKey()�� ���ǹ��� �ο��Ͽ� ��, ���� ����Ű�� �ԷµǾ��� ���
     * 1-1. GetKey()�� ��������� �� ������ ������Ű�� ����!
     * 2. ���������� �Է��� �Ǿ��ٸ� �ش� ����Ű�� �°� ������
     * 3. 2D�����̹Ƿ� ���ʹ� Vector2�� ���
     * 4. transform.positon = ������ġ
     * 5. new Vector2(����x�� ��ġ - 3 * �ð�, y�� ��ġ) --> ��, ������ �̵��� x���� �ʿ��ϹǷ� �ڵ����� y��ġ�� �״�� �α�!
     * 6. �����ΰ�� ������ġ�� x���� -(����)�� �ο�, �����ΰ�� ������ġ�� x���� +(���ϱ�)�� �ο��� �ǵ��� �°� �̵�
     * 7. ��, �Ʒ��� �����̴� ������ 1 ~ 6�� �������� y�ุ �����ϸ� ��.
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
