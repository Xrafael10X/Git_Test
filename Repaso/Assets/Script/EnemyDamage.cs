using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Health pHealth;

    int enemyDamage; 
    // Start is called before the first frame update
    void Start()
    {
        enemyDamage = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pHealth.damage(enemyDamage);
        }
    }
}
