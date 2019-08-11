using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float baseSpeed = 1.5f;
    private int horizontalBoundary = 9;
    private int verticalBoundary = 7;
    private Player player;
    private Animator destroyAnim;
    private bool isNotShoted = true;

    // Start is called before the first frame update
    void Start()
    {
        setToBase();
        player = GameObject.Find("Player").GetComponent<Player>();
        if (player.Equals(null))
        {
            Debug.LogError("PLYRnull");
        }

        destroyAnim = GetComponent<Animator>();
        if (destroyAnim.Equals(null))
        {
            Debug.LogError("PLYRnull");
        }

        //audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * baseSpeed);

        if (transform.position.y < (-1 * verticalBoundary))
        {
            setToBase();
        }
    }

    void setToBase()
    {
        //Random.Range((-1*horizontalBoundary),horizontalBoundary), verticalBoundary)
        float randomX= Random.Range((-1 * horizontalBoundary), horizontalBoundary);
        transform.position = new Vector3(randomX, verticalBoundary, 0);
    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            
            Player player = other.transform.GetComponent<Player>();
            destroyAnim.SetTrigger("onEnemyDeath");
            baseSpeed = 0;
            Destroy(this.gameObject, 2.5f);
            player.Damaged();

        } else if (other.tag=="Laser") {
            Destroy(other.gameObject);
            if (player.isAlive()&&isNotShoted)
            {
                player.addScore();
                isNotShoted = false;
            }
            baseSpeed = 0;
            destroyAnim.SetTrigger("onEnemyDeath");
            AudioManager.Explosion();
            Destroy(this.gameObject, 2.5f);
            
        }

        //setToBase();
    }

    
}
