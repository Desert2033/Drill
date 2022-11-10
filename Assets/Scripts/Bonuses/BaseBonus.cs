using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBonus : MonoBehaviour
{

    protected List<IEffect> effects;


    protected BonusEffects GetBonusEffectsType(Collider other)
    {
        if (other.TryGetComponent(out BonusEffects bonusEffects))
        {
            return bonusEffects;
        }

        throw new System.Exception("Bonus Effects not found in class" + this.GetType());
    }

}
