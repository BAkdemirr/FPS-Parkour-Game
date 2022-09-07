using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacle, player_layer;

    public GameObject death_effect;

    public float laser_multiplier = 1;

    private bool laser_hit;
    public float range = 100f;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, obstacle)) 
        {
            GetComponent<LineRenderer>().enabled = true;
            laser_hit = true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            // laserin büyüyüp küçülmesi. Matematikteki sin fonksiyonunun grafiği ile yapılıyor.
            GetComponent<LineRenderer>().startWidth = 0.025f * laser_multiplier + Mathf.Sin(Time.time) / 80;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
            laser_hit = false;
        }

        // Kill player
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, player_layer)) 
        {
            if (laser_hit)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    hit.transform.gameObject.GetComponent<PlayerManager>().Death();
                }
            }
        }


    }
}
