using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    private void OnEnable()
    {
        PlayerHealth.onPlayerDeath += enableGameOverMenu;
    }
    private void OnDisable()
    {
        PlayerHealth.onPlayerDeath -= enableGameOverMenu;
    }
    public void enableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
