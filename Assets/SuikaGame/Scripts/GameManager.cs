using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject fruitPrefab;
    public GameObject[] fruitPrefabs;
    public int score = 0;
    public TMP_Text scoreText;
    public GameObject playAgainButton;
    public GameObject scoreTextObject;
    public bool gameOver = false;

    public GameObject normalBlob;
    public GameObject dieBlob;

    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Instantiates the fruit prefab with the given parameters
    /// </summary>
    public GameObject InstantiateFruit(Vector3 position, int id)
    {
        GameObject combinedFruit = Instantiate(fruitPrefabs[id], position, Quaternion.identity);
        combinedFruit.GetComponent<Fruit>().id = id;
        return combinedFruit;
    }

    public void switchBlob(bool isDead)
    {
        if (isDead)
        {
            dieBlob.SetActive(true);
            normalBlob.SetActive(false);
        }
        else
        {
            normalBlob.SetActive(true);
            dieBlob.SetActive(false);
        }
    }

    /// <summary>
    /// Adds score based on the id of the fruit
    /// </summary>
    public void addScore(int id)
    {
        switch (id)
        {
            case 0:
                score += 1;
                break;
            case 1:
                score += 2;
                break;
            case 2:
                score += 4;
                break;
            case 3:
                score += 8;
                break;
            case 4:
                score += 16;
                break;
            case 5:
                score += 32;
                break;
            case 6:
                score += 64;
                break;
            case 7:
                score += 128;
                break;
            case 8:
                score += 256;
                break;
            case 9:
                score += 512;
                break;
            case 10:
                score += 1024;
                break;
        }
        scoreText.text = "Score: " + score.ToString();
    }

    public void endGame()
    {
        gameOver = true;
        playAgainButton.SetActive(true);
    }

    public void playAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
