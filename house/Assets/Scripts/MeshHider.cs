using UnityEngine;

public class MeshHider : MonoBehaviour
{
    public ShowMesh showMeshScript;

    public CameraTrigger CamTriggerScript;

    

    public bool inBath;

    private void Start()
    {
        // Call ShowMesh to enable all the MeshRenderers in the parent object and its children
        showMeshScript.ShowingMesh(showMeshScript.parent);

        // Call HideMesh to disable all the MeshRenderers in the parent object and its children
        showMeshScript.HideMesh(showMeshScript.parent2);
    }

    private void Update()
    {
        inBath = CamTriggerScript.inBathroom;
        if (inBath)
        {
            showMeshScript.ShowingMesh(showMeshScript.parent2);
            showMeshScript.HideMesh(showMeshScript.parent);
        }
        else //in living room
        {
            showMeshScript.ShowingMesh(showMeshScript.parent);
            showMeshScript.HideMesh(showMeshScript.parent2);
        }
    }


}
