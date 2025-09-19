using UnityEngine;

public class cowMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 3f;

    public bool movingRight = true;

    private float angleTour = 180;

    private Animator animalAnim;

    private PlayerController playerControllerScript;

    private GameOverTrigger trigger;

    private bool hungry = true;

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animalAnim = GetComponent<Animator>();

        trigger = GameObject.Find("Player").GetComponent<GameOverTrigger>();
    }

    void Manger()
    {
        hungry = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hungry && !trigger.gameOver)
        {
            if (movingRight)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }

            float limiteDroite = 9f;
            float limiteGauche = -9f;

            if (transform.position.x >= limiteDroite && movingRight)
            {
                movingRight = false;
                transform.rotation = Quaternion.Euler(0, -90f, 0);  // tourne vers la gauche
            }
            else if (transform.position.x <= limiteGauche && !movingRight)
            {
                movingRight = true;
                transform.rotation = Quaternion.Euler(0, 90f, 0);   // tourne vers la droite
            }

        }
        else if (!hungry && !trigger.gameOver){

            if (transform.rotation.y == 90f)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            }
            else
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
            }

            animalAnim.SetBool("Eat_b", true);
            animalAnim.SetFloat("Speed_f", 0.01f);

            //Il doit courri pour s'en aller !
        }

    }
}
