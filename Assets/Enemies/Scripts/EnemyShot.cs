using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private float angle;
    [SerializeField] public float bulletSpeed;
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public GameObject target;

    [SerializeField] public Vector2 moveDirection;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Vector3 thisPos;
    [SerializeField] private float timeSinceLastRangeShot;
    [SerializeField] private float TimeBetweenRangeShots ;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        {
            if (distance < 100f )//&& target.enemyHealtSystem.GetHealth() >= 1)
            {
                if (Time.time > timeSinceLastRangeShot + TimeBetweenRangeShots)
                {


                    Shoot();







                    timeSinceLastRangeShot = Time.time;

                }




            }
        }


    }



    public void Shoot()
    {
        

        GameObject bullet = Instantiate(bulletPrefab, transform.position, target.transform.rotation);
        Rigidbody2D rbbullet2 = bullet.GetComponent<Rigidbody2D>();
        moveDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        rbbullet2.velocity = new Vector2(moveDirection.x, moveDirection.y);


        float offset = -90f;

        targetPos = target.transform.position;
        thisPos = rbbullet2.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        rbbullet2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));


    }
}
