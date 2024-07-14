using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 2.0f;
    public float smoothSpeed = 10.0f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    private float rotationY = 0.0f;
    private float rotationX = 0.0f;

    void Start()
    {
        offset = new Vector3(0, height, -distance);

        LockCursor();
    }

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            rotationY += Input.GetAxis("Mouse X") * horizontalSpeed;
            rotationX -= Input.GetAxis("Mouse Y") * verticalSpeed;
            rotationX = Mathf.Clamp(rotationX, -60, 40);

            Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
            Vector3 desiredPosition = target.position + rotation * offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}