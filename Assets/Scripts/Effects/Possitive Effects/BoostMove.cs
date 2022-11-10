using UnityEngine;

public class BoostMove : BaseEffectChangeMove, IEffect
{
    
    public bool IsLife { get; private set; }

    public BoostMove(int procentOfBoost)
    {
        this.procent = procentOfBoost;
        IsLife = true;
    }

    public void MakeEffect(GameObject target)
    {
        this.target = target;
        this.TryGetDrill();
        this.drill.UpSpeedMove(this.procent);
    }

    public void DisableEffect()
    {
        if (!this.IsEmpyDrill())
        {
            this.drill.DownSpeedMove(this.procent);
        }
    }

}
