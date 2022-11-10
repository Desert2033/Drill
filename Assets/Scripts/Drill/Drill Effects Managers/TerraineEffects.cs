using System.Collections.Generic;
using UnityEngine;

public class TerraineEffects : MonoBehaviour
{

    private List<IEffect> terraineEffects = new List<IEffect>();

    public void SetEffects(List<IEffect> effects)
    {
        if (terraineEffects.Count != 0)
        {
            foreach (var item in terraineEffects)
            {
                item.DisableEffect();
            }
            terraineEffects.Clear();
        }

        terraineEffects = effects;

        foreach(var element in terraineEffects)
        {
            element.MakeEffect(this.gameObject);
        }
    }

}
