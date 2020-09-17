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
    public bool direction; //false = hacia arriba y true = hacia abajo
    public Toggle[] toggles;
    void Start()
    {
        simulationData = GameObject.Find("SimulationData").GetComponent<SimulationData>();
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(delegate
            {
                directionSelect(toggle);
            });
        }
    }
    public void next()
    {
        simulationData.particle.vi = float.Parse(veli.text);
        simulationData.particle.angle = float.Parse(angle.text);
        simulationData.efield.intensity = float.Parse(efieldi.text);
        simulationData.efield.direction = direction;
        simulationData.efield.large = float.Parse(large.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void directionSelect(Toggle toggle)
    {
        if (toggle.isOn == true) // Se hace solo cuando pasa a checkeado
        {
            if (toggle.name == toggles[0].name)
            {
                direction = false;
                toggles[1].isOn = false;
            } else
            {

                direction = true;
                toggles[0].isOn = false;
            }
        }
    }
}
