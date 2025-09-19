using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    
    public float turnSpeed = 10f;

    private float horizontalInput;

    private float verticalInput;

    private float leftBound  = 4;

    private float rightBound = 16;


    private GameOverTrigger trigger;

    private Animator playerAnim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trigger = GetComponent<GameOverTrigger>();

        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        float limiteDroite = 9f;
        float limiteGauche = -9f;

        if (!trigger.gameOver)
        {
            if (horizontalInput > 0 && transform.position.x > limiteGauche && !trigger.gameOver)
            {
                transform.rotation = Quaternion.Euler(0, 195, 0);
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }
            else if (horizontalInput < 0 && transform.position.x < limiteDroite && !trigger.gameOver)
            {
                transform.rotation = Quaternion.Euler(0, 165, 0);
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

        }else if (trigger.gameOver){
            //animation de mort quand game over
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);
            //Idle quand game over
            playerAnim.SetFloat("Speed_f", 0.20f);
        }
       

        
    }
  
}
