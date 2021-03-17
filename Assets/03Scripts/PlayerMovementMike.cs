using UnityEngine;

public class PlayerMovementMike : MonoBehaviour
{
    public CharacterController controller;
    float turnSmoothvelocity;

    Transform cam;
    Animator animator;

    private void Start()
    {
        cam = Camera.main.transform;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Movement();

        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
        //    Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        //{
        //    animator.SetBool("isWalking", true);
        //}
        //else
        //{ 
        //    animator.SetBool("isWalking", false);
        //}
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        var config = GameManager.config;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothvelocity, config.PlayerTurnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(movDir.normalized * config.PlayerSpeed * Time.deltaTime);
        }
    }   
}
