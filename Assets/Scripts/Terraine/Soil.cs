using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : BaseTerraine
{
    private int procentBoost = 0;

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
