using System.Collections;
using UnityEngine;

public class BoostMoveOnTime : BaseEffectChangeMove, IEffect
{

    private float seconds;

    public bool IsLife { get; private set; }

    public BoostMoveOnTime(int procentOfBoost, float seconds)
    {
        this.procent = procentOfBoost;
        this.seconds = seconds;
        IsLife = true;
    }

    public void MakeEffect(GameObject target)
    {
        this.target = target;
        this.TryGetDrill();
        this.drill.UpSpeedMove(this.procent);        
        this.drill.StartCoroutine(TimeLife());
    }

    public void DisableEffect()
    {
        if (!this.IsEmpyDrill())
        {
            this.drill.DownSpeedMove(this.procent);
        }
    }

    IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(seconds);
        IsLife = false;
    }

}
