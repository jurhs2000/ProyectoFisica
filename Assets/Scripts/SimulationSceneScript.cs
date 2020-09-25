using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimulationSceneScript : MonoBehaviour
{
    private SimulationData simulationData;
    public GameObject plaque;
    public GameObject efield;
    public Image playpause;
    public Sprite playSprite;
    public Sprite pauseSprite;
    public bool isPlay = false;
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

    public void resetlvl()
    {
        SceneManager.LoadScene("Simulation");
    }

    public void changePlayPause()
    {
        if (isPlay)
        {
            playpause.sprite = playSprite;
            isPlay = false;
        } else
        {
            playpause.sprite = pauseSprite;
            isPlay = true;
        }
    }
}
