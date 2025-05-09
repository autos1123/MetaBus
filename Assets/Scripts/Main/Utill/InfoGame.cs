using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGame : MonoBehaviour
{
    public GameObject interactionUI; // 상호작용 가능한 경우 표시할 UI (예: F키 아이콘)

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
}
