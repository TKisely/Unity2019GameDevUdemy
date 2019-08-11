using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    private static AudioSource explosionSource;
    private static AudioSource laserSource;
    private static AudioSource powerUpSource;
    

    // Start is called before the first frame update
    void Start()
    {
        
        explosionSource = GameObject.Find("Explosion").GetComponent<AudioSource>();

        if(explosionSource==null )
        {
            Debug.LogError("AUDIOERROR");
        }

        laserSource = GameObject.Find("Laser").GetComponent<AudioSource>();

        if (laserSource == null)
        {
            Debug.LogError("AUDIOERROR");
        }

        powerUpSource = GameObject.Find("PowerUp").GetComponent<AudioSource>();

        if (powerUpSource == null)
        {
            Debug.LogError("AUDIOERROR");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Explosion()
    {
        explosionSource.Play();
    }

    public static void Laser()
    {
        laserSource.Play();
    }

    public static void PowerUp()
    {
        powerUpSource.Play();
    }
}
