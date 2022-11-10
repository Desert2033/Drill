using UnityEngine;

public class NormalDrill : BaseDrill
{

    private void OnTriggerEnter(Collider other)
    {
        BonusEffects bonusEffects = other.gameObject.GetComponent<BonusEffects>();

        if (bonusEffects != null)
        {
            
        }
    }

    void Update()
    {
        if (!thisPhotoView.IsMine) 
        {
            return;
        }

        Move();
        Rotate();
        //Debug.Log(moveSpeed);
    }

}
