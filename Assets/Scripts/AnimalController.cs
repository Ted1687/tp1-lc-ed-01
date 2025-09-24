using UnityEngine;

public class AnimalController : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip;
    
    public float speed = 10f;

    public float speedFuite = 8f;

    //Limite de d�placement
    private float limiteGauche = 9f;
    private float limiteDroite = -9f;

    private bool movingLeft = true; //L'animal va � gauche

    private Animator animalAnim; //Composant animator

    private Rigidbody animalRB; // Composant rigidBody

    private GameOverTrigger trigger; //Trigger qui enclenche le game over

    private GameObject player; //Le player

    private bool hungry = true; //D�termine si l'animal est nourrit

    private float animationEatDuration = 2f; //Dur�e de l'animation Eat

    private float progress = 0f; //Progr�s du temps


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animalAnim = GetComponent<Animator>();

        animalRB = GetComponent<Rigidbody>();

        trigger = GameObject.Find("Player").GetComponent<GameOverTrigger>();

        player = GameObject.Find("Player");
        
        audioSource = GetComponent<AudioSource>();


    }

    public void Manger()
    {
        hungry = false;//L'aniaml est nourrit. Il n'a plus faim.
        
        if(!audioSource.isPlaying)
            audioSource.PlayOneShot(audioClip);
    }

    // Update is called once per frame
    void Update()
    {

        //Game over si l'animal affam� d�passe le joueur
        if (transform.position.z > player.transform.position.z + 2 && hungry)
        {
            trigger.gameOver = true;
            trigger.jouerSoundGameOver();//Son de game over
            
        }

        //L'animmal est affam� et en jeu
        if (hungry && !trigger.gameOver)
        {

            if (movingLeft)
            {
                //L'animal va � gauche
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
                
            }
            else
            {
                //L'animal va � droite
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }

            //Il fait demi tour au diff�rente limite
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

        }//L'animal est nourrit et en jeu
        else if (!hungry && !trigger.gameOver)
        {

            progress += Time.deltaTime;

            if (progress < animationEatDuration)
            {
                animalAnim.SetBool("Eat_b", true);//L'animation eat est d�clench�

            }
            else if (progress > animationEatDuration)
            {
                //Apr�s un certain temps l'animation passe de eat � running
                animalAnim.SetBool("Eat_b", false);
                animalAnim.SetFloat("Speed_f", 1.5f);

                //L'animal sort du c�t� gauche ou droite en fonction de sa direction de rotation
                if (transform.rotation.y > 0)
                {
                    transform.Translate(Vector3.right * speedFuite * Time.deltaTime, Space.World);
                }
                else
                {
                    transform.Translate(Vector3.left * speedFuite * Time.deltaTime, Space.World);
                }
            }

        }//C'est le game over
        else if(trigger.gameOver)
        {

            //Animation de game Over
            //Physics.gravity = new Vector3(0, -9.81f * 10f, 0);
            //bool auSol = true;
            //if (auSol)
            //{
            //    animalRB.AddForce(Vector3.up * 1f, ForceMode.Impulse);
            //}

        }

    }
}
