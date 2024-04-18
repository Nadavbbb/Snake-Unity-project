using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game_Logic : MonoBehaviour
{
    public SnakeController Controll;
    public GameObject[] myObjects;
    // Start is called before the first frame update
    [SerializeField] private GameObject platforms_collection;
    void Start()
    {
        GameObject first_platform = platforms_collection.transform.GetChild(0).gameObject;
        Vector3 top_right_point = Calculate_Top_right(first_platform);
        Vector3 bottom_left_point = Calculate_Bottom_left(first_platform);
        print(top_right_point);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int randomSpawner = Random.Range(0,myObjects.Length);
            Vector3 RandomSpawnerPosition = new Vector3(Random.Range(-10,11), 5, Random.Range(-10,11));
            Instantiate(myObjects[randomSpawner], RandomSpawnerPosition, Quaternion.identity);
        }
    }
    public Vector3 Calculate_Top_right(GameObject platform)
    {
        Vector3 top_right_point = platform.transform.position
            + new Vector3(platform.transform.localScale.x / 2, 10f, platform.transform.localScale.z / 2);
            
        return top_right_point;
    }
    public Vector3 Calculate_Bottom_left(GameObject platform)
    {
        Vector3 bottom_left_point = platform.transform.position
            + new Vector3(-platform.transform.localScale.x / 2, 10f, -platform.transform.localScale.z / 2);

        return bottom_left_point;
    }

    public Vector3 CalculateRandomPlaceToSpawn(Vector3 downLeft, Vector3 topRight)
    {
        Vector3 spawn_pos = transform.position;
        //float random_x = Random.Range(min_x, max_x);
        //float random_z = Random.Range(min_z, max_z);
        return spawn_pos;
    }
}
