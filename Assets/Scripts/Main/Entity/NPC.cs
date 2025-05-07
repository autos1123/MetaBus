using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName = "Game Master";
    public GameObject interactionUI; // ��ȣ�ۿ� ������ ��� ǥ���� UI (��: FŰ ������)

    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactionUI != null)
                interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }

    // ��ȣ�ۿ� �� ���� ��� UI ǥ��
    public void Interact()
    {
        if (playerInRange)
        {
            MainUIManager.Instance.ShowGameSelectionUI();
        }
    }
}