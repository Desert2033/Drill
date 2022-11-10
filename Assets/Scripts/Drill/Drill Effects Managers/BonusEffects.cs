using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEffects : MonoBehaviour
{

    private List<IEffect> bonusEffects = new List<IEffect>();

    public bool IsGigaDrill { get; set; }

    public bool IsTurboDrill { get; set; }

    private void Update()
    {
        for (int i = 0; i < bonusEffects.Count; i++)
        {
            if (!bonusEffects[i].IsLife)
            {
                bonusEffects[i].DisableEffect();
                bonusEffects.Remove(bonusEffects[i]);
                IsGigaDrill = false;
            }
        }
    }

    public void SetEffects(List<IEffect> effects)
    {

        if (bonusEffects.Count != 0)
        {
            foreach (var item in bonusEffects)
            {
                item.DisableEffect();
            }
            bonusEffects.Clear();
        }

        bonusEffects = effects;

        foreach (var element in bonusEffects)
        {
            element.MakeEffect(this.gameObject);
        }

    }

    public List<IEffect> GetEffects()
    {
        return bonusEffects;
    }

}
