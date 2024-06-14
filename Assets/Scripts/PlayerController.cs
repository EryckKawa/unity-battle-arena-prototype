using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject powerUpIndicator;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float powerUpForce = 10.0f;
    [SerializeField] private int powerUpDuration = 7;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform rocketLaunchPoint;

    private Rigidbody playerRigidbody;
    private PowerUpType currentPowerUp = PowerUpType.None;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        UpdatePowerUpIndicatorPosition();

        if (currentPowerUp == PowerUpType.Rocket && Input.GetKeyDown(KeyCode.Space))
        {
            LaunchRocket();
        }
    }

    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(moveSpeed * verticalInput * focalPoint.transform.forward);
    }

    void UpdatePowerUpIndicatorPosition()
    {
        if (powerUpIndicator != null)
        {
            powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }
    }

    public void ActivatePowerUp(PowerUpType powerUpType)
    {
        currentPowerUp = powerUpType;
        powerUpIndicator.SetActive(true);
        StartCoroutine(PowerUpTimer());
    }

    IEnumerator PowerUpTimer()
    {
        yield return new WaitForSeconds(powerUpDuration);
        currentPowerUp = PowerUpType.None;
        powerUpIndicator.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && currentPowerUp == PowerUpType.Force)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            if (enemyRigidbody != null)
            {
                Vector3 awayFromPlayer = (other.transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(powerUpForce * awayFromPlayer, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            PowerUp powerUp = other.GetComponent<PowerUp>();
            if (powerUp != null)
            {
                ActivatePowerUp(powerUp.GetPowerUpType());
                Destroy(other.gameObject);
            }
        }
    }

    private void LaunchRocket()
    {
        if (rocketPrefab != null && rocketLaunchPoint != null)
        {
			Instantiate(rocketPrefab, new Vector3(0, 1, 0) + transform.position, rocketLaunchPoint.rotation);
        }
    }
}
