using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;

    public float speed = 15.0f;
    private float xRange = 15;
    private float yHighBound = 7;
    private float yLowBound = 3;
    private float zBound = -30;

    public int pointValue;

    public ParticleSystem goodParticle;
    public ParticleSystem badParticle;

    private AudioSource playerAudio;
    public AudioClip goodSound;
    public AudioClip badSound;
    public AudioClip powerUpSound;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Spawn targets at random positions
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        //The objects constantly move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //Destroys the object if it goes past the player's view
        if (transform.position.z < zBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        //Destroy object and update score
        if(gameManager.isGameActive && CompareTag("Bad"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
        //Destroy object and update score
        else if (gameManager.isGameActive && CompareTag("Good"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
        //Check for power up and start power up countdown
        else if(gameManager.isGameActive && CompareTag("PowerUp"))
        {
            Time.timeScale = 0.5f;
            Destroy(gameObject);
            gameManager.StartTimer();
        }
    }

    //Detect 'Good' objects which pass the players view and then end the game
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Good"))
        {
            gameManager.GameOver();
        }
    }


    Vector3 RandomSpawnPos()
    {
        //Generate random spawn positions
        float spawnPositionX = Random.Range(-xRange, xRange);
        float spawnPositionY = Random.Range(yLowBound, yHighBound);

        Vector3 randomPosition = new Vector3(spawnPositionX, spawnPositionY, 23);

        return randomPosition;
    }
}
