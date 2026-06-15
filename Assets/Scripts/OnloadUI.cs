using UnityEngine;

public class OnloadUI : MonoBehaviour
{
    public GameObject startui;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startui.SetActive(true);
        Invoke("DisableUi", 2f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableUi()
    {
        startui.SetActive(false);
    }
}
