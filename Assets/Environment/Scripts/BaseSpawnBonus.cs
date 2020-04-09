using UnityEngine;

public class BaseSpawnBonus : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    // Start is called before the first frame update
    public float spawnTime = 20f;
    //The amount of time between each spawn.
    public float spawnDelay = 3f;
    //The amount of time before spawning starts.
    public GameObject itemsToSpawn;
    //Array of spawning prefabs.
    public Vector3 enposition;
    public Transform spawnPoint;

    
    void Start()
    {
        
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }
    void Spawn()
    {
        

        
        GameObject newEnemy = Instantiate(itemsToSpawn, spawnPoint.transform.position, transform.rotation);
        newEnemy.name = "BonusBoost";
    }
}
