using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public LayerMask obstacleLayer;
    RaycastHit hit;
    public Vector3 offset;

    public GameObject bullet;
    public Transform firePoint;

    private float coolDown;

    public AudioClip gunshot;

    public GameObject hand;

    private void Update()
    {
        // Look
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, obstacleLayer)) 
        {
            hand.transform.LookAt(hit.point);
            hand.transform.rotation *= Quaternion.Euler(offset); 
        }


        // CoolDown
        if (coolDown > 0) 
        {
            coolDown -= Time.deltaTime;
        }

        // Fire
        if (Input.GetMouseButtonDown(0) && coolDown <= 0)  
        {
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
            coolDown = 0.25f;

            // Sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunshot, 0.3f);

            // Animation
            GetComponent<Animator>().SetTrigger("shotTrigger");


        }
         

    }
}
