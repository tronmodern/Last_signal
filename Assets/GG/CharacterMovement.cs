using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator animator;
    float speed = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    public float walkSpeed = 2f;
    public float runSpeed = 4f;
    public float turnSpeed = 360f;
    int SpeedHash;
    Vector3 moveDirection = Vector3.zero;

    Rigidbody rb;

    void Start()
    {
        moveDirection = transform.forward;
        animator = GetComponent<Animator>();
        SpeedHash = Animator.StringToHash("Speed");

        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        // —крываем и фиксируем курсор
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void FixedUpdate()
    {
        

        animator.SetFloat(SpeedHash, speed);

        // ѕеремещение персонажа
        
        rb.MovePosition(rb.position + moveDirection);

        // ѕоворот персонажа и камеры
        HandleRotation();
    }

    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if (forwardPressed && speed < 0.5f)
        {
            speed += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && speed > 0.0f)
        {
            speed -= Time.deltaTime * deceleration;
        }

        if (forwardPressed && runPressed)
        {
            speed += Time.deltaTime * acceleration;
        }

        if (forwardPressed && runPressed && speed > 1.0f)
        {
            speed = 1.0f;
        }

        if (forwardPressed && !runPressed && speed > 0.5f)
        {
            speed -= Time.deltaTime * acceleration;
        }

        if (backwardPressed)
        {
            speed -= Time.deltaTime * deceleration;
        }

        if (!backwardPressed && speed < 0.0f)
        {
            speed += Time.deltaTime * deceleration;
        }

        if (backwardPressed && speed < -0.5f)
        {
            speed = -0.5f;
        }

        moveDirection = transform.forward * speed * (backwardPressed ? 3 : (runPressed ? runSpeed : walkSpeed)) * Time.deltaTime;
    }


    void HandleRotation()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float movementThreshold = 0.1f; // ѕорог дл€ определени€ неподвижности

        if (Mathf.Abs(speed) < movementThreshold)
        {
            // ѕоворачиваем камеру вокруг персонажа, если персонаж не движетс€          
            transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);
        }
        else
        {
            // ѕоворачиваем персонажа в направлении движени€ камеры
            Vector3 direction = Camera.main.transform.forward;
            direction.y = 0;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}