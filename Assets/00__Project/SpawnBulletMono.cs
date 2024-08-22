using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletMono : MonoBehaviour
{
    public GameObject m_objectToSpawn;
    public float m_timeToSpawn = 5;
    void Start()
    {
      

        InvokeRepeating("SpawnNewSpaceShip",0, m_timeToSpawn);
            
    }
    public void SpawnNewSpaceShip() {
        GameObject.Instantiate(m_objectToSpawn);
    }

}
