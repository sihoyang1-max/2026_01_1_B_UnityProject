using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript2 : MonoBehaviour
{
    public int maxlives = 3;
    public int curentLives;

    public float invincblcTime = 1.0f;
    public bool isinvincible = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curentLives = maxlives;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Missile"))
        {
            curentLives--;
            Destroy(other.gameObject);
            
            if (curentLives <= 0)
            {
                GameOver();
            }
        }
    }
    void GameOver()
    {
        gameObject.SetActive(false);
        Invoke("RestartGame", 3.0f);
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
    
    }
}
