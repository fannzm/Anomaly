using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [Header("Base Probabilities")]
    public float probabilityNone = 15.01f;
    public float probabilityEasy = 28.33f;
    public float probabilityMedium = 28.33f;
    public float probabilityHard = 28.33f;

    public float reductionFactor = 0.1f;

    [Header("References")]
    public GameObject player;
    public CharacterController controller;
    public TabletUI tabletUI;
    public GameManager gameManager;

    [Header("Room Pool")]
    public List<RoomState> allSourceRooms; 
    [HideInInspector] private List<RoomState> runtimePool;

    private RoomState chosenRoom;
    private GameObject currentRoomInstance;
    private float w0, w1, w2, w3;

    public CutSceneLogic cutscenlogic;

    void Awake()
    {
        ResetFullPool();
        ResetProbabilities();
    }

    void Start()
    {
        SpawnMasterRoom();
    }
    
    // Refill Pool
    public void ResetFullPool()
    {
        runtimePool = new List<RoomState>(allSourceRooms);
        Debug.Log("Room pool reset. Total rooms: " + runtimePool.Count);
    }

    public void ResetProbabilities()
    {
        w0 = probabilityNone;
        w1 = probabilityEasy;
        w2 = probabilityMedium;
        w3 = probabilityHard;
    }
     // Spawn Master Room
    public void SpawnMasterRoom()
    {
       

        RoomState masterRoom = allSourceRooms.Find(r => r.difficulty == 0);
        if (masterRoom != null)
        {
            chosenRoom = masterRoom; 
            UpdateWeights(0); 
            ExecuteTeleport(chosenRoom);
            Debug.Log("Spawn: " + chosenRoom.name);
        }
    }

     // Main Spawning Logic
    public void SpawnNext()
    {
       

        int nextDiff = GetNextDifficulty();
        List<RoomState> candidates = runtimePool.FindAll(r => r.difficulty == nextDiff);

        // Use any available anomaly if roll is empty
        if (candidates.Count == 0 && nextDiff > 0)
            candidates = runtimePool.FindAll(r => r.difficulty > 0);

        // Use Master Room
        if (candidates.Count == 0)
            candidates = allSourceRooms.FindAll(r => r.difficulty == 0);

        if (candidates.Count > 0)
        {
            chosenRoom = candidates[Random.Range(0, candidates.Count)];
            Debug.Log("Spawned Room: " + chosenRoom.name + " (Difficulty: " + chosenRoom.difficulty + ")");
            ExecuteTeleport(chosenRoom);
        }
    }

    // Remove Current Room From Pool
    public void RemoveCurrentRoom()
    {
        if (chosenRoom != null && chosenRoom.difficulty > 0)
        {
            runtimePool.Remove(chosenRoom);
            Debug.Log("Removed Room: " + chosenRoom.name + ". Remaining in pool: " + runtimePool.Count);
        }
    }

    // Calculate Next Diffculty via Ticket System
    private int GetNextDifficulty()
    {
        float totalWeight = w0 + w1 + w2 + w3;
        float randomValue = Random.Range(0, totalWeight);

        int selected; 
        if (randomValue < w0) selected = 0;
        else if (randomValue < w0 + w1) selected = 1;
        else if (randomValue < w0 + w1 + w2) selected = 2;
        else selected = 3;

        UpdateWeights(selected);
        return selected;
    }

    // Update Weights after Selection
    private void UpdateWeights(int selected)
    {
        float reduction = 0f;

        if (selected == 0)
        {
            reduction = w0 - (w0 * reductionFactor);
            w0 *= reductionFactor;
            float comp = reduction / 3f;
            w1 += comp; w2 += comp; w3 += comp;
        }
        else
        {
            w0 = probabilityNone; // Cap Master Room at 15%
            
            if (selected == 1) {
                reduction = probabilityEasy - (probabilityEasy * reductionFactor);
                w1 = probabilityEasy * reductionFactor;
                w2 = probabilityMedium + (reduction / 2f);
                w3 = probabilityHard + (reduction / 2f);
            }
            else if (selected == 2) {
                reduction = probabilityMedium - (probabilityMedium * reductionFactor);
                w2 = probabilityMedium * reductionFactor;
                w1 = probabilityEasy + (reduction / 2f);
                w3 = probabilityHard + (reduction / 2f);
            }
            else if (selected == 3) {
                reduction = probabilityHard - (probabilityHard * reductionFactor);
                w3 = probabilityHard * reductionFactor;
                w1 = probabilityEasy + (reduction / 2f);
                w2 = probabilityMedium + (reduction / 2f);
            }
        }

        
        float total = w0 + w1 + w2 + w3;
        Debug.Log("Current Chances - Master: " + (w0/total*100).ToString("F0") + "% | Easy: " + (w1/total*100).ToString("F0") + "% | Medium: " + (w2/total*100).ToString("F0") + "% | Hard: " + (w3/total*100).ToString("F0") + "%");
    }

    // Handle Teleportation
    private void ExecuteTeleport(RoomState targetRoom)
    {   
        controller.enabled = false;
        
        if (currentRoomInstance != null)
        {
            Destroy(currentRoomInstance);
        }
        
        currentRoomInstance = Instantiate(targetRoom.gameObject);
        RoomState spawnedRoomState = currentRoomInstance.GetComponent<RoomState>();

        Transform spawn = currentRoomInstance.transform.Find("SpawnPoint");
        if (spawn != null) {
            player.transform.position = spawn.position;
            player.transform.rotation = spawn.rotation;
        }

        if (spawnedRoomState.isTabletAnomalyRoom && spawnedRoomState.hasAnomaly)
        {
            tabletUI.UpdateUserDisplay(true);
        }
        else
        {
            tabletUI.UpdateUserDisplay(false);
        }
       
        MovementPlayer movementPlayer = player.GetComponent<MovementPlayer>();
        bool shouldInvert = spawnedRoomState.isInvertedRoom && spawnedRoomState.hasAnomaly;

        if(movementPlayer != null)
        {
            
            movementPlayer.SetInversion(shouldInvert);
        }

        MouseLook lookScript = player.GetComponentInChildren<MouseLook>(); 
        if (lookScript != null)
        {
            lookScript.SetMouseInversion(shouldInvert);
        }
        
        tabletUI.currentRoom = spawnedRoomState;
        gameManager.GenerateNewCode(spawnedRoomState);
        Physics.SyncTransforms();
        controller.enabled = true;
    }
}