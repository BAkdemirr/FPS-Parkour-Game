using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool player_enter, player_exit;
    private bool spawned=false;

    public Transform[] drone_spawners;
    public GameObject drone;

    public GameObject level;
    public GameObject destroy_level;

    private void Awake()
    {
        player_enter = false;
        spawned = false;
    }

    private void Update()
    {
        // Drone Spawned
        if (!spawned) 
        {
            if (player_enter)
            {
                for (int i = 0; i < drone_spawners.Length; i++)
                {
                    Instantiate(drone, drone_spawners[i].position, Quaternion.identity);
                }

                // level spawn
                SpawnLevel();

                // set boolean
                spawned = true;
            }
        }

        if (player_exit)
        {
            if (destroy_level != null) 
            {
                DestroyLevel();
            }
        }
    }

    private void SpawnLevel()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 85);
        GameObject obj = Instantiate(level, pos, Quaternion.identity);
        obj.GetComponent<LevelManager>().destroy_level = this.gameObject;
    }

    private void DestroyLevel()
    {
        Destroy(destroy_level);
    }

}
