using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmplitude = 0.2f;
    public float shakeDuration = 0.2f;
    public float smooth = 0.1f;

    private Vector3 startPos;
    private float resetDurationTimer;
    private bool shouldShake;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        resetDurationTimer = shakeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        ShakeCam();
    }


    void ShakeCam()
    {
        if (shouldShake)
        {
            if (shakeDuration > 0)
            {
                transform.localPosition = startPos + Random.insideUnitSphere * shakeAmplitude;
                shakeDuration -= Time.deltaTime * smooth;
            }
            else
            {
                shouldShake = false;
                shakeDuration = resetDurationTimer;
                transform.localPosition = startPos;
            }
        }
    }

    public void SetShouldShake(bool b)
    {
        shouldShake = b;
    }
}
