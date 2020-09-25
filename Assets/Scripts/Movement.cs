using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private SimulationData simulationData;
    private SimulationSceneScript simulationScene;
    private Timer timer;
    public Text posXtxt;
    public Text posYtxt;
    public Text acceltxt;
    public Text vitxt;
    public Text vixtxt;
    public Text viytxt;
    public Text vytxt;
    public Text angletxt;
    public Text nametxt;
    public Text chargetxt;
    public Text masstxt;
    public Text efieldtxt;
    public Text xmaxtxt;
    public Text ymaxtxt;
    public Text largePlaquetxt;
    public Particle particle;
    private int accMultiplier = 1;
    private float timeStop;
    public GameObject wall;
    Vector2 lastWall;
    Collider2D nextWall;
    public Toggle toggle;
    private float yStop;

    // Start is called before the first frame update
    void Start()
    {
        simulationData = GameObject.Find("SimulationData").GetComponent<SimulationData>();
        simulationScene = GameObject.Find("SceneController").GetComponent<SimulationSceneScript>();
        timer = GameObject.Find("Time").GetComponent<Timer>();
        particle = simulationData.particle;
        particle.vix = Mathf.Cos((float)(Math.PI / 180 * particle.angle)) * particle.vi;
        particle.viy = Mathf.Sin((float)(Math.PI / 180 * particle.angle)) * particle.vi;
        nametxt.text = "Particle: " + particle.name;
        chargetxt.text = "Charge: " + particle.charge + " C";
        masstxt.text = "Mass: " + particle.mass + " Kg";
        vitxt.text = "Vi: " + particle.vi + " m/s";
        angletxt.text = "Angle: " + particle.angle + "º";
        vixtxt.text = "Vi X: " + particle.vix + " m/s";
        viytxt.text = "Vi Y: " + particle.viy + "m/s";
        efieldtxt.text = "E Field: " + simulationData.efield.intensity + " N/C";
        largePlaquetxt.text = "Large Plaque: " + simulationData.efield.large + " m";
    }

    // Update is called once per frame
    void Update()
    {
        if (simulationScene.isPlay)
        {
            // Calculando aceleración
            particle.acceleration = accMultiplier * (simulationData.efield.intensity * particle.charge) / particle.mass;
            // Posiciones de la particula
            particle.y = (float)((particle.viy * timer.t) + ((particle.acceleration * Math.Pow(timer.t, 2)) / 2));
            particle.x = particle.vix * timer.t;
            // Otros parametros de la particula
            if (particle.y < 0)
            {
                // Cuando la partícula sale por debajo de la placa
                accMultiplier = 0;
                particle.viy = particle.vy;
                particle.y = particle.y - (particle.viy * timeStop); // Al nuevo movimiento se le resta Y inicial
            }
            else
            {
                if (particle.x > simulationData.efield.large)
                {
                    // Cuando la partícula supera el largo de la placa y Y > 0
                    accMultiplier = 0;
                    particle.viy = particle.vy;
                    particle.y = yStop + (particle.viy * (timer.t - timeStop));
                } else
                {
                    // Mientras este en el campo electrico calcula la velocidad en y normal
                    particle.vy = particle.viy + (particle.acceleration * timer.t);
                    timeStop = timer.t;
                    yStop = particle.y;
                    // Cuando salga dejara de calcularla y quedará con aceleración 0
                }
            }
            angletxt.text = "Angle: " + (Math.Atan((particle.vy/particle.vix)) * (180 / Math.PI)).ToString("f2") + "º";
            // Estableciendo posicion del objeto en Unity
            gameObject.transform.position = new Vector3(particle.x, particle.y, 0);
            posXtxt.text = "Pos X: " + particle.x.ToString() + " m";
            posYtxt.text = "Pos Y: " + particle.y.ToString() + " m";
            vytxt.text = "Vel Y: " + particle.vy + " m/s";
            acceltxt.text = "Accel: " + particle.acceleration + " m/(s^2)";

            if (toggle.isOn) //deja rastro la particula
            {
                spawnWall();
            }
            
        }
    }

    void spawnWall()
    {
        lastWall = transform.position;
        GameObject l = (GameObject)Instantiate(wall, transform.position, Quaternion.identity);
        nextWall = l.GetComponent<Collider2D>();
    }
}
