using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;     // Slider UI 요소
    //[SerializeField] private Text healthText;         // 체력 텍스트 UI (선택 사항)

    private StatHandler statHandler;  // StatHandler를 동적으로 참조할 변수

    private void Start()
    {
        // Player 오브젝트에서 StatHandler 컴포넌트를 찾아 연결
        statHandler = FindObjectOfType<StatHandler>();

        if (statHandler != null)
        {
            healthSlider.maxValue = 100;  // 최대 체력
            healthSlider.value = statHandler.Health;  // 초기 체력 값

            //if (healthText != null)
                //healthText.text = statHandler.Health.ToString();
        }
    }

    private void Update()
    {
        // 체력이 변경될 때마다 UI 갱신
        if (statHandler != null)
        {
            healthSlider.value = statHandler.Health;

            //if (healthText != null)
                //healthText.text = statHandler.Health.ToString();
        }
    }
}
