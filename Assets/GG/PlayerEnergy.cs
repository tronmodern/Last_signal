using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerEnergy : MonoBehaviour
{
    public float startingEnergy = 100f; // Начальное значение энергии
    public float maxEnergy = 100f; // Максимальное значение энергии
    public float walkEnergyDecrease = 0.02f; // Потребление энергии при ходьбе (ед/сек)
    public float runEnergyDecrease = 0.05f; // Потребление энергии при беге (ед/сек)
    public float idleEnergyDecrease = 0.01f; // Потребление энергии в состоянии бездействия (ед/сек)
    public float backwardWalkEnergyDecrease = 0.02f; // Потребление энергии при ходьбе назад (ед/сек)
    public float energyDecreaseInterval = 1f; // Интервал уменьшения энергии (в секундах)
    public string MainMenu = "MainMenu"; // Название сцены смерти

    private float currentEnergy; // Текущее значение энергии
    private float decreaseTimer; // Таймер для уменьшения энергии
    private Text energyText; // Ссылка на текст HUD для отображения энергии

    void Start()
    {
        currentEnergy = startingEnergy;
        decreaseTimer = energyDecreaseInterval;
        energyText = GetComponentInChildren<Text>(); // Находим текст HUD
        UpdateEnergyHUD(); // Обновляем HUD при старте
    }

    void Update()
    {
        // Уменьшаем энергию по истечении времени
        decreaseTimer -= Time.deltaTime;
        if (decreaseTimer <= 0f)
        {
            DecreaseEnergy();
            decreaseTimer = energyDecreaseInterval;
        }

        // Проверяем, если энергия достигла нуля, переключаемся на сцену смерти
        if (currentEnergy <= 0f)
        {
            SceneManager.LoadScene(MainMenu);
        }
    }

    // Функция уменьшения энергии
    void DecreaseEnergy()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentEnergy -= runEnergyDecrease;
            }
            else
            {
                currentEnergy -= walkEnergyDecrease;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentEnergy -= backwardWalkEnergyDecrease;
        }
        else
        {
            currentEnergy -= idleEnergyDecrease; // Уменьшаем энергию при бездействии
        }

        currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy); // Ограничиваем энергию
        UpdateEnergyHUD(); // Обновляем HUD
    }

    // Обновление текста HUD с текущим значением энергии
    void UpdateEnergyHUD()
    {
        if (energyText != null)
        {
            energyText.text = "Энергия: " + Mathf.RoundToInt(currentEnergy);
        }
    }

    // Функция для добавления энергии
    public void AddEnergy(float amount)
    {
        currentEnergy += amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy); // Ограничиваем энергию
        UpdateEnergyHUD(); // Обновляем HUD
    }
}