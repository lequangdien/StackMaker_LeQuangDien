using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public GameObject victoryUI;
    [SerializeField] public Button buttonNextLevel;
    public void Start()
    {
        buttonNextLevel.onClick.AddListener(NextLevel);
    }
    public void NextLevel()
    {
        victoryUI.SetActive(false);
        LevelManager.Instance.NextLevel();
    }
    public void VictoryUI()
    {
        victoryUI.SetActive(true);
    }
}
