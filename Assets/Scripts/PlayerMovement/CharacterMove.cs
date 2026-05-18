using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharacterMove : MonoBehaviour
{
    [Tooltip("The walking speed")]
    public float speedWalk = 4f;
    [Tooltip("The sprint speed")]
    public float speedSprint = 7f;

    private CharacterController controller;

    private Vector2 inputsThisFrame = new Vector2();

    private Vector3 movement = new Vector3();

    private float yaw = 0.0f;


    // temp????
    //public Transform cameratransform; 

    private CameraSelector cameraSelector;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();

        cameraSelector = GetComponent<CameraSelector>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0, yaw, 0);

        inputsThisFrame.x = Input.GetAxis("Horizontal");
        inputsThisFrame.y = Input.GetAxis("Vertical");
        
        // translate inputs into world space e.g. 3D
        //movement = new Vector3(0,0,0);
        movement = new Vector3(inputsThisFrame.x, 0, inputsThisFrame.y);

        //movement = transform.TransformDirection(movement); // old line for static movement

        movement = cameraSelector.GetCameraTransform().TransformDirection(movement);


        // sprint 
        if (Input.GetButton("Sprint"))
        {
            movement *= speedSprint;
        }
        else
        {
            movement *= speedWalk;
        }

        controller.Move(movement * Time.deltaTime);
    }

}
