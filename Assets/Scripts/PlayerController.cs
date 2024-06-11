using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject powerUpIndicator;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float powerUpForce = 10.0f;
    [SerializeField] private int powerUpDuration = 7;

    private Rigidbody playerRigidbody;
    private bool hasPowerUp;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        UpdatePowerUpIndicatorPosition();
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpTimer());
        }
    }

    IEnumerator PowerUpTimer()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            if (enemyRigidbody != null)
            {
                Vector3 awayFromPlayer = (other.transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(powerUpForce * awayFromPlayer, ForceMode.Impulse);
            }
        }
    }
}
