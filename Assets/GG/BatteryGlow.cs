using UnityEngine;

public class BatteryGlow : MonoBehaviour
{
    public Color glowColor = Color.green; // Цвет свечения
    public float glowIntensity = 1f; // Интенсивность свечения
    public float glowRange = 5f; // Радиус свечения

    void Start()
    {
        // Настраиваем материал для эмиссии
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.EnableKeyword("_EMISSION");
            renderer.material.SetColor("_EmissionColor", glowColor * glowIntensity);
        }

        // Добавляем компонент Light для дополнительного свечения
        Light glowLight = gameObject.AddComponent<Light>();
        glowLight.type = LightType.Point;
        glowLight.color = glowColor;
        glowLight.intensity = glowIntensity;
        glowLight.range = glowRange;
    }
}