using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] // para que Unity pueda ver nuestras clases
public class Particle
{
    public Particle(string name, float charge, float mass) {
        this.name = name;
        this.charge = charge;
        this.mass = mass;
    }
    public string name;
    public float charge;
    public float mass;
    public float vi;
    public float vix;
    public float viy;
    public float vy;
    public float angle;
    public float x;
    public float y;
    public float xmax;
    public float ymax;
    public float acceleration;
}
