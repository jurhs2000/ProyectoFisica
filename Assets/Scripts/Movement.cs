using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private SimulationData simulationData;
    public Particle particle;
    // Start is called before the first frame update
    void Start()
    {
        simulationData = GameObject.Find("SimulationData").GetComponent<SimulationData>();
        particle = simulationData.particle;
    }

    // Update is called once per frame
    void Update()
    {
        particle = simulationData.particle;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "EField")
        {
            // Añadir fuerza de campo electrico
        }
    }
}
