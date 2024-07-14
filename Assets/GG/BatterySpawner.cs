using UnityEngine;

public class BatterySpawner : MonoBehaviour
{
    public GameObject batteryPrefab;
    public int maxBatteries = 10;
    public LayerMask noSpawnMask; // ����� ��� ��������, �� ������� �� ������ ���������� ���������

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

        // ��������� ������� ������, ���� �� ��������� ������������� ����������
        while (currentBatteries < maxBatteries)
        {
            // ���������� ��������� ���������� X � Z ������ ������� ������
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);

            // ���������� ������ �������� � ���� �����
            float terrainHeight = terrain.SampleHeight(new Vector3(randomX, 0f, randomZ));

            // ������� ����� ������ � ������ ������ ��������
            Vector3 spawnPosition = new Vector3(randomX, terrainHeight, randomZ);

            // ���������, �� ��������� �� ����� � ���� noSpawn
            if (!IsInNoSpawnZone(spawnPosition))
            {
                // ������� ��������� �� ���� �������
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

    // ��������� ������� ������ (������ ��� �������)
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