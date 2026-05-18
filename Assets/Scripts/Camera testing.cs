using UnityEngine;

public class Cameratesting : MonoBehaviour
{    
    Camera cam;

    [Tooltip("The maximum distnace a raycast will travel from the camera")]
    public float maxCameraRaycast = 20f;    // The max distance a raycast will travel from the camera
    public LayerMask layerToIgnore;  // layers to ignore e.g. the player
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))  // 0 is left click
        {
            print("Mouse clicked");
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit , maxCameraRaycast, ~layerToIgnore)) // should spilt this up 
            {
                print("hit an object");
                print(hit.transform.gameObject.name);
            }
        }
    }


}
