using System.Collections;
using UnityEngine;

public class ChangeSizeEffect : IEffect
{
    private GameObject target;

    private Vector3 scale;

    private Vector3 scalerOld;

    private BaseDrill drill;

    private TrailRenderer trailDrill;

    private Coroutine timeLife;

    private float seconds;

    private float trailOld;

    public bool IsLife { get; private set; }

    public ChangeSizeEffect(Vector3 scale, float seconds)
    {
        this.scale = scale;
        this.seconds = seconds;
        IsLife = true;
    }

    public void MakeEffect(GameObject target)
    {
        this.target = target;

        if (target.TryGetComponent(out BaseDrill drill))
        {
            this.drill = drill;
            this.trailDrill = this.drill.gameObject.GetComponent<TrailRenderer>();

            scalerOld = this.drill.transform.localScale;

            this.drill.transform.localScale = this.scale;
            //trailOld = trailDrill.startWidth;
            //trailDrill.startWidth = 0.47f;

            this.timeLife = drill.StartCoroutine(TimeLife());
        }
        else
        {
            throw new System.Exception("Drill not found in class " + this.GetType());
        }
        
    }

    public void DisableEffect()
    {
        drill.transform.localScale = scalerOld;
        //trailDrill.startWidth = trailOld;
        drill.StopCoroutine(this.timeLife);
    }

    private IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(this.seconds);
        IsLife = false;
    }

}
