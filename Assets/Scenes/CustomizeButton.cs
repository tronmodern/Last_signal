using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomizeButton : MonoBehaviour
{
    public Button myButton;
    public TMP_Text buttonText; // Используем TMP_Text вместо Text

    void Start()
    {
        // Настройка фона кнопки
        var buttonImage = myButton.GetComponent<Image>();
        buttonImage.color = new Color(1f, 1f, 1f, 1f); // Белый цвет

        // Настройка цветов для различных состояний
        var buttonColors = myButton.colors;
        buttonColors.normalColor = new Color(1f, 1f, 1f, 1f); // Белый цвет
        buttonColors.highlightedColor = new Color(0.87f, 0.87f, 0.87f, 1f); // Светло-серый цвет
        buttonColors.pressedColor = new Color(0.67f, 0.67f, 0.67f, 1f); // Серый цвет
        buttonColors.disabledColor = new Color(0.47f, 0.47f, 0.47f, 1f); // Темно-серый цвет
        myButton.colors = buttonColors;

        // Настройка текста кнопки
        buttonText.fontSize = 24;
        buttonText.color = Color.black;

        // Добавление тени к тексту
        var shadow = buttonText.gameObject.AddComponent<Shadow>();
        shadow.effectColor = new Color(0f, 0f, 0f, 0.5f); // Полупрозрачный черный цвет
        shadow.effectDistance = new Vector2(2f, -2f); // Смещение тени
    }
}