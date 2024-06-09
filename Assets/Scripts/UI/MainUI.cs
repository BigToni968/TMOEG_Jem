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
    [SerializeField] private SpawnEnemy infoSpawnEnemy;
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
        titleWave.SetText($"{SceneManager.GetActiveScene().buildIndex}");
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
}
