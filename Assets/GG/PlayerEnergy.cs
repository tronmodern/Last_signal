using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerEnergy : MonoBehaviour
{
    public float startingEnergy = 100f; // ��������� �������� �������
    public float maxEnergy = 100f; // ������������ �������� �������
    public float walkEnergyDecrease = 0.02f; // ����������� ������� ��� ������ (��/���)
    public float runEnergyDecrease = 0.05f; // ����������� ������� ��� ���� (��/���)
    public float idleEnergyDecrease = 0.01f; // ����������� ������� � ��������� ����������� (��/���)
    public float backwardWalkEnergyDecrease = 0.02f; // ����������� ������� ��� ������ ����� (��/���)
    public float energyDecreaseInterval = 1f; // �������� ���������� ������� (� ��������)
    public string MainMenu = "MainMenu"; // �������� ����� ������

    private float currentEnergy; // ������� �������� �������
    private float decreaseTimer; // ������ ��� ���������� �������
    private Text energyText; // ������ �� ����� HUD ��� ����������� �������

    void Start()
    {
        currentEnergy = startingEnergy;
        decreaseTimer = energyDecreaseInterval;
        energyText = GetComponentInChildren<Text>(); // ������� ����� HUD
        UpdateEnergyHUD(); // ��������� HUD ��� ������
    }

    void Update()
    {
        // ��������� ������� �� ��������� �������
        decreaseTimer -= Time.deltaTime;
        if (decreaseTimer <= 0f)
        {
            DecreaseEnergy();
            decreaseTimer = energyDecreaseInterval;
        }

        // ���������, ���� ������� �������� ����, ������������� �� ����� ������
        if (currentEnergy <= 0f)
        {
            SceneManager.LoadScene(MainMenu);
        }
    }

    // ������� ���������� �������
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
            currentEnergy -= idleEnergyDecrease; // ��������� ������� ��� �����������
        }

        currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy); // ������������ �������
        UpdateEnergyHUD(); // ��������� HUD
    }

    // ���������� ������ HUD � ������� ��������� �������
    void UpdateEnergyHUD()
    {
        if (energyText != null)
        {
            energyText.text = "�������: " + Mathf.RoundToInt(currentEnergy);
        }
    }

    // ������� ��� ���������� �������
    public void AddEnergy(float amount)
    {
        currentEnergy += amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy); // ������������ �������
        UpdateEnergyHUD(); // ��������� HUD
    }
}