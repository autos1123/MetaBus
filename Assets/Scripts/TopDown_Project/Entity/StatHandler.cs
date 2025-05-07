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
        Debug.Log($"체력 감소: {amount}, 현재 체력: {Health}");
    }

    public void Heal(int amount)
    {
        Health += amount;
        Debug.Log($"체력 회복: {amount}, 현재 체력: {Health}");
    }
    private void Update()
    {
        // 예시: F 키를 누르면 데미지, H 키를 누르면 회복
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