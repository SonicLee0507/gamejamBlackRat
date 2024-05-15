using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLauncher : MonoBehaviour
{
    [SerializeField] private Transform LaunchPoint;

    [SerializeField] private GameObject[] obj;

    [SerializeField] private float timeBtwSpawns;
    [SerializeField] private float startTimeBtwSpawns;
    [SerializeField] private float minTimeBtwSpawns;
    [SerializeField] private float decrease;
    // Update is called once per frame
    void Update()
    {
        SpawnedTime();
    }

    private void SpawnedTime()
    {
        if (timeBtwSpawns <= 0)
        {
            GameObject ranobj = obj[Random.Range(0, obj.Length)];
            Instantiate(ranobj, LaunchPoint.position, Quaternion.AngleAxis(0, -Vector3.forward));
            if (startTimeBtwSpawns > minTimeBtwSpawns)
            {
                startTimeBtwSpawns -= Random.Range(-0.5f,decrease);
            }
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
