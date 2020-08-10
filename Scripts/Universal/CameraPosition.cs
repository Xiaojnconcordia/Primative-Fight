using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField]
    Transform target;
    public float smoothSpeed = 0.125f;// the higher, the faster the camera will lock on the target
    public Vector3 offset;

    public float shakeAmplitude = 0.2f;
    public float shakeDuration = 0.1f;
    public float smooth = 0.1f;

    private Vector3 startPos;
    private float resetDurationTimer;
    public bool shouldShake;


    // Start is called before the first frame update
    void Start()
    {
        resetDurationTimer = shakeDuration;
    }


    void LateUpdate() // if use Update(), the camera and the target will be competing to go first. 
    {
        FollowOrShakeCam();
    }


    void FollowOrShakeCam()
    {
        if (shouldShake)
        {            
            if (shakeDuration > 0)
            {
                transform.localPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, offset.z)
                    + Random.insideUnitSphere * shakeAmplitude;
                shakeDuration -= Time.deltaTime * smooth;
            }
            else
            {
                shouldShake = false;
                shakeDuration = resetDurationTimer;
                transform.localPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, offset.z); ;
            }
        }

        // follow the player only
        else
        {
            transform.localPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, offset.z);
        }
    }

    public void SetShouldShake(bool b)
    {
        shouldShake = b;
    }
}
