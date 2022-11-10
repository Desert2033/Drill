using UnityEngine;

public interface IEffect
{
    public bool IsLife { get; }

    public void MakeEffect(GameObject target);

    public void DisableEffect();

}
