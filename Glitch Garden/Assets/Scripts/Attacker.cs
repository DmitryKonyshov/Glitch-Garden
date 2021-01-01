﻿using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)][SerializeField] float walkSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    }
}
