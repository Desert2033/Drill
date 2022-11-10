using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTerraine : MonoBehaviour
{

    protected List<IEffect> effects;

    void Start()
    {
        effects = new List<IEffect>();
    }


    protected TerraineEffects GetTerraineEffectsType(Collider other)
    {
        if (other.TryGetComponent(out TerraineEffects terraineEffects))
        {
            return terraineEffects;
        }

        throw new System.Exception("Terraine Effects not found in class" + this.GetType());
    }

}
