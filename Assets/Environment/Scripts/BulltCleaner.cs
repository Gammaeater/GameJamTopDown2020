using UnityEngine;

public class BulltCleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BulletDestroy();
    }
    public void BulletDestroy()
    {
        if (gameObject.tag == "Bullet")
        {
            Destroy(gameObject, 2f);
        }
    }
}

