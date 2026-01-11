using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomState : MonoBehaviour
{
    public bool hasAnomaly;
    public string roomCode;
    public TextMeshPro codeDisplay;
    public int difficulty; // 0: Master, 1: Easy, 2: Medium, 3: Hard
}
