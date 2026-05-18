using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float sens=3f;

    public Transform playertransform;

    public float verticalrotationmin = -50f;

    public float verticalrotationmax = 80f;

    private Transform cameratransform;

    private Transform boomtransform;

    private float camerayaw, camerapitch;

    new private Camera camera;

    public float zoomideal = 10f;

    public LayerMask avoidlayer;

    public float zoomcurrent = 10f;



    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GetComponentInChildren<Camera>();

        cameratransform = camera.transform;

        boomtransform = transform.GetChild(0);

        // for pivot
        camerayaw = transform.localEulerAngles.y;
        // for camera boom
        camerapitch = boomtransform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        camerayaw += Input.GetAxis("Mouse X") * sens;
        camerapitch += Input.GetAxis("Mouse Y") * sens;

        camerapitch = Mathf.Clamp(camerapitch, verticalrotationmin, verticalrotationmax);

        transform.localEulerAngles = new Vector3(0, camerayaw, 0);

        boomtransform.localEulerAngles = new Vector3(camerapitch, 0, 0);

        //transform.position = playertransform.position;

        Vector3 directiontocamera = cameratransform.position - transform.position;

        directiontocamera.Normalize();


        // out function gets more info from the raycast
        if (Physics.Raycast( transform.position,directiontocamera, out RaycastHit hit, zoomideal, avoidlayer ) )
        {
            zoomcurrent = hit.distance;

        }
        else
        {
            zoomcurrent = zoomideal;
        }

        cameratransform.localPosition = new Vector3(0, 0, -zoomcurrent);
    }
}
