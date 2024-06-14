using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject fallDownCubePrefab;

    [SerializeField]
    GameObject rollerPrefab;

    [SerializeField]
    GameObject point;

    private float timeToSpawnFallDownCube = 2.0f;
    private float timeToDestroyFallDownCube = 2.0f;
    private float timeToSpawnRoller = 5.0f;
    private float timeToDestroyRoller = 7.0f;

    // Start is called before the first frame update
    private void Start()
    {
        SpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        // spawn fall down cube
        timeToSpawnFallDownCube -= Time.deltaTime;
        if (timeToSpawnFallDownCube < 0.0f)
        {
            Instantiate(fallDownCubePrefab, new Vector3(Random.Range(-4.40f, 4.50f),
                8.40f, Random.Range(-4.60f, 4.60f)), Quaternion.identity);
            timeToSpawnFallDownCube = 2.0f;
        }
        
        // destroy fall down cube
        GameObject needToDestroyCube = GameObject.FindWithTag("FallDownCube");
        if (needToDestroyCube != null)
        {
            timeToDestroyFallDownCube -= Time.deltaTime;
            if (timeToDestroyFallDownCube < 0.0f)
            {
                Destroy(needToDestroyCube);
                timeToDestroyFallDownCube = 2.0f;
            }
        }
        
        // spawn roller
        timeToSpawnRoller -= Time.deltaTime;
        if (timeToSpawnRoller < 0.0f)
        {
            // choose which ramp to spawn roller
            int decidedSide = Random.Range(0, 2);
            if (decidedSide == 0)
            {
                Instantiate(rollerPrefab, new Vector3(Random.Range(-22.82f, -11.11f), 
                    13f, Random.Range(-8.70f, 9.00f)), Quaternion.identity);
                timeToSpawnRoller = 5.0f;
            }
            else
            {
                Instantiate(rollerPrefab, new Vector3(Random.Range(11.11f, 22.82f),
                    13f, Random.Range(-8.70f, 9.00f)), Quaternion.identity);
                timeToSpawnRoller = 5.0f;
            }
        }

        // destroy roller
        GameObject needToDestroyRoller = GameObject.FindWithTag("Roller");
        if (needToDestroyRoller != null)
        {
            timeToDestroyRoller -= Time.deltaTime;
            if (timeToDestroyRoller < 0.0f)
            {
                Destroy(needToDestroyRoller);
                timeToDestroyRoller = 7.0f;
            }
        }

        // spawn point
        GameObject existedPoint = GameObject.FindWithTag("Point");
        if (existedPoint == null)
        {
            SpawnPoint();
        }
    }

    // check if any objects that already existed in the position that we want to spawn point 
    private bool CheckPointSpawnPosition(Vector3 position)
    {
        Collider[] checkInsideColliderMap = Physics.OverlapSphere(position, 0.0f);
        if (checkInsideColliderMap.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Create a position to spawn point
    private Vector3 PointSpawnPosition()
    {
        Vector3 pointPosition = new Vector3(Random.Range(-4.40f, 4.50f),
                0.4f, Random.Range(-4.60f, 4.60f));

        return pointPosition;
    }

    // Spawn point
    private void SpawnPoint()
    {
        Vector3 pointPosition = PointSpawnPosition();
        while (CheckPointSpawnPosition(pointPosition))
        {
            pointPosition = PointSpawnPosition();
        }
        Instantiate(point, pointPosition, Quaternion.identity);
    }
}
