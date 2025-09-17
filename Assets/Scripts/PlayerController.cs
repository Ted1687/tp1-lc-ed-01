using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    
    public float turnSpeed = 10f;

    private float horizontalInput;

    private float verticalInput;

    private float leftBound  = 4;

    private float rightBound = 16;

    public bool gameOver;

    private Animator playerAnim;


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

        if (horizontalInput > 0 && transform.position.z < 18)
        {
            transform.rotation = Quaternion.Euler(0, -75, 0);
            transform.Translate(Vector3.forward  * speed * Time.deltaTime, Space.World);
        }
        else if (horizontalInput < 0 && transform.position.z > 2)
        {
            transform.rotation = Quaternion.Euler(0, -115, 0);
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0,-90,0);
        }

        //transform.Translate(Vector3.left * speed * horizontalInput * Time.deltaTime);

            //if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    transform.rotation = Quaternion.Euler(0, -115, 0);
            //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //}


            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    transform.rotation = Quaternion.Euler(0, -75, 0);
            //    transform.Translate(Vector3.back * speed * Time.deltaTime);
            //}




            //if (! (transform.position.x < leftBound &&  transform.position.x > rightBound && !gameOver) )
            //{

            //}

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            gameOver = true;

            //animation de mort
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

        }
    }
}
