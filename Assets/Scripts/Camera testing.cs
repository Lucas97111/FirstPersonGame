using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cameratesting : MonoBehaviour
{    
    public Camera cam;

    [Tooltip("The maximum distnace a raycast will travel from the camera")]
    public float maxCameraRaycast = 20f;    // The max distance a raycast will travel from the camera
    [Tooltip("Layers that the camera will ignore, e.g. the player, small bushes ect")]
    public LayerMask layerToIgnore;  // layers to ignore e.g. the player
    [Tooltip("How often the player can take a picture")]
    public float cameracooldown = 5f;

    private float nextClickTime = 0f;
    private Texture2D texture2D;
    public RenderTexture myRenderTexture;

    public Image guiImage;

    public GameObject cameraoutputcanvas;

    public AudioSource camerascucess;

    public AudioSource camerafail;
    

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // when you left click a raycast is performed in the centre of your screen 
        if (Input.GetMouseButton(0))  // 0 is left click
        {
            if (Time.time >= nextClickTime)
            {
                takepicture();

                nextClickTime = Time.time + cameracooldown;
            }
            else
            {
                camerafail.Play();
            }

        }
    }

    public void takepicture()
    {
        // if the raycast hits something it prints its name and saves the texture 
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, maxCameraRaycast, ~layerToIgnore)) // should spilt this up 
        {
            print(hit.transform.gameObject.name);

            if (hit.collider.CompareTag("Collision"))
            {

                print("Hit a special thing and saved and image");
                cameraoutputcanvas.GetComponentInChildren<TextMeshProUGUI>().text = "You captured the angle";

            }

        }
        camerascucess.Play();

        saveImage();
        cameraoutputcanvas.SetActive(true);
        Invoke("DisableUI", 2f);


    }






    // saves the render texture to image idk how half of it works but it does
    public void saveImage()
    {
        RenderTexture previousActive = RenderTexture.active;

        RenderTexture.active = myRenderTexture;

        texture2D = new Texture2D(myRenderTexture.width, myRenderTexture.height, TextureFormat.ARGB32, false);
        texture2D.ReadPixels(new Rect(0, 0, myRenderTexture.width, myRenderTexture.height), 0, 0);
        texture2D.Apply();

        RenderTexture.active = previousActive;

        Sprite newsprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));

        guiImage.sprite = newsprite;

    }

    // disables the ui in 2 seconds via an invoke call
    public void DisableUI()
    {
        cameraoutputcanvas.SetActive(false);

    }


}
