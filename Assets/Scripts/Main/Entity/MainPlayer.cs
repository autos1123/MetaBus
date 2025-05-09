using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private bool IsMove = true;
    private SpriteRenderer spriteRenderer;
    public GameObject spriteObject;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // 이동 처리
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (animator != null)
        {
            bool isMoving = movement.sqrMagnitude > 0.01f;
            animator.SetBool("IsMove", isMoving); // 이동 중이면 애니메이션 반영
        }

        // 마우스 방향에 따라 스프라이트 반전
        UpdateLookDirectionByMouse();

        // F키를 누르면 상호작용
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void FixedUpdate()
    {
        if (IsMove)
        {
            // 이동 처리 (프레임 독립적)
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }

    // 상호작용 가능한 NPC 검사 및 상호작용
    private void Interact()
    {
        // 주변에 NPC가 있는지 확인 (반경 1.5f 내에 NPC 탐지)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.5f);
        foreach (Collider2D collider in colliders)
        {
            NPC npc = collider.GetComponent<NPC>();
            if (npc != null)
            {
                npc.Interact();  // NPC와 상호작용
                break;  // 첫 번째 NPC와 상호작용 후 종료
            }
        }
    }

    // 이동 제어
    public void SetMovementEnabled(bool enabled)
    {
        IsMove = enabled;
        if (!enabled)
        {
            rb.velocity = Vector2.zero;  // 이동 멈출 때 속도 초기화
        }
    }

    // 마우스 방향에 따라 플레이어 스프라이트 반전
    private void UpdateLookDirectionByMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dir = mouseWorldPos.x - transform.position.x;

        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = dir < 0f; // 마우스가 왼쪽에 있으면 플레이어도 왼쪽을 보게 함
        }
    }
}
