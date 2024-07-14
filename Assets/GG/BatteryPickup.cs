using UnityEngine;
using UnityEngine.UI;

public class BatteryPickup : MonoBehaviour
{
    private bool isPlayerInRange = false; // ���� ��� ������������, ��������� �� ����� � ���� ���������
    private PlayerEnergy playerEnergy; // ������ �� ��������� ������� ������
    private Text pickupHintText; // ������ �� ����� UI ��� ����������� ���������

    void Start()
    {
        playerEnergy = FindObjectOfType<PlayerEnergy>(); // ����� ���������� ������� ������
        pickupHintText = GameObject.Find("PickupText").GetComponent<Text>(); // ����� ������ ��������� �� ������� ������
        pickupHintText.enabled = false; // ������� ��������� ��� ������
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
            pickupHintText.enabled = true; // ���������� ���������
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            pickupHintText.enabled = false; // �������� ���������
        }
    }

    void PickUpBattery()
    {
        playerEnergy.AddEnergy(50); // ��������� ������� ������
        Destroy(gameObject); // ������� ��������� �� �����
        pickupHintText.enabled = false; // �������� ���������
    }
}