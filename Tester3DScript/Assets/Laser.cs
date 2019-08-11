using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float baseSpeed = 13.5f;

    private int verticalBoundary = 7;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        Vector3 direction = new Vector3(0, 1, 0);
        transform.Translate(direction * Time.deltaTime * baseSpeed);

        if (transform.position.y > verticalBoundary)
        {
            if (transform.parent != null) { Destroy(transform.parent.gameObject); }
            Destroy(this.gameObject);
        }

    }
}
