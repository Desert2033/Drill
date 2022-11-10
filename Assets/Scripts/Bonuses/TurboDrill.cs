using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboDrill : BaseBonus
{

    private float seconds = 3.5f;

    private int procent = 15;

    private Vector3 scale = new Vector3(0.75f, 0.75f, 0.75f);

    private BonusEffects bonusEffects;

    private void Start()
    {
        effects = new List<IEffect>();
        effects.Add(new BoostMoveOnTime(procent, seconds));
        effects.Add(new ChangeSizeEffect(scale, seconds));
    }

    private void OnTriggerEnter(Collider other)
    {
        bonusEffects = this.GetBonusEffectsType(other);
        bonusEffects.SetEffects(effects);
        Destroy(this.gameObject);
    }

}
