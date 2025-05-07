using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Material material;
    /* !! ���� ���ȭ�� ���� !!
     * ���� �ƴ� ������ ������ ������ ���̴�.
     * 1. Meterial�� �̿��ؼ� offset y�ุ �����ϸ� �������� ���̴� ���� ���� �� �� �ִ�.
     * 2. Meterial���� textureoffst�� ������ �Ѵ�.
     * 2-1. y���� +=���� ��� �߰����ָ� ���Ѹ� �ϼ�!
     */
    void Start()
    {
        
    }
    void Update()
    {
        // floatŸ���� offset ������ �ʴ� 0.5��ŭ �����̰���.
        float offset = Time.deltaTime * 0.5f;
        // material.mainTextureOffset�� ��Ƽ���� ����� ���� �ؽ�ó�� ������ �� �����ϰų� �������� �Ӽ��̹Ƿ�
        // Vector�� ()�ȿ� x, y ���� �������ټ� �ִ�.
        // float y = material.mainTextureOffset.y;
        // material.mainTextureOffset = new Vector2(0, y + offset);
        material.mainTextureOffset = new Vector2(0, material.mainTextureOffset.y + offset);
    }
    
}
