using UnityEngine;

public abstract class BaseEffectChangeMove
{

    protected int procent;
    protected GameObject target;
    protected BaseDrill drill;

    virtual protected void TryGetDrill()
    {
        if (target.TryGetComponent(out BaseDrill drill))
        {
            this.drill = drill;
        }
        else
        {
            throw new System.Exception("Drill is not found in class " + this.GetType());
        }
    }

    virtual protected bool IsEmpyDrill()
    {
        if (drill != null)
        {
            return false;
        }
        else
        {
            throw new System.Exception("Drill is not found in class " + this.GetType());
        }
    }

}
