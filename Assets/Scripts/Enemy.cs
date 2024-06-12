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
        player = GameObject.FindGameObjectWithTag(PLAYER_TAG);
    }

    void FixedUpdate()
    {
        MoveTowardsPlayer();

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
