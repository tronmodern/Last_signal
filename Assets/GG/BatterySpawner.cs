using UnityEngine;

public class BatterySpawner : MonoBehaviour
{
    public GameObject batteryPrefab;
    public int maxBatteries = 10;
    public LayerMask noSpawnMask; // Маска для объектов, на которых не должны спавниться батарейки

    private int currentBatteries = 0;

    void Start()
    {
        SpawnBatteries();
    }

    void SpawnBatteries()
    {
        Terrain terrain = Terrain.activeTerrain;
        if (terrain == null)
        {
            Debug.LogError("Terrain not found!");
            return;
        }

        TerrainData terrainData = terrain.terrainData;
        Vector3 terrainPosition = terrain.transform.position;

        Vector3 spawnAreaMin = terrainPosition;
        Vector3 spawnAreaMax = terrainPosition + terrainData.size;

        // Повторяем попытку спавна, пока не достигнем максимального количества
        while (currentBatteries < maxBatteries)
        {
            // Генерируем случайные координаты X и Z внутри области спавна
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);

            // Определяем высоту террейна в этой точке
            float terrainHeight = terrain.SampleHeight(new Vector3(randomX, 0f, randomZ));

            // Создаем точку спавна с учетом высоты террейна
            Vector3 spawnPosition = new Vector3(randomX, terrainHeight, randomZ);

            // Проверяем, не находится ли точка в зоне noSpawn
            if (!IsInNoSpawnZone(spawnPosition))
            {
                // Спавним батарейку на этой позиции
                Instantiate(batteryPrefab, spawnPosition, Quaternion.identity);
                currentBatteries++;
            }
        }
    }

    bool IsInNoSpawnZone(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 1f, noSpawnMask);
        return colliders.Length > 0;
    }

    // Отрисовка области спавна (только для отладки)
    private void OnDrawGizmosSelected()
    {
        Terrain terrain = Terrain.activeTerrain;
        if (terrain == null)
            return;

        TerrainData terrainData = terrain.terrainData;
        Vector3 terrainPosition = terrain.transform.position;

        Vector3 spawnAreaMin = terrainPosition;
        Vector3 spawnAreaMax = terrainPosition + terrainData.size;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube((spawnAreaMin + spawnAreaMax) * 0.5f, spawnAreaMax - spawnAreaMin);
    }
}