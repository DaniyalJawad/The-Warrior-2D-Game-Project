using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteScreen : MonoBehaviour
{
    public GameObject LevelComplete;
    private void OnEnable()
    {
        BossHealth.onLevelComplete += enableGameOverMenu;
    }
    private void OnDisable()
    {
        BossHealth.onLevelComplete -= enableGameOverMenu;
    }
    public void enableGameOverMenu()
    {
        LevelComplete.SetActive(true);
    }
}
