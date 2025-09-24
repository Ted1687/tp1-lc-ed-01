using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f; //Vitesse de déplacement du joueur
    
    private float horizontalInput;

    //Les limites de déplacements à l'écran
    private float leftBound  = 9f;

    private float rightBound = -9f;


    private static GameOverTrigger trigger; //Trigger qui active le gameOver

    private Animator playerAnim; //Composant animator

    public GameObject foodPrefab; //La nourriture lancée

    public ParticleSystem fx_foodThrow;// particule qui s'active quand on lance la nourriture



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trigger = GetComponent<GameOverTrigger>();

        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (!trigger.gameOver)
        {
            //Pendant le jeu, input gauche et droite
            if (horizontalInput > 0 && transform.position.x > rightBound && !trigger.gameOver)
            {
                //Le joueur va à droite avec un léger changement d'angle pour animer le mouvement
                //Il ne dépasse la limite à droite
                transform.rotation = Quaternion.Euler(0, 195, 0);
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }
            else if (horizontalInput < 0 && transform.position.x < leftBound && !trigger.gameOver)
            {
                //Le joueur va à gauche avec un léger changement d'angle pour animer le mouvement
                //Il ne dépasse la limite à gauche
                transform.rotation = Quaternion.Euler(0, 165, 0);
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            }
            else
            {
                //Le joueur court tout droit
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            //Pendant le jeu, input espace
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Instancie un objet de jeu (Préfabriqué) de nourriture
                GameObject food = Instantiate(foodPrefab, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.Euler(0,180,0));

                //E»ffet de particule qui accompagne le lancer
                fx_foodThrow.Play();
            }

        }//Lors d'un gameOver
        else if (trigger.gameOver)
        {
            //animation de mort du joueur quand game over
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);

            //Il devient static quand game over. Il ne court plus, l'animation change
            playerAnim.SetFloat("Speed_f", 0.20f);
        }
        
    }
  
}
