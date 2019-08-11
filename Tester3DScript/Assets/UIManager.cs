using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Sprite[] liveSprites;
    [SerializeField]
    private Image livesImage;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Image gameOverIMG;
    [SerializeField]
    private Text restartText;
    [SerializeField]
    private GameManager gmanager;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
        gameOverIMG.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
        gmanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gmanager.Equals(null))
        {
            Debug.LogError("GMManagerNULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int playerScore)
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void updateLives(int currentLives)
    {
        livesImage.sprite = liveSprites[currentLives];
    }

    public void displayGameOver()
    {
        //gameOverText.gameObject.SetActive(true);
        gameOverIMG.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        gmanager.GameOver();
        StartCoroutine(flickrGameOver());
        moveGameOver();

        
    }

    public void moveGameOver()
    {
        gameOverIMG.transform.Translate(Vector3.down * Time.deltaTime*1);
    }

    IEnumerator flickrGameOver()
    {
        while (true)
        {
            restartText.text = "Press the 'R' key to restart the level";
            yield return new WaitForSeconds(0.3f);

            restartText.text = "";
            yield return new WaitForSeconds(0.3f);
        }
        
    }
}
