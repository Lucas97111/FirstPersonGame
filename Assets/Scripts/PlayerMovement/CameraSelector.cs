using UnityEngine;

public class CameraSelector : MonoBehaviour
{
    
    public enum Selection
    {
        Firstperson,
        Thirdperson
    }

    [Tooltip("What camera mode the game should start in")]
    public Selection currentSelection;


    private FirstPersonCamera firstPersonCamera;
    private ThirdPersonCamera thirdPersonCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CursorManager.SetCursor(false);


        // old cursor code that hardcoded a locked state
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;


        firstPersonCamera = FindFirstObjectByType<FirstPersonCamera>();
        thirdPersonCamera = FindFirstObjectByType<ThirdPersonCamera>();


        SelectCamera(currentSelection);
    }


    //thirdPersonCamera = FindFirstObjectByType<ThirdPersonCamera>();

    

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SelectCamera(Selection newselection)
    {
        currentSelection = newselection;


        switch (currentSelection)
        {
            case Selection.Firstperson:
                print("swtiched to first person");
                firstPersonCamera.gameObject.SetActive(true);
                thirdPersonCamera.gameObject.SetActive(false);
                break;

            case Selection.Thirdperson:
                print("swtiched to third person");
                firstPersonCamera.gameObject.SetActive(false);
                thirdPersonCamera.gameObject.SetActive(true);
                break;
        }
    }


    public Transform GetCameraTransform()
    {
        switch (currentSelection)
        {
            case Selection.Firstperson:
                return firstPersonCamera.transform;

            case Selection.Thirdperson:
                return thirdPersonCamera.transform;

            default:
                return null;
        }
    }
}
