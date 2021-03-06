﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailFlameSpeed : MonoBehaviour
{
    ParticleSystem.MainModule targetPS;

    // Start is called before the first frame update
    void Start()
    {
        targetPS = GetComponent<ParticleSystem>().main;

    }

    // Update is called once per frame
    void Update()
    {
        targetPS.startSpeed = ShipController._moveFB > 50 ? ShipController._moveFB / 5 : 10;
        targetPS.startSize = ShipController._moveFB > 60 ? ShipController._moveFB / 40 : 1.2f;
        targetPS.maxParticles = ShipController._moveFB != 0 ? Mathf.RoundToInt(ShipController._moveFB * 100) : 1000;
    }
}
