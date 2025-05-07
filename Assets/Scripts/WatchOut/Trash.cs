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
        * !! ������ ������Ʈ �����ϰ� ��ȯ�ϱ� !!
        * 1. ���ϴ� ��ġ�� ��ǥ�� ���� �迭�� �ִ´�.
        * 2. �迭������ �迭 ���̸�ŭ ������ �����ϰ� ���� �ε��� �̱�
        * 3. ���� �ε����� ������ �� ������ Vector2�� �ʱ�ȭ�Ͽ� ���� �����Ѵ�.
        * 4. ��ȯ�̳� ���� ������ ���� �Ŵ������� ���� �ؾ��ϹǷ� ���� �Ŵ������� ��ȯ ����� �߰��Ѵ�.
        */
        int randomChoose = Random.Range(0, choose.Length);
        float resultChoose = choose[randomChoose];
        float y = 6.0f;
        transform.position = new Vector2(resultChoose, y);
        Debug.Log(resultChoose);

        // �����Ⱑ ��ȯ�Ǵ� �ð���ŭ �̹��� ����ӵ� ����
        SelectImg();
    }
    void Update()
    { 
        float speed = Time.deltaTime * 5.0f;
        transform.position += Vector3.down * speed;
        DestroyTrash();
    }
    /*
     * !! ������ ������Ʈ �̹����� �����ϰ� ��ȯ�ϱ� !!
     * 1. ������ �ϳ�����
     * 2. ���ҽ� ���� ���� �̹��� �ְ�
     * 3. �迭������ �迭 ���̸�ŭ ������ �����ϰ� ���� �ε��� �̱�
     * 4. ���� �ε����� ������ ���ҽ����Ͽ� �����ؼ� ������ �ҷ��´�.
     */
    public void SelectImg()
    {
        int[] selectTrash = { 0, 1, 2, 3, 4, 5 };
        int randomTrash = Random.Range(0, selectTrash.Length);
        int resultTrash = selectTrash[randomTrash];
        Debug.Log("������ : " + resultTrash);
        image.sprite = Resources.Load<Sprite>($"trash{resultTrash}");
    }
    // ������� �ڵ������� �浹üũ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DodgeManager.Instance.GameOver();
        }
    }
    // �����Ⱑ �ı��Ǵ��� üũ�ϰ� GameManager���ִ� DadgedTrash�Լ��� �ҷ��´��� ��ü�� �ı�.
    public void DestroyTrash()
    {
        if (gameObject.transform.position.y <= -5.5f)
        {
            DodgeManager.Instance.DodgedTrash();
            Destroy(gameObject);
        }
    }
}
