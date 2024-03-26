using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float goldStart;
    private float gold;

    private void Start()
    {
        gold = goldStart;
    }
}
