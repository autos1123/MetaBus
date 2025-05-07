using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [Range(1, 100)][SerializeField] private int health = 100;
    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, 100);
    }

    [Range(1, 100)][SerializeField] private float speed = 3f;
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }
    public void TakeDamage(int amount)
    {
        Health -= amount;
        Debug.Log($"ü�� ����: {amount}, ���� ü��: {Health}");
    }

    public void Heal(int amount)
    {
        Health += amount;
        Debug.Log($"ü�� ȸ��: {amount}, ���� ü��: {Health}");
    }
    private void Update()
    {
        // ����: F Ű�� ������ ������, H Ű�� ������ ȸ��
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(2);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(2);
        }
    }
}