using UnityEngine;

public class BaseSpawnBonus : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    // Start is called before the first frame update
    public float spawnTime = 5f;
    //The amount of time between each spawn.
    public float spawnDelay = 3f;
    //The amount of time before spawning starts.
    public GameObject[] itemsToSpawn;
    //Array of spawning prefabs.
    public Vector3 enposition;
    public Transform spawnPoint;

    
    void Start()
    {
        //Start calling the Spawn function repeatedly after a delay.
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }
    void Spawn()
    {
        //Instantiate a random enemy.
        int enemyIndex = Random.Range(0, itemsToSpawn.Length -1);
        // Instantiate(enemies[enemyIndex], enposition, transform.rotation);

        
        GameObject newEnemy = Instantiate(itemsToSpawn[enemyIndex], spawnPoint.transform.position, transform.rotation);
        newEnemy.name = "BonusBoost";
    }
}
