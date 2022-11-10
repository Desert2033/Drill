using UnityEngine;

public class BoostBaseMove : BaseEffectChangeMove, IEffect
{
    
    public bool IsLife { get; private set; }

    public BoostBaseMove(int procentOfBoost)
    {
        this.procent = procentOfBoost;
        IsLife = true;
    }

    public void MakeEffect(GameObject target)
    {
        this.target = target;
        this.TryGetDrill();
        this.drill.UpBaseSpeedMove(this.procent);
    }

    public void DisableEffect()
    {
        if (!this.IsEmpyDrill())
        {
            this.drill.DownBaseSpeedMove(this.procent);
        }
    }

}
