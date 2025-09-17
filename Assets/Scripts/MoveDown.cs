using UnityEngine;

public class MoveDown : MonoBehaviour
{

    public float speed = 5f;

    private float upBound = 25;

    PlayerController playerControllerSript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerSript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerSript.gameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        //if (transform.position.x > upBound && gameObject.CompareTag("Animal"))
        //{
        //    Destroy(gameObject);
        //}

    }
}
