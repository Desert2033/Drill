using UnityEngine;

public class SlowdownBaseMove : BaseEffectChangeMove, IEffect
{
    public bool IsLife { get; private set; }

    public SlowdownBaseMove(int procentOfSlow)
    {
        this.procent = procentOfSlow;
        IsLife = true;
    }

    public void MakeEffect(GameObject target)
    {
        this.target = target;
        this.TryGetDrill();
        this.drill.DownBaseSpeedMove(this.procent);
    }

    public void DisableEffect()
    {
        if (!this.IsEmpyDrill())
        {
            this.drill.UpBaseSpeedMove(this.procent);
        }
    }

}
