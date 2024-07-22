using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Main Settings")]
    [SerializeField, Range(0.1f, 0.2f)] private float speed;

    private Rigidbody rigidBody;
    private bool canMove = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) canMove = true;
        else if (Input.GetKey(KeyCode.S)) canMove = false;

        if (canMove)
        {
            Move();
        }
    }

    private void Move()
    {
        rigidBody.AddForce(-transform.forward * speed, ForceMode.Impulse);
        Debug.Log("движение прямо");
    }
}
