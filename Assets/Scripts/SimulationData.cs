using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationData : MonoBehaviour
{

    public Particle particle;
    public Efield efield;
    public static SimulationData instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
