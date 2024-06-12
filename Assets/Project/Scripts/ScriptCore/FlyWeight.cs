using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RiflePointNClick;
using static Patoscript;
[CreateAssetMenu(menuName = "ScriptableObjects/Rifle")]


public class FlyWeight : ScriptableObject
{
    public float velocidadbala;
    public int balasRestantes;
    public float tiempoRecarga;
    public float delay;

    public float Speed;
    public float RotationSpeed;
}
