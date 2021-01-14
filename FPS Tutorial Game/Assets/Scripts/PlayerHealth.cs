using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(int damage)
    {
        print("ow");
        hitPoints -= damage;
        print(hitPoints + " " + damage);
        if (hitPoints <= 0)
        {
            print("dead");
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
