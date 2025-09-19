using UnityEngine;

public class MoveDown : MonoBehaviour
{

    public float speed = 2f;
    private float Bound = 40f;


    private Vector3 startPos;
    private float repeatWidth = 50f;

    private Rigidbody animalRB;

    

    GameOverTrigger trigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trigger = GameObject.Find("Player").GetComponent<GameOverTrigger>();
        startPos = transform.position;

        //animalRB = GameObject.Find("Animal").GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //animalRB.AddForce(Vector3.right *  10f, ForceMode.Force);

        if (!trigger.gameOver)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

        }


        if (transform.position.z > startPos.z + repeatWidth && gameObject.CompareTag("BackGround"))
        {
            transform.position = startPos;
        }

        if (transform.position.z > Bound && gameObject.CompareTag("Animal"))
        {
            Destroy(gameObject);
        }

    }
}
