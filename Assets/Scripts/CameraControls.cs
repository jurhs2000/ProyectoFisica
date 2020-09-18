using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControls : MonoBehaviour
{
    public Toggle toggle;
    public GameObject particle;
    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn) // Sigue a la particula
        {
            gameObject.transform.position = new Vector3(particle.transform.position.x, particle.transform.position.y, particle.transform.position.z - 20);
            gameObject.GetComponent<Camera>().orthographicSize = 20;
        } else // Control con teclas
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);

            if (Input.GetKey(KeyCode.RightArrow))
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);

            if (Input.GetKey(KeyCode.UpArrow))
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);

            if (Input.GetKey(KeyCode.DownArrow))
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1, gameObject.transform.position.z);

            if (Input.GetKey(KeyCode.W))
                gameObject.GetComponent<Camera>().orthographicSize = gameObject.GetComponent<Camera>().orthographicSize - 1;

            if (Input.GetKey(KeyCode.S))
                gameObject.GetComponent<Camera>().orthographicSize = gameObject.GetComponent<Camera>().orthographicSize + 1;
        }
    }
}
