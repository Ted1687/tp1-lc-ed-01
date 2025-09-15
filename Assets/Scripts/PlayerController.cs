using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    
    public float turnSpeed = 5f;

    private float horizontalInput;

    private float leftBound  = 4;

    private float rightBound = 16;

    private Animator playerAnim;

    public float verticalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        //horizontalInput = Input.GetAxis("Horizontal");

       
        if (! (transform.position.x < leftBound &&  transform.position.x > rightBound) )
        {
            transform.Translate(Vector3.left * speed * verticalInput * Time.deltaTime);
            transform.Rotate(Vector3.left * Time.deltaTime * horizontalInput * turnSpeed);
        }
        
    }
}
