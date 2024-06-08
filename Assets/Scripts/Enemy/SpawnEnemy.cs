using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Runtime.CompilerServices;
using Game.Data;
using Game;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private WaitForSeconds wait;
    [SerializeField] public List<Unit> unitEnemies;
    public WaveInfo[] waveInfo;
    private bool isLock = false;
    public int AllEnemies;
    public int countDeathEnemies;
    private int indexWave;
    public int maxWaves;
    public int curentWave = 1;
    public int segments = 50; // Количество сегментов для круга
    public float radius = 30f; // Радиус круга
    public float lineWidth = 0.1f; // Толщина линии круга

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        SetupCircle();
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
        for (int i = 0; i < waveInfo.Length; i++)
        {
            indexWave = i;
            isLock = waveInfo[i].WaitDestroyEnemy;
            yield return new WaitWhile(() => isLock);
            wait = new WaitForSeconds(waveInfo[i].DelaySpawn);
            yield return wait;
            if (waveInfo[i].WaitDestroyEnemy)
            {
                curentWave++;
            }
            for (int j = 0; j < waveInfo[i].MaxEnemies; j++)
            {
                Vector3 spawnPoint = GetRandomPointOnCircle();
                Unit instance = Instantiate(waveInfo[i].Character.Prefab, spawnPoint + transform.position, Quaternion.identity);
                instance.Init(waveInfo[i].Character);
                unitEnemies.Add(instance);
            }
        }
    }
    private void Update()
    {
        for (int i = unitEnemies.Count - 1; i >= 0; i--)
        {
            if (unitEnemies[i].Stats.ReadData.HP <= 0)
            {
                countDeathEnemies++;
                unitEnemies.Remove(unitEnemies[i]);
            }
        }
        isLock = !(unitEnemies.Count == 0); ;
    }

    private void SetupCircle()
    {
        lineRenderer.loop = true;
        lineRenderer.widthMultiplier = lineWidth;
        lineRenderer.useWorldSpace = false;
        lineRenderer.positionCount = segments + 1;

        float angleStep = 360f / segments;
        var positions = new Vector3[segments + 1];
        float angle = 0f;

        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            positions[i] = new Vector3(x, 0f, y);
            angle += angleStep;
        }

        lineRenderer.SetPositions(positions);
    }

    private Vector3 GetRandomPointOnCircle()
    {
        int segmentIndex = Random.Range(0, segments);
        float angle = segmentIndex * (360f / segments);
        float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
        float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
        return new Vector3(x, 5f, y);
    }
}
[Serializable]
public struct WaveInfo
{
    [Header("Enemy model unit")]
    public Character Character;
    public float DelaySpawn;
    public bool WaitDestroyEnemy;
    public int MaxEnemies;
}

