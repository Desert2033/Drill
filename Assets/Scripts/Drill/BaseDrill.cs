using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDrill : MonoBehaviour
{
    protected const float baseMoveSpeed = 1f;


    protected float angleMax = 90f;
    protected Vector3 currentAngle;

    protected float rotateSpeed = 20f;
    protected float currentBaseMoveSpeed = baseMoveSpeed;
    protected float moveSpeed = baseMoveSpeed;

    protected List<IEffect> terraineEffects = new List<IEffect>();
    protected List<IEffect> obstacleEffects = new List<IEffect>();
    protected List<IEffect> bonusEffects = new List<IEffect>();

    [SerializeField] protected PhotonView thisPhotoView;

    public BaseDrill()
    {
        moveSpeed = baseMoveSpeed;
    }

    virtual protected void Rotate()
    {
        if (Input.anyKey)
        {

            float localAngleMax = Mathf.Max(this.angleMax, 360 - this.angleMax);
            float localAngleMin = Mathf.Min(this.angleMax, 360 - this.angleMax);
            float localAngleForDirection = 0;
            float futureRotatePosition = 0;

            if (Input.GetKey(KeyCode.A))
            {
                localAngleForDirection = localAngleMin;
                currentAngle = Vector3.forward * rotateSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                localAngleForDirection = localAngleMax;
                currentAngle = Vector3.forward * -rotateSpeed * Time.deltaTime;
            }

            futureRotatePosition = transform.eulerAngles.z + currentAngle.z;

            if (futureRotatePosition < localAngleMax && futureRotatePosition > localAngleMin)
            {
                currentAngle.z = localAngleForDirection - futureRotatePosition;
            }


            transform.Rotate(currentAngle);
            currentAngle = Vector3.zero;
        }
    }

    virtual protected void Move()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
   
    virtual public void UpSpeedMove(int procent)
    {
        moveSpeed += currentBaseMoveSpeed * procent / 100;
    }

    virtual public void DownSpeedMove(int procent)
    {
        moveSpeed -= currentBaseMoveSpeed * procent / 100;
    }

    virtual public void UpBaseSpeedMove(int procent)
    {
        int procentMoveSpeedFromBaseMove = (int)(moveSpeed / currentBaseMoveSpeed * 100);
        currentBaseMoveSpeed = baseMoveSpeed + (baseMoveSpeed * procent / 100);
        moveSpeed = currentBaseMoveSpeed * procentMoveSpeedFromBaseMove / 100;
    }

    virtual public void DownBaseSpeedMove(int procent)
    {
        int procentMoveSpeedFromBaseMove = (int)(moveSpeed / currentBaseMoveSpeed * 100);
        currentBaseMoveSpeed = baseMoveSpeed - (baseMoveSpeed * procent / 100);
        moveSpeed = currentBaseMoveSpeed * procentMoveSpeedFromBaseMove / 100;
    }

}
