using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : BaseTerraine
{

    private int procentSlowdown = 50;

    void Start()
    {
        effects = new List<IEffect>();
        effects.Add(new SlowdownBaseMove(procentSlowdown));
    }

    private void OnTriggerEnter(Collider other)
    {
        TerraineEffects terraineEffects = GetTerraineEffectsType(other);
        terraineEffects.SetEffects(effects);
    }


}
