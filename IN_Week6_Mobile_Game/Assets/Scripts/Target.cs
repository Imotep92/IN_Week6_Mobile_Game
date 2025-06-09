using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    private Rigidbody targetRb; //All target items Rigidbodies

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 4;
    private float xRange = 4;
    private float ySpawnPos = -6;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>(); //retrieve rigidbodies of 'target' items

        targetRb.AddForce(RandomForce(), ForceMode.Impulse); //random Y value
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); // random XYZ value

        transform.position = RandomSpawnPos(); // position set as randomised X value
    }

    Vector3 RandomForce() // return method call for random y value in start()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed); // = RandomForce()
    }
   
    float RandomTorque() //return method call for random rotation values in XYZ
    {
        return Random.Range(-maxTorque, maxTorque);  // = RandomTorque()
    }

    Vector3 RandomSpawnPos()  //return method call for random X value, set y value
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos); // = RandomSpawnPos
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    /*EXAMPLE*/
}
