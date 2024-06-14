using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Rotate(horizontalInput);
    }

    private void Rotate(float horizontalInput)
    {
        transform.Rotate(Vector3.down, horizontalInput * rotateSpeed * Time.deltaTime);
    }
}
