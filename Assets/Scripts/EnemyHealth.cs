using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Adds amount to maxHitPoints when emeny dies.")]
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints = 0;
    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();    
    }

    void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
