using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider StaminaBar;
    [SerializeField] private TextMeshProUGUI titleWave;
    [SerializeField] private TextMeshProUGUI countEnemys;
    [SerializeField] private TextMeshProUGUI titeAncouments;
    [SerializeField] private TextMeshProUGUI titeButtonAncoumentsLeft;
    [SerializeField] private TextMeshProUGUI titeButtonAncoumentsRight;
    [SerializeField] private SpawnEnemy infoSpawnEnemy;
    [SerializeField] private Transform panelAncouments;
    [field: SerializeField] static public MainUI Instance { private set; get; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        healthBar.maxValue = player.PlayerSelf.MaxHealth;
    }
    private void Update()
    {
        UpdateHelthBar();
        UpdateInfoWave();
        UpdateStaminaBar();
    }
    public void UpdateHelthBar()
    {
        healthBar.value = player.PlayerSelf.Health;
    }
    public void UpdateInfoWave()
    {
        titleWave.SetText($"Âîëíà {SceneManager.GetActiveScene().buildIndex}");
        countEnemys.SetText($"{infoSpawnEnemy.countDeathEnemies}/{infoSpawnEnemy.AllEnemies}");
    }
    public void StopGame()
    {
        Time.timeScale = 0f;
    }
    public void UpdateStaminaBar()
    {
        StaminaBar.value = player.timer;
    }
    public void AncoumentsWin()
    {
        if (infoSpawnEnemy.countDeathEnemies == infoSpawnEnemy.AllEnemies)
        {
            panelAncouments.gameObject.SetActive(true);
            titeAncouments.SetText("");
        }
        
    }
    public void AncoumentsLose()
    {
        if (player.PlayerSelf.Health <= 0)
        {
            panelAncouments.gameObject.SetActive(true);
            titeAncouments.SetText("ÊÀÊ ÆÀËÜ ÂÀØÀ ÄÓØÀ ÎÒÏÐÀÂÈËÀÑÜ Â ÐÓÊÈ ÓÌÑÓÃÓÒÀÐ ÎËÎÕÀ");
            titeButtonAncoumentsLeft.SetText("ÒÓÄÀ ÅÉ È ÄÎÐÎÃÀ");
            titeButtonAncoumentsRight.SetText("ÒÐÅÁÓÞ ÐÅÂÀÍØ");
        }
    }
}
