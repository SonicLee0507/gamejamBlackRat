using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    private CameraControl instance;
    public CameraControl Instance => instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    private void update()
    {

        PlayerShakeAnimation();
    }
    public CinemachineImpulseSource impulseSource;
    // Update is called once per frame
 
    public void PlayerShakeAnimation()
    {
        impulseSource.GenerateImpulse();
    }
}
