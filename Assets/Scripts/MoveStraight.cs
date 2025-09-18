using UnityEngine;

public class MoveStraight : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        transform.Translate(Vector3.forward * 20f * Time.deltaTime, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
