using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;     // Slider UI ���
    //[SerializeField] private Text healthText;         // ü�� �ؽ�Ʈ UI (���� ����)

    private StatHandler statHandler;  // StatHandler�� �������� ������ ����

    private void Start()
    {
        // Player ������Ʈ���� StatHandler ������Ʈ�� ã�� ����
        statHandler = FindObjectOfType<StatHandler>();

        if (statHandler != null)
        {
            healthSlider.maxValue = 100;  // �ִ� ü��
            healthSlider.value = statHandler.Health;  // �ʱ� ü�� ��

            //if (healthText != null)
                //healthText.text = statHandler.Health.ToString();
        }
    }

    private void Update()
    {
        // ü���� ����� ������ UI ����
        if (statHandler != null)
        {
            healthSlider.value = statHandler.Health;

            //if (healthText != null)
                //healthText.text = statHandler.Health.ToString();
        }
    }
}
