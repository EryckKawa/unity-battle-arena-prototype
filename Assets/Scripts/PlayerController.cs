using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private GameObject focalPoint;
	[SerializeField] private float movSpeed;
	private Rigidbody playerRigidbody;

	// Start is called before the first frame update
	void Start()
	{
		playerRigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		float verticalInput = Input.GetAxis("Vertical");
		
		playerRigidbody.AddForce(movSpeed * verticalInput * focalPoint.transform.forward);
	}
}
