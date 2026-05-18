using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    [Tooltip("Camera sensitivity")]
    public float sens = 3f;

    public Transform playertransform;


    [Tooltip("Camera offset from centre of player, middle axis is height")]
    public Vector3 cameraoffset = new Vector3 (0, 3, 0);

    public float verticalrotationmin = -60f;

    public float verticalrotationmax = 70f;

    private float camerayaw, camerapitch;

    new private Camera camera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GetComponent<Camera>();

        camerayaw = transform.localEulerAngles.y;
        camerapitch = transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {



        // get input data
        camerayaw += Input.GetAxis("Mouse X") * sens;
        camerapitch += Input.GetAxis("Mouse Y") * sens;

        //clamp max camera angles
        camerapitch = Mathf.Clamp(camerapitch, verticalrotationmin, verticalrotationmax);

        //apply transform to camera
        transform.localEulerAngles = new Vector3(camerapitch, camerayaw);

        //transform.position = playertransform.position + cameraoffset;


    }
}
