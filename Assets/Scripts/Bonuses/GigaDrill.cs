using System.Collections.Generic;
using UnityEngine;

public class GigaDrill : BaseBonus
{

    private float seconds = 3.5f;

    private int procent = 15;

    private Vector3 scale = new Vector3(1.25f, 1.25f, 1.25f);

    private BonusEffects bonusEffects;

    private void Start()
    {
        effects = new List<IEffect>();
        effects.Add(new SlowdownMoveOnTime(procent, seconds));
        effects.Add(new ChangeSizeEffect(scale, seconds));
    }

    private void OnTriggerEnter(Collider other)
    {
        bonusEffects = this.GetBonusEffectsType(other);
        bonusEffects.SetEffects(effects);
        bonusEffects.IsGigaDrill = true;
        Destroy(this.gameObject);
    }

}
