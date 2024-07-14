using UnityEngine;
using UnityEngine.UI;

public class BatteryPickup : MonoBehaviour
{
    private bool isPlayerInRange = false; // Флаг для отслеживания, находится ли игрок в зоне батарейки
    private PlayerEnergy playerEnergy; // Ссылка на компонент энергии игрока
    private Text pickupHintText; // Ссылка на текст UI для отображения подсказки

    void Start()
    {
        playerEnergy = FindObjectOfType<PlayerEnergy>(); // Поиск компонента энергии игрока
        pickupHintText = GameObject.Find("PickupText").GetComponent<Text>(); // Поиск текста подсказки на канвасе игрока
        pickupHintText.enabled = false; // Скрытие подсказки при старте
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            PickUpBattery();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            pickupHintText.enabled = true; // Показываем подсказку
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            pickupHintText.enabled = false; // Скрываем подсказку
        }
    }

    void PickUpBattery()
    {
        playerEnergy.AddEnergy(50); // Добавляем энергию игроку
        Destroy(gameObject); // Удаляем батарейку из сцены
        pickupHintText.enabled = false; // Скрываем подсказку
    }
}