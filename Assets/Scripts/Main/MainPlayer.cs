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
        // �̵� ó��
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (animator != null)
        {
            bool isMoving = movement.sqrMagnitude > 0.01f;
            animator.SetBool("IsMove", isMoving); // �̰͸� ������ ��
        }

        // ���콺 ���⿡ ���� ��������Ʈ ����
        UpdateLookDirectionByMouse();


        // FŰ �Է����� NPC�� ��ȣ�ۿ�
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void FixedUpdate()
    {
        if (IsMove)
        {
            // �̵� ó�� (�̵� �ӵ��� Time.deltaTime�� ����� ������ ���������� ����)
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }

    // ��ȣ�ۿ� ������ NPC �˻� �� ��ȣ�ۿ�
    private void Interact()
    {
        // �ֺ��� NPC�� �ִ��� Ȯ��
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.5f);
        foreach (Collider2D collider in colliders)
        {
            NPC npc = collider.GetComponent<NPC>();
            if (npc != null)
            {
                npc.Interact();
                break;
            }
        }
    }

    // �̵� ����
    public void SetMovementEnabled(bool enabled)
    {
        IsMove = enabled;
        if (!enabled)
        {
            rb.velocity = Vector2.zero;  // �̵� ���� �� �ӵ� �ʱ�ȭ
        }
    }
    private void UpdateLookDirectionByMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dir = mouseWorldPos.x - transform.position.x;

        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = dir < 0f; // ���ʿ� ������ ���� (���� ����)
        }
    }
}
