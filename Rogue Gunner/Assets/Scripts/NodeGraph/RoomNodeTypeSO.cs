using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomNodeType", menuName = "Scriptable Object/Dungeon/Room Node Type")]
public class RoomNodeTypeSO : ScriptableObject
{
    public string roomNodeTypeName;
    [Header("Only flaghe RoomNodeTypes that should be visible in the editor.")]
    public bool displayInNodeGraphEditor = true;
    [Header("One type should be a Corridor")]
    public bool isCorridor;
    [Header("One type should be a CorridorNS")]
    public bool isCorridorNS;
    [Header("One type should be a CorridorEW")]
    public bool isCorridorEW;
    [Header("One type should be an Entrance")]
    public bool isEntrance;
    [Header("One type should be a Boss Room")]
    public bool isBossRoom;
    [Header("One type should be None (Unassigned)")]
    public bool isNone;

    #region Validation
#if UNITY_EDITOR
    // https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnValidate.html
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(roomNodeTypeName), roomNodeTypeName);
    }
#endif
#endregion
}
