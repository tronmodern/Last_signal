using UnityEngine;

public class BatteryGlow : MonoBehaviour
{
    public Color glowColor = Color.green; // ���� ��������
    public float glowIntensity = 1f; // ������������� ��������
    public float glowRange = 5f; // ������ ��������

    void Start()
    {
        // ����������� �������� ��� �������
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.EnableKeyword("_EMISSION");
            renderer.material.SetColor("_EmissionColor", glowColor * glowIntensity);
        }

        // ��������� ��������� Light ��� ��������������� ��������
        Light glowLight = gameObject.AddComponent<Light>();
        glowLight.type = LightType.Point;
        glowLight.color = glowColor;
        glowLight.intensity = glowIntensity;
        glowLight.range = glowRange;
    }
}