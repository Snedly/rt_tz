using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Main Settings")]
    [SerializeField, Range(0.05f, 0.1f)] private float speed = 0.05f;

    [Header("Component Link's")]
    [Space]
    [SerializeField] private TrafficLightController trafficController;

    private Rigidbody rigidBody;
    private Animator animator;
    private bool drive = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) drive = true;
        else if (Input.GetKeyDown(KeyCode.S)) drive = false;

        if (trafficController.canMove)
        {
            if(drive)
            {
                Move();
            }
            else
            {
                animator.SetBool("Moving", false);
            }
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    private void Move()
    {
        rigidBody.AddForce(-transform.forward * speed, ForceMode.Impulse);
        animator.SetBool("Moving", true);
    }
}
