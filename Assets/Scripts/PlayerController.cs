using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     // A reference to the Rigidbody component 
    private Rigidbody rb;
    
    [Tooltip("How fast the ball moves left/right")]
    [Range(0, 10)]
    public float dodgeSpeed = 5;
    
    [Tooltip("How fast the ball moves forwards automatically")]
    [Range(0, 10)]
    public float rollSpeed = 5;

    private float horizontalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Get access to our Rigidbody component 
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
         //horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;
    }


    /// <summary>
    /// FixedUpdate is called at a fixed framerate and is a prime place to put
    /// Anything based on time.
    /// </summary>
    private void FixedUpdate()
    {

        #if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;

        if(Input.GetMouseButton(0))
        {
            horizontalSpeed = CalculateMovement(Input.mousePosition);
        }
        #elif UNITY_IOS || UNITY_ANDROID
        
        if (Input.touchCount > 0)
        {
                Touch touch = Input.touches[0];
                horizontalSpeed = CalculateMovement(touch.position);
        }
        #endif

        rb.velocity = new Vector3(horizontalSpeed, 0, rollSpeed);


    }

    /// <summary>
    /// Move player horizontally
    /// </summary>
    /// <param name="pixelPos">The position the has touched/click on</param>
    /// <returns>The direction to move in the x axis</returns>

    private float CalculateMovement(Vector3 pixelPos)
    {
        var worldPos = Camera.main.ScreenToViewportPoint(pixelPos);
        float xMove = 0;

        if (worldPos.x < 0.5f)
        {
            xMove = -1;
        }
        else
        {
            xMove = 1;
        }

        return xMove * dodgeSpeed;
    }

}