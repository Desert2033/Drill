using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObstacles : MonoBehaviour
{

    protected List<IEffect> effects;

    void Start()
    {
        effects = new List<IEffect>();
    }


}
