using UnityEngine;

public class EnemiesPool : MonoBehaviour
{
    public int enemiesPoolSize = 10;
    private GameObject[] enemies;
    public float spawnRate = 4f;


    public GameObject enemyPrefab;
    private Vector2 objectPoolPosition = new Vector2(-15, -25f);
    private float timeSinceLastSpawned;



    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[enemiesPoolSize];
        for (int i = 0; i < enemiesPoolSize; i++)
        {
            enemies[i] = (GameObject)Instantiate(enemyPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //timeSinceLastSpawned += Time.deltaTime;
        //if(GameManager.IsGameOver == false  && timeSinceLastSpawned >= spawnRate) {
        //    timeSinceLastSpawned = 0;
        //    float spawnPosition  = Random.Range()
    }

}

