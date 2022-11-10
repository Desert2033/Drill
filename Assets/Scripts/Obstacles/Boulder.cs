using System.Collections.Generic;
using UnityEngine;


public class Boulder : BaseObstacles
{

    private int procentSlowdown = 50;
    private int secondDebuff = 3;

    void Start()
    {
        effects = new List<IEffect>();
        effects.Add(new SlowdownMoveOnTime(procentSlowdown, secondDebuff));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ObstacleEffects obstacleEffects))
        {
           obstacleEffects.SetEffects(effects);
           Destroy(transform.gameObject);
        }
    }

}
