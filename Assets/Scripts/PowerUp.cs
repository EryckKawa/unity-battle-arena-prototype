using UnityEngine;

public enum PowerUpType
{
    None,
    Force,
    Rocket
}

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType powerUpType;

    public PowerUpType GetPowerUpType()
    {
        return powerUpType;
    }
}
