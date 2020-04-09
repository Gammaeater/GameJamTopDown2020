using UnityEngine;


public class EnemySpawner : Wave
{
    [SerializeField] private Transform playerTransform;
    // Start is called before the first frame update
    public float spawnTime = 5f;
    //The amount of time between each spawn.
    public float spawnDelay = 3f;
    //The amount of time before spawning starts.
    public GameObject[] enemies;
    //Array of enemy prefabs.
    public Vector3 enposition;

    private Wave waveController;
    void Start()
    {
        //Start calling the Spawn function repeatedly after a delay.
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }
    void Spawn()
    {
        //Instantiate a random enemy.
        int enemyIndex = Random.Range(0, enemies.Length);
        // Instantiate(enemies[enemyIndex], enposition, transform.rotation);
        GameObject newEnemy = Instantiate(enemies[enemyIndex], enposition, transform.rotation);
        newEnemy.name = "Alien";

    }

    void SpawnManualy()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            int enemyIndex = Random.Range(0, enemies.Length);
            GameObject newEnemy = (GameObject)Instantiate(enemies[enemyIndex], enposition, transform.rotation);
            newEnemy.name = "Alien2";




            waveController.SpawnEnemies();
        }
    }

}

[System.Serializable]
public class Wave : MonoBehaviour
{
    [SerializeField] private GameObject[] enemySpawyArray;
    [SerializeField] private float timer;



    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                SpawnEnemies();
            }
        }

    }


    public void SpawnEnemies()
    {
        foreach (GameObject enemySpawn in enemySpawyArray)
        {
            int enemyIndex = Random.Range(0, enemySpawyArray.Length);
            GameObject newEnemy = (GameObject)Instantiate(enemySpawn,transform.position, transform.rotation);
        }

    }
}
