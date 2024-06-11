using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    [SerializeField] private float moveSpeed = 5.0f;
    private GameObject player;
    private Rigidbody enemyRigidbody;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        if (enemyRigidbody == null)
        {
            Debug.LogError("Rigidbody component not found on Enemy object.");
        }

        player = GameObject.FindGameObjectWithTag(PLAYER_TAG);
        if (player == null)
        {
            Debug.LogError("Player object not found in the scene.");
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(lookDirection * moveSpeed);
    }
}
