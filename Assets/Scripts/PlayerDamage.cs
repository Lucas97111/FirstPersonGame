using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{


    public GameObject gameoverpanel;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("player damage started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {

        print("touched something with a trigger");
        if (collision.gameObject.CompareTag("Collision"))
        {
            print("Touched the angle resetting scene");

            gameoverpanel.SetActive(true);

            Invoke("resetscene", 2f);
            
        }
          
    }


    public void resetscene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // reloads the current scence when you take damage
    }
}
