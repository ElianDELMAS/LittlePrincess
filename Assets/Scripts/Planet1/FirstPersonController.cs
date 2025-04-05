using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;
    public Transform cameraTransform;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private CharacterController controller;
    private bool freezePlayer = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!freezePlayer)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);
            rotationY += mouseX;

            if (rotationX > 60) rotationX = 60;
            if (rotationX < -60) rotationX = -60;

            cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 move = transform.right * moveX + transform.forward * moveZ;

            controller.Move(move * speed * Time.deltaTime);
        }
    }

    public void activateFreezePlayer(bool freeze)
    {
        freezePlayer = freeze;
    }
}
