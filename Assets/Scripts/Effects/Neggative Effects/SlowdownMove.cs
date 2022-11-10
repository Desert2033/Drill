using UnityEngine;

public class SlowdownMove : BaseEffectChangeMove, IEffect
{

    public bool IsLife { get; private set; }

    public SlowdownMove(int procentOfSlow)
    {
        this.procent = procentOfSlow;
        IsLife = true;
    }

    public void MakeEffect(GameObject target)
    {
        this.target = target;
        this.TryGetDrill();
        this.drill.DownSpeedMove(this.procent);
    }

    public void DisableEffect()
    {
        if (!this.IsEmpyDrill())
        {
            this.drill.UpSpeedMove(this.procent);
        }
    }

}
