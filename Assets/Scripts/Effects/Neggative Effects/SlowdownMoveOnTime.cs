using System.Collections;
using UnityEngine;

public class SlowdownMoveOnTime : BaseEffectChangeMove, IEffect
{

    private float seconds;

    public bool IsLife { get; private set; }

    public SlowdownMoveOnTime(int procentOfSlow, float seconds)
    {
        this.procent = procentOfSlow;
        this.seconds = seconds;
        IsLife = true;
    }

    public void MakeEffect(GameObject target)
    {
        this.target = target;
        this.TryGetDrill();
        this.drill.DownSpeedMove(this.procent);        
        this.drill.StartCoroutine(TimeLife());
    }

    public void DisableEffect()
    {
        if (!this.IsEmpyDrill())
        {
            this.drill.UpSpeedMove(this.procent);
        }
    }

    IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(seconds);
        IsLife = false;
    }

}
