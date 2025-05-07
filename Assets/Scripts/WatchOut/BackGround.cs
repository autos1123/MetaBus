using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Material material;
    /* !! 무한 배경화면 로직 !!
     * 흔히 아는 런게임 로직을 가져올 것이다.
     * 1. Meterial을 이용해서 offset y축만 조절하면 무한으로 보이는 맵을 생성 할 수 있다.
     * 2. Meterial에서 textureoffst에 접근을 한다.
     * 2-1. y축을 +=으로 계속 추가해주면 무한맵 완성!
     */
    void Start()
    {
        
    }
    void Update()
    {
        // float타입인 offset 변수를 초당 0.5만큼 움직이게함.
        float offset = Time.deltaTime * 0.5f;
        // material.mainTextureOffset는 머티리얼에 적용된 메인 텍스처의 오프셋 을 설정하거나 가져오는 속성이므로
        // Vector값 ()안에 x, y 값을 설정해줄수 있다.
        // float y = material.mainTextureOffset.y;
        // material.mainTextureOffset = new Vector2(0, y + offset);
        material.mainTextureOffset = new Vector2(0, material.mainTextureOffset.y + offset);
    }
    
}
