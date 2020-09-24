using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ParamsSelectSceneScript : MonoBehaviour
{
    private SimulationData simulationData;
    public TMP_InputField veli;
    public TMP_InputField angle;
    public TMP_InputField efieldi;
    public TMP_InputField large;
    void Start()
    {
        simulationData = GameObject.Find("SimulationData").GetComponent<SimulationData>();
    }
    public void next()
    {
        simulationData.particle.vi = float.Parse(veli.text);
        simulationData.particle.angle = float.Parse(angle.text);
        simulationData.efield.intensity = float.Parse(efieldi.text);
        simulationData.efield.large = float.Parse(large.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
