using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;
    public Transform cameraTransform;
    public float interactionDistance = 2f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    private bool freezePlayer = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!freezePlayer) 
        {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move * speed * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        rotationY += mouseX * sensitivity;
        
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        }
    }

    public void activateFreezePlayer(bool freeze)
    {
        freezePlayer = freeze;
    }
}
