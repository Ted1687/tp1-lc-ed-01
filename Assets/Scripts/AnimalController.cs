using UnityEngine;

public class cowMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed = 5f;
    public float progress;

    private Animator animalAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       animalAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);


    }
}
