using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    #region Variables
    public Rigidbody Rigid;
    public Transform CameraHolder;   // Assign your Camera here
    public float MouseSensitivity = 2f;
    public float MoveSpeed = 5f;
    public Transform GroundCheck;
    public float GroundDistance = 0.2f;
    public LayerMask GroundMask;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier
    bool readyToJump;
    #endregion

    [Header("Keybinds")]
    public KeyCodes jumpKey = KeyCode.Space;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Look();
        Move();
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        // Rotate player body (left/right)
        Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(0f, mouseX, 0f));

        // Rotate camera (up/down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        CameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void Move()
    {
        Vector3 move =
            transform.forward * Input.GetAxis("Vertical") +
            transform.right * Input.GetAxis("Horizontal");

        Rigid.MovePosition(Rigid.position + move * MoveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        Rigid.velocity = new Vector3(Rigid.velocity.x, 0f, Rigid.velocity.z);

        Rigid.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void RestJump()
    {
        readyToJump = true;
    }
}