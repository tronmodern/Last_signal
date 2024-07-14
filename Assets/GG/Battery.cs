using UnityEngine;

public class Battery : MonoBehaviour
{
    public int energyAmount = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerEnergy playerEnergy = other.GetComponent<PlayerEnergy>();
            if (playerEnergy != null)
            {
                playerEnergy.AddEnergy(energyAmount);
                Destroy(gameObject);
            }
        }
    }
}