using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    private SpawnManager spawnManager;

    private float baseSpeed = 0.5f;
    private int horizontalBoundary = 9;
    private int verticalBoundary = 7;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        setToBase();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back*baseSpeed*20*Time.deltaTime);
        transform.Translate(Vector3.down*baseSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            AudioManager.Explosion();
        }
        else if (other.tag=="Player")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Player player = other.transform.GetComponent<Player>();
            Destroy(this.gameObject);
            player.Damaged();
            AudioManager.Explosion();
        }
        

        //spawnManager.corutineStarter();

    }

    void setToBase()
    {
        //Random.Range((-1*horizontalBoundary),horizontalBoundary), verticalBoundary)
        float randomX = Random.Range((-1 * horizontalBoundary), horizontalBoundary);
        transform.position = new Vector3(randomX, verticalBoundary, 0);
    }

}
