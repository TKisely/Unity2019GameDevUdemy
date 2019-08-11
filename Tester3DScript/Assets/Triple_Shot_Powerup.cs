using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triple_Shot_Powerup : MonoBehaviour
{

    private int horizontalBoundary = 8;
    private int verticalBoundary = 7;
    private int baseSpeed = 3;


    // Start is called before the first frame update
    void Start()
    {
        setToBase();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {

        transform.Translate(Vector3.down * Time.deltaTime * baseSpeed);
        if (transform.position.y < (verticalBoundary * -1))
        {
            Destroy(this.gameObject);
        }
    }

    void setToBase()
    {
        transform.position = new Vector3(
            Random.Range((-1*horizontalBoundary),
            horizontalBoundary), Random.Range((-1*verticalBoundary),
            verticalBoundary), 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            player.PoweredUp();
            Destroy(this.gameObject);

        }
        
    }    
}
