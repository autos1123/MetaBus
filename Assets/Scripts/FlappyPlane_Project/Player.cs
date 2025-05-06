using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;
    
    public float flapForce = 6f;
    public float fowardSpeed = 3f;
    public bool isDead = false;

    float deathCoolDown = 0f;
    bool isFlap = false;

    public bool isGod = false;
    FlapManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FlapManager.Instance;
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if(animator == null)
        {
            Debug.LogError("Animator not found in children of Player object.");
        }
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody2D not found in Player object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            if(deathCoolDown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCoolDown -= Time.deltaTime;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap= true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = fowardSpeed;

        if (isFlap)
        {
            velocity.y = flapForce;
            isFlap = false;
        }
        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f) , -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGod) return;

        if (isDead) return;

        isDead = true;
        deathCoolDown = 1f;
        animator.SetInteger("IsDie", 1);
        gameManager.GameOver();
    }

}
