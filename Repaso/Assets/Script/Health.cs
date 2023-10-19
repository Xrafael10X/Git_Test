using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Health : MonoBehaviour
{
    int health;
    [SerializeField] int maxHealth;
    int damageCount;
    Vector2 lastRespawn;
    public HealthBar UIhealthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        lastRespawn = transform.position;
        UIhealthBar.SetHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damage(int damageCount) 
    {
        health = health - damageCount;
       
        if (health <= 0)
        {
            Respawn();
            health = maxHealth;
        }
        UIhealthBar.SetHealth(health);
    }

    private void Respawn()
    {
        transform.position = lastRespawn;
    }


}
