using System.Collections.Generic;
using UnityEngine;


public class CrystalCluster : BaseObstacles
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
        if (other.TryGetComponent(out BaseDrill drill))
        {
            drill.TryGetComponent(out BonusEffects bonusEffects);
            drill.TryGetComponent(out ObstacleEffects obstacleEffects);
            
            if (bonusEffects.IsGigaDrill)
            {
                obstacleEffects.SetEffects(effects);
            }
            else
            {
                Destroy(other.gameObject);
            }
            Destroy(transform.gameObject);
        }
    }

}
