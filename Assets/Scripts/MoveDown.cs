using UnityEngine;

public class MoveDown : MonoBehaviour
{

    public float speed = 2f;// Vitesse de mouvement vers le bas 

    private float Bound = 40f;//Limite sur l'axe z avant que les objets animaux soit détruits

    private Vector3 startPos;//Position du backGround au départ du jeu

    private float repeatWidth = 50f;//Distance de déplacement avant la répétition du backGround

    GameOverTrigger trigger;// trigger qui enclenche le gameOver


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trigger = GameObject.Find("Player").GetComponent<GameOverTrigger>();

        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Pendant le jeu les animaux et le backGround vont vers le bas
        if (!trigger.gameOver)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

        }

        //Si le backGround se déplace de 50f vers le bas on le répète (Effet d'infinité du sol du jeu)
        if (transform.position.z > startPos.z + repeatWidth && gameObject.CompareTag("BackGround"))
        {
            transform.position = startPos;
        }

        //Si l'animal dépasse la limite de 40f vers le bas on le détruit
        if (transform.position.z > Bound && gameObject.CompareTag("Animal"))
        {
            Destroy(gameObject);
        }

    }
}
