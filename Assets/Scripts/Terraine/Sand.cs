using System.Collections.Generic;
using UnityEngine;

public class Sand : BaseTerraine
{

    private int procentBoost = 25;

    void Start()
    {
        effects = new List<IEffect>();
        effects.Add(new BoostBaseMove(procentBoost));
    }

    private void OnTriggerEnter(Collider other)
    {
        TerraineEffects terraineEffects = GetTerraineEffectsType(other);
        terraineEffects.SetEffects(effects);
    }

    
}
