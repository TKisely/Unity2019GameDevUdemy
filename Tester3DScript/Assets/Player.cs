using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float baseSpeed = 3.5f;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject tripleShootPrefab;
    [SerializeField]
    private GameObject shieldVisualizer;
    [SerializeField]
    private GameObject rightEngineDamaged;
    [SerializeField]
    private GameObject leftEngineDamaged;
    
    private int horizontalBoundary = 11;
    private int verticalBoundary = 7;
    private float fireRate = 0.2f;
    private float canFire = 0.0f;
    private int lives = 3;
    private SpawnManager spawnManager;
    private UIManager uiManager;
    private bool isTripleShoot = false;
    private bool isShielded = false;
    private bool isSpeeded = false;
    private int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //set player in the center
        setToBase();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (uiManager==null)
        {
            Debug.LogError("UIisNULL");
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        move();
        fire();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (spawnManager == null)
        {
            Debug.LogError("SPWNMNGR is NULL");
        }
    }

    void move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (isSpeeded)
        {
            Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
            transform.Translate(direction * Time.deltaTime * baseSpeed*2);
        }
        else
        {
            Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
            transform.Translate(direction * Time.deltaTime * baseSpeed);
        }

        

        checkBoundaries();
    }

    void checkBoundaries()
    {
        if (transform.position.y > verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, (verticalBoundary*-1), 0);
        }else if (transform.position.y < (verticalBoundary * -1))
        {
            transform.position = new Vector3(transform.position.x, (verticalBoundary), 0);
        }

        if (transform.position.x > horizontalBoundary)
        {
            transform.position = new Vector3((horizontalBoundary*-1), transform.position.y, 0);
        } else if (transform.position.x < (horizontalBoundary*-1))
        {
            transform.position = new Vector3((horizontalBoundary), transform.position.y, 0);
        }
    }

    void setToBase()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void fire()
    {

        if (Input.GetKeyDown(KeyCode.Space)&&Time.time>canFire)
        {
            if (isTripleShoot)
            {
                Instantiate(tripleShootPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            }
            AudioManager.Laser();
            canFire = Time.time + fireRate;
            
        }
    }

    public void Damaged()
    {
        if (!isShielded)
        {
            lives--;
            uiManager.updateLives(lives);

            if(lives == 2) { rightEngineDamaged.SetActive(true); }
            if(lives == 1) { leftEngineDamaged.SetActive(true); }

            if (lives < 1)
            {
                uiManager.displayGameOver();
                spawnManager.onPlayerDeath();
                AudioManager.Explosion();
                Destroy(this.gameObject);
            }
        }else { isShielded = false; shieldVisualizer.SetActive(false); }
        
    }

    public void PoweredUp()
    {
        isTripleShoot = true;
        StartCoroutine(TripleShotActivated());
        
    }

    public void SpeededUp()
    {
        isSpeeded = true;
        AudioManager.PowerUp();
        StartCoroutine(SpeedUpActivated());
    }

    public void ShieldedUp()
    {
        isShielded = true;
        shieldVisualizer.SetActive(true);
        AudioManager.PowerUp();
        StartCoroutine(ShieldActivated());
    }

    public void addScore()
    {
        score += 10;
        uiManager.updateScore(score);
    }

    public bool isAlive()
    {
        return (lives>0);
    }

    IEnumerator TripleShotActivated()
    {
        
            yield return new WaitForSeconds(5.0f);
        isTripleShoot = false;
        

    }

    IEnumerator ShieldActivated()
    {

        yield return new WaitForSeconds(50.0f);
        isShielded = false;
        shieldVisualizer.SetActive(false);


    }

    IEnumerator SpeedUpActivated()
    {

        yield return new WaitForSeconds(5.0f);
        isSpeeded = false;


    }
}
