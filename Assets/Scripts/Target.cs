using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private GameManager1 gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),
         ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > 0.1f && gameObject.name == "Bad 1(Clone)")
        {
            gameObject.tag = "Bad";
        }
        if (gameObject.transform.position.y <= 0 && gameObject.name == "Bad 1(Clone)")
        {
            gameObject.tag = "Untagged";
        }
        if (transform.position.y < -7 || !gameManager.isGameActive)
        {
            Destroy(gameObject);
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }
    //private void OnMouseDown()
    //{
    //    if (gameManager.isGameActive)
    //    {
    //        Destroy(gameObject);
    //        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    //        gameManager.UpdateScore(pointValue);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {       
        if (gameObject.CompareTag("Bad") && other.gameObject.CompareTag("Swiper"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue); 
            gameManager.UpdateLives(-1);
        }
        if (!gameObject.CompareTag("Bad") && other.gameObject.CompareTag("Swiper"))
        {
            DestroyTarget();
        }
    }
    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
}
