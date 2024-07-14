using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomizeButton : MonoBehaviour
{
    public Button myButton;
    public TMP_Text buttonText; // ���������� TMP_Text ������ Text

    void Start()
    {
        // ��������� ���� ������
        var buttonImage = myButton.GetComponent<Image>();
        buttonImage.color = new Color(1f, 1f, 1f, 1f); // ����� ����

        // ��������� ������ ��� ��������� ���������
        var buttonColors = myButton.colors;
        buttonColors.normalColor = new Color(1f, 1f, 1f, 1f); // ����� ����
        buttonColors.highlightedColor = new Color(0.87f, 0.87f, 0.87f, 1f); // ������-����� ����
        buttonColors.pressedColor = new Color(0.67f, 0.67f, 0.67f, 1f); // ����� ����
        buttonColors.disabledColor = new Color(0.47f, 0.47f, 0.47f, 1f); // �����-����� ����
        myButton.colors = buttonColors;

        // ��������� ������ ������
        buttonText.fontSize = 24;
        buttonText.color = Color.black;

        // ���������� ���� � ������
        var shadow = buttonText.gameObject.AddComponent<Shadow>();
        shadow.effectColor = new Color(0f, 0f, 0f, 0.5f); // �������������� ������ ����
        shadow.effectDistance = new Vector2(2f, -2f); // �������� ����
    }
}