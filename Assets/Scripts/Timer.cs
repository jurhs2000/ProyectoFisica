using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text despliegue;
    public int minutos;
    public int segundos;
    float acumulador;
    // Start is called before the first frame update
    void Start()
    {
        despliegue = GetComponent<Text>();
        acumulador = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        //despliegue.text = minutos+":"+segundos;

        acumulador = acumulador + Time.deltaTime;
        if (acumulador > 1)
        {
            if (segundos == 59)
            {
                segundos = 0;
                minutos = minutos + 1;
            }
            else
            {
                segundos = segundos + 1;
            }
            acumulador = 0;
        }
 

        //Formatos de despliegue
        if (minutos < 10 && segundos < 10)
        {
            despliegue.text = "0" + minutos + ":" + "0" + segundos;
        }
        else if (minutos < 10)
        {
            despliegue.text = "0" + minutos + ":" + segundos;
        }
        else if (segundos < 10)
        {
            despliegue.text = minutos + ":" + "0" + segundos;
        }
    }

    public int getMinutos()
    {
        return minutos;
    }

    public int getSegundos()
    {
        return segundos;
    }
}