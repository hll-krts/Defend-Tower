using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    public float EnemyDamage;
    public float EnemyHealth;
    public float speed;
    float DestroyTime;


    void Start()
    {
    }


    void Update()
    {
        transform.position = transform.position + transform.forward * -speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player_sc player = other.transform.GetComponent<Player_sc>();
            if (player != null)
            {
                player.Hasar();
            }
            Destroy(this.gameObject);
        }
        else if (other.tag == "Ates")
        {
            EnemyHealth -= GameObject.FindObjectOfType<Fire_sc>().Damage;
            if (EnemyHealth < 1)
            {
                DestroyTime = Time.time + 1;
                GameObject.FindObjectOfType<Fire_sc>().Target_Counter();
                Destroy(this.gameObject);
            }
        }
        else if (other.tag == "Tower")
        {
            Destroy(this.gameObject);
        }
    }
}
