using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    private int _missionNumber = 0;
    public List<Mission> missions = new List<Mission>();

    [SerializeField] private Transform npcSpawnPoint;

    private void Start()
    {
        StartCoroutine(InitializeMission());  
    }

    public void CompleteMission()
    {
        Mission activeMission = missions[_missionNumber];
        activeMission.isCompleted = true;
        _missionNumber++;
        Debug.Log(_missionNumber + " " + missions.Count );
        if (_missionNumber > missions.Count - 1)
        {
            return;
        }
        Debug.Log("initializing mission " + _missionNumber);
        StartCoroutine(InitializeMission());
    }

    public IEnumerator InitializeMission()
    {
        yield return new WaitForSeconds(3f);
        Mission currentActiveMission = missions[_missionNumber];
        while (currentActiveMission.isCompleted)
        {
            _missionNumber++;
            currentActiveMission = missions[_missionNumber];
        }
        GameObject npcGameObject = Instantiate(currentActiveMission.npcPrefab, npcSpawnPoint);
        NPCController controller = npcGameObject.GetComponent<NPCController>();
        controller.OnCompleteRequest += CompleteMission;
    }
}
