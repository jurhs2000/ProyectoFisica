using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParticleSelectSceneScript : MonoBehaviour
{
    private SimulationData simulationData;
    public Toggle[] toggles;
    private Particle[] particles =
    {
        new Particle("Electrón", -1.602176565e-19f, 9.10938291e-31f),
        new Particle("Positrón", 1.602176487e-19f, 9.10938215e-31f),
        new Particle("Protón", 1.602176487e-19f, 1.672621898e-27f),
        new Particle("Núcleo de Antimateria de Cromo", -3.845223569e-18f, 8.63415478e-26f),
        new Particle("Neutrón", 0f, 1.67492729e-27f),
        new Particle("Partícula Alfa", 3.204352974e-19f, 6.695098376e-27f),
        new Particle("Núcleo de Deuterio", 1.602176487e-19f, 3.347549188e-27f),
        new Particle("Muón", -1.602176565e-19f, 1.885642262e-28f),
        new Particle("Núcleo de Oro", 1.265719425e-17f, 3.2707065562e-25f),
        new Particle("Núcleo de Antimateria de Litio", -4.806529461e-19f, 1.15258e-26f)
    };
    void Start()
    {
        simulationData = GameObject.Find("SimulationData").GetComponent<SimulationData>();
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(delegate
            {
                particleSelect(toggle);
            });
        }
    }
    public void next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void particleSelect(Toggle toggle)
    {
        if (toggle.isOn == true) // Se hace solo cuando pasa a checkeado
        {
            int select = 0;
            for (int i = 0; i < 10; i++)
            {
                if (toggle.name != toggles[i].name)
                {
                    toggles[i].isOn = false;
                } else
                {
                    select = i;
                }
            }
            simulationData.particle = particles[select];
        }
    }
}
