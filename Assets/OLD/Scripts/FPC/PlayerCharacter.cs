using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    void Start()
    {
        health = 5;
    }

    public void Hurt(int _damage)
    {
        health -= _damage;
        print($"Health: {health}");
    }
}
