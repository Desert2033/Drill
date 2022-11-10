using System.Collections.Generic;
using UnityEngine;

public class ObstacleEffects : MonoBehaviour
{

    private List<IEffect> obstacleEffects = new List<IEffect>();

    private void Update()
    {
        for (int i = 0; i < obstacleEffects.Count; i++)
        {
            if (!obstacleEffects[i].IsLife)
            {
                obstacleEffects[i].DisableEffect();
                obstacleEffects.Remove(obstacleEffects[i]);
            }
        }
    }

    public void SetEffects(List<IEffect> effects)
    {
        foreach (var item in effects)
        {
            item.MakeEffect(this.gameObject);
        }
        obstacleEffects.AddRange(effects);
    } 

}
