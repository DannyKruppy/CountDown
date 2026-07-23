using Unity.VisualScripting;
using UnityEngine;

public class DronePlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float lookSpeed;

    private CharacterController characterController;
    private GameObject camera;
    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Awake()
    {
        characterController = this.GetComponent<CharacterController>();
        camera = transform.Find("Player Camera").gameObject;
    }

    void Update()
    {
        float zMovement = Input.GetAxisRaw("Vertical"); //forward and back
        float xMovement = Input.GetAxisRaw("Horizontal"); //side to side
        float yMovement = 0; //up and down

        float xMouse = Input.GetAxisRaw("Mouse X") * lookSpeed;
        float yMouse = Input.GetAxisRaw("Mouse Y") * lookSpeed;

        //getting vertical movement
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftControl))
        {
            yMovement = 0;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            yMovement = 1;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            yMovement = -1;
        }
        Vector3 movement = new Vector3(xMovement, yMovement, zMovement).normalized;

        //math for rotation
        yRotation = xMouse;
        xRotation -= yMouse;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //applying movement and rotation
        characterController.Move(movement * moveSpeed * Time.deltaTime);
        
        transform.Rotate(0, yRotation, 0);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
