using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10f;
    
    private float turnSpeed = 5f;

    public float horizontalInput;

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
        horizontalInput = Input.GetAxis("Horizontal");

        var direction = new Vector3(1, 0, 0);
        direction = Vector3.right;

        transform.Translate(Vector3.left * speed * verticalInput * Time.deltaTime);

        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);
    }
}
