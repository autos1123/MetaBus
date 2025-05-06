// ���� ���� ���� �ڵ鷯 (WeaponHandler ���)
using UnityEngine;

public class MeleeWeaponHandler : WeaponHandler
{
    [Header("Melee Attack Info")]
    public Vector2 collideBoxSize = Vector2.one; // ���� ���� (�浹 �ڽ� ũ��)

    // ���� ũ�⿡ ���� �浹 ������ Ȯ��
    protected override void Start()
    {
        base.Start();
        collideBoxSize = collideBoxSize * WeaponSize;
    }

    public override void Attack()
    {
        base.Attack();

        // BoxCast�� ���� ���� ���� (LookDirection �������� �浹 �˻�)
        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position + (Vector3)Controller.LookDirection * collideBoxSize.x, // ��ġ
            collideBoxSize,              // �ڽ� ũ��
            0,                           // ȸ�� ����
            Vector2.zero,                // �̵� �Ÿ� ���� (������ ��ġ)
            0,                           // �Ÿ� 0 (�� ���� �˻�)
            target                       // ���� ������ ��� ���̾� ����ũ
        );

        if (hit.collider != null)
        {
            // ��󿡰� ü�� ���� ����
            ResourceController resourceController = hit.collider.GetComponent<ResourceController>();
            if (resourceController != null)
            {
                resourceController.ChangeHealth(-Power); // ������ ����

                // �˹� ȿ���� �����Ǿ� ���� ��� ����
                if (IsOnKnockback)
                {
                    BaseController controller = hit.collider.GetComponent<BaseController>();
                    if (controller != null)
                    {
                        controller.ApplyKnockback(transform, KnockbackPower, KnockbackTime);
                    }
                }
            }
        }
    }

    // ���� ���� ȸ�� (��/�쿡 ���� ������Ʈ y�� ����)
    public override void Rotate(bool isLeft)
    {
        if (isLeft)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
} 