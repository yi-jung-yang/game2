using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public List<GameObject> targets;
    float rate = 1.0f;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isplay;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        isplay = true;
        StartCoroutine(spawnObject());
        scoreText.text = "Score:" + score;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnObject()
    {
        while (isplay)
        {
            yield return new WaitForSeconds(rate);
            int ind = Random.Range(0, targets.Count);
            Instantiate(targets[ind]);

        }
    }

    public void updateScore(int point)
    {
        score += point;
        scoreText.text = "Score:" + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        isplay = false;
    }
}
