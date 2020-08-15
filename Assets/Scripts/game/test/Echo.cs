using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    private MoveBehaviour jump;
    public GameObject echo;

    private float timeBtSpawn;
    [SerializeField] private float spawnRate;

    private void Start()
    {
        jump = GetComponent<MoveBehaviour>();
    }

    private void Update()
    {
        if(jump.GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            if(timeBtSpawn >= spawnRate)
            {
                if(jump.moveH > 0)
                {
                    GameObject instance = Instantiate(echo, transform.position, Quaternion.identity);
                    Destroy(instance, 2.0f);
                    timeBtSpawn = 0;
                }
                if(jump.moveH < 0)
                {
                    GameObject instance = Instantiate(echo, transform.position, Quaternion.identity);
                    instance.transform.eulerAngles = new Vector3(0, 180, 0);
                    Destroy(instance, 2.0f);
                    timeBtSpawn = 0;
                }
            }
            else
            {
                timeBtSpawn += Time.deltaTime;
            }
        }
    }

}
