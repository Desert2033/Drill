using System.Collections.Generic;
using UnityEngine;

public class Bones : BaseObstacles
{

    private int procentSlowdown = 25;
    private int secondDebuff = 7;

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
