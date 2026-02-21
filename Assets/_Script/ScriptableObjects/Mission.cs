using UnityEngine;

[CreateAssetMenu(fileName = "Mission", menuName = "Scriptable Objects/Mission")]
public class Mission : ScriptableObject
{

    public int missionNumber;
    public string missionName;
    public bool isCompleted = false;
    public GameObject npcPrefab;

}
