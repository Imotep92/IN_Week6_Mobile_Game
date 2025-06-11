using System.Collections;
using UnityEditor.Build.Content;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    
    private GameManger gameManager; // Access to GameManager.cs
    

    #region GameObjects: Targets
    private Rigidbody targetRb; // Access to all target items' Rigidbodies

    private float minSpeed = 12; // minimum speed
    private float maxSpeed = 16; // maximum speed
    private float maxTorque = 4; // maximum Torque(rotation)
    private float xRange = 4; // range along the x axis
    private float ySpawnPos = -6; // 'targets' spawn at a specified point on y axis

    public int pointValue; // individual point values assigned to 'targets'

    public ParticleSystem explosionParticle; // explosion particles for each target 
    #endregion GameObjects: Targets


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManger>(); // initialise access to GameManager GameObject
       

        targetRb = GetComponent<Rigidbody>(); // intialise access to rigidbodies of 'target' items

        targetRb.AddForce(RandomForce(), ForceMode.Impulse); //random Y value
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); // random XYZ value

        transform.position = RandomSpawnPos(); // position set as randomised X value

        
    }

    Vector3 RandomForce() // return method call for random y value in start()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed); // = RandomForce()
    }
   
    float RandomTorque() // return method call for random rotation values in XYZ
    {
        return Random.Range(-maxTorque, maxTorque);  // = RandomTorque()
    }

    Vector3 RandomSpawnPos()  // return method call for random X value, set y value
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos); // = RandomSpawnPos
    }

    private void OnMouseDown()  // return method call for what should happen to targets upon mouse click
    {
        if (gameManager.isGameActive) //only when isGameActive bool is set to 'true' 
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
    }

    private void OnTriggerEnter(Collider other) // call method for targets that fall into the collider sttached to the 'sensor' GameObject
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

        /*if (gameManager.lives <= 0)
        {
            
            gameManager.UpdateLives(1);
        }*/
            
    }

    // Update is called once per frame
    void Update()
    {
    

    }
    
    /*EXAMPLE*/
}
