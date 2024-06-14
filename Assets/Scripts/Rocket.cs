using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float rocketSpeed = 20.0f;
    [SerializeField] private float turnSpeed = 5.0f;

    private Rigidbody rocketRigidbody;
    private Transform target;

    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
        FindClosestEnemy();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            MoveTowardsEnemy();
        }
    }

    private void MoveTowardsEnemy()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rocketRigidbody.velocity = direction * rocketSpeed;
        Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);
        rocketRigidbody.angularVelocity = rotationAmount * turnSpeed;
    }

    private void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            target = null;
            return;
        }

        target = enemies[0].transform; // Assume the first enemy is the closest
        float closestDistance = Vector3.Distance(transform.position, target.position);

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                target = enemy.transform;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
