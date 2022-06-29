using GameManager;
using UnityEngine;
using UnityEditor.Callbacks;
using UnityEditor;
using UnityEditor.MPE;

public class RoomNodeGraphEditor : EditorWindow
{
    private GUIStyle _roomNodeStyle;
    private static RoomNodeGraphSO _currentRoomNodeGraph;
    private RoomNodeTypeListSO _roomNodeTypeListSo;

    // Node layout values
    private const float nodeWidth = 160f;
    private const float nodeHeight = 75f;
    private const int nodePadding = 25;
    private const int nodeBorder = 12; 

    [MenuItem("Room Node Graph Editor", menuItem = "Window/Dungeon Editor / Room Node Graph Editor")]
    private static void OpenWindow()
    {
        GetWindow<RoomNodeGraphEditor>();
    }
    

    private void OnEnable()
    {
        // Define node layout style
        _roomNodeStyle = new GUIStyle();
        _roomNodeStyle.normal.textColor = Color.white;
        _roomNodeStyle.normal.background = EditorGUIUtility.Load("node1") as Texture2D;
        _roomNodeStyle.padding = new RectOffset(nodePadding, nodePadding, nodePadding, nodePadding);
        _roomNodeStyle.border = new RectOffset(nodeBorder, nodeBorder, nodeBorder, nodeBorder);
        
        // Load the Room node types
        _roomNodeTypeListSo = GameResources.Instance.roomNodeTypeListSo;
    }

    /// <summary>
    /// Open the room node graph editor window if a room graph scriptable object asset i double clicked in the instpector
    /// </summary>
    /// <param name="instanceId"></param>
    /// <param name="line"></param>
    /// <returns>Returns true if this method handles what is being clicked in the editor. Else returns false.</returns>
    [OnOpenAsset(0)]
    public static bool OnDoubleClickAsset(int instanceId, int line)
    {
        RoomNodeGraphSO roomNodeGraphSo = EditorUtility.InstanceIDToObject(instanceId) as  RoomNodeGraphSO;

        if (roomNodeGraphSo != null)
        {
            OpenWindow();

            _currentRoomNodeGraph = roomNodeGraphSo;

            return true;
        }

        return false;
    }

    private void OnGUI()
    {
        // If a scriptable object of type RoomNodeGraphSO has been selected then process
        if (_currentRoomNodeGraph != null)
        {
            // Process events
            ProcessEvent(Event.current);
            
            // Draw Room Nodes
            DrawRoomNode();
        }
    }
}
