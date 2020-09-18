using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulationSceneScript : MonoBehaviour
{
    private SimulationData simulationData;
    public GameObject plaque;
    public GameObject efield;
    // Start is called before the first frame update
    void Start()
    {
        simulationData = GameObject.Find("SimulationData").GetComponent<SimulationData>();
        plaque.gameObject.transform.localScale = new Vector3(simulationData.efield.large, 1, 1);
        efield.gameObject.transform.localScale = new Vector3(simulationData.efield.large, 1000, 1);
    }

    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
