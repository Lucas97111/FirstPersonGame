using UnityEngine;
using UnityEngine.Audio;

public class CharacterJump : MonoBehaviour
{
    [Tooltip("The jump strength")]
    public float jumpPower = 10f;
    [Tooltip("Gravity acceleration")]
    public float gravity = 9.8f;

    public int JumpsPerformed;

    public int JumpsAllowed;


    public float yVelocity;

    //public AudioSource sfxJump;

    private CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        // we move first before the jump to force an update on the isgrounded state
       controller.Move(Vector3.up * yVelocity * Time.deltaTime);

        if (controller.isGrounded)
        {

            ResetJumps();

            yVelocity = -1f;
        }
        else
        {
            JumpsPerformed = Mathf.Max(1, JumpsPerformed);
        }

            yVelocity -= gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
           
            TryToJump();

        }
    }

    /// <summary>
    /// Tries to jump, checking if we are on the groud or if we have any jumps available
    /// </summary>
    public void TryToJump()
    {
        if (controller.isGrounded || JumpsPerformed < JumpsAllowed)
        {
            yVelocity = jumpPower;

            JumpsPerformed += 1;

            //sfxJump.Play();
        }
    }

    public void ResetJumps()
    {
        JumpsPerformed = 0;
    }
}
