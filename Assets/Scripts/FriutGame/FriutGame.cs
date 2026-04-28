using UnityEngine;

public class FriutGame : MonoBehaviour
{

    public GameObject[] friutPrefabs;
    public float[] fruitSize = { 0.5f, 0.7f, 0.9f, 1.1f, 1.3f, 1.5f, 1.7f, 1.9f };

    public GameObject currentFruit;
    public int currentFruitTyp;

    public float fruitStartHeiheght = 6.0f;
    public float gameWidth = 5.0f;
    public bool isGameOver = false;
    public Camera maincamera;

    void SpawnNewFruit()
    {
        if (!isGameOver)
        {
            currentFruitType = Random.Range(0, 3);

            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = maincamera.ScreenToWorldPoint(mousePosition);

            Vector3 spawnPosition = new Vector3(worldPosition.x, fruitStartHeiheght, 0);

            float halFruitSize = fruitSizes[currentFruitType] / 2f;

            spawnPosition.x = Mathf.Clamp(spawnPosition.x, -gameWidth / 2 + halFruitSize, gameWidth / 2 - halFruitSize);

            currentFruit = Instantiate(fruitPrefabs[currentFruitype], spawnPosition, Quaternion.identity);
            currentFruit.transform.localScale = new Vector3(fruitSuzes[currentFruitType], fruitSizes[currentFruitType], 1);

            Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();

            if (rb != null )
            {
                rb,gravityScale = 0f;
            }
        }
    }
}
