using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 3f;
    public float speedFuite = 8f;

    public bool movingLeft = true;

    private Animator animalAnim;

    private GameOverTrigger trigger;

    private bool hungry = true;

    private float animationEatDuration = 2f;

    public float duration = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animalAnim = GetComponent<Animator>();

        trigger = GameObject.Find("Player").GetComponent<GameOverTrigger>();
    }

    public void Manger()
    {
        hungry = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hungry && !trigger.gameOver)
        {
            if (movingLeft)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }

            float limiteGauche = 9f;
            float limiteDroite = -9f;

            if (transform.position.x >= limiteGauche && movingLeft)
            {
                movingLeft = false;
                transform.rotation = Quaternion.Euler(0, -90f, 0);  // tourne vers la gauche
            }
            else if (transform.position.x <= limiteDroite && !movingLeft)
            {
                movingLeft = true;
                transform.rotation = Quaternion.Euler(0, 90f, 0);   // tourne vers la droite
            }

        }
        else if (!hungry && !trigger.gameOver){

            duration += Time.deltaTime;

            if (duration < animationEatDuration)
            {
                animalAnim.SetBool("Eat_b", true);
                
            }
            else if(duration > animationEatDuration) 
            {
                animalAnim.SetBool("Eat_b", false);
                animalAnim.SetFloat("Speed_f", 1.5f);

                // Logique de fuite//
                if (transform.rotation.y > 0)
                {
                    transform.Translate(Vector3.right * speedFuite * Time.deltaTime, Space.World);
                }
                else 
                {
                    transform.Translate(Vector3.left * speedFuite * Time.deltaTime, Space.World);
                }
            }

        }

    }
}
