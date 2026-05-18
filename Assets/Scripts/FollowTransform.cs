using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public Transform follow;

    public Vector3 offset = new Vector3 (2, 2, 2);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (follow == null)
        {
            return;
        }

        transform.position = follow.position + offset;
    }
}
