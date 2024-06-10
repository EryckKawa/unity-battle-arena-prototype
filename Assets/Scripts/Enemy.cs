using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private const string PLAYER = "Player";

	[SerializeField] private float movSpeed = 5.0f;
	private GameObject player;
	private Rigidbody enemyRigidbody;

	void Start()
	{
		enemyRigidbody = GetComponent<Rigidbody>();
		
		player = GameObject.Find(PLAYER);
		
	}

	void FixedUpdate()
	{
		Vector3 lookDirection = (player.transform.position - transform.position).normalized;
		enemyRigidbody.AddForce(lookDirection * movSpeed);
	}
}
