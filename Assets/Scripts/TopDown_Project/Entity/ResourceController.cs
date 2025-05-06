using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = 0.5f;

    private BaseController baseController;
    private StatHandler statHandler;
    private AnimationHandler animationHandler;

    private float timeSinceLastChance = float.MaxValue;

    public float CurrentHealth { get; private set; }
    public float MaxHealth => statHandler.Health;

    private void Awake()
    {
        baseController = GetComponent<BaseController>();
        statHandler = GetComponent<StatHandler>();
        animationHandler = GetComponent<AnimationHandler>();
    }
    private void Start()
    {
        CurrentHealth = statHandler.Health;
    }
    private void Update()
    {
        if (timeSinceLastChance < healthChangeDelay)
        {
            timeSinceLastChance += Time.deltaTime;
            if (timeSinceLastChance > healthChangeDelay)
            {
                animationHandler.InvincibilityEnd();
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        if (change == 0 || timeSinceLastChance < healthChangeDelay)
        {
            return false;
        }
        timeSinceLastChance = 0;
        CurrentHealth += change;
        CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;

        if (change < 0)
        {
            animationHandler.Damage();
        }
        if (CurrentHealth <= 0f)
        {
            Death();
        }
        return true;
    }

    private void Death()
    {
        baseController.Death();
    }
}
