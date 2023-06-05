using UnityEngine;

public class MeshRendererSwitcher : MonoBehaviour
{
    public void DisableChildMeshRenderers(GameObject parent)
    {
        MeshRenderer[] childMeshRenderers = parent.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in childMeshRenderers)
        {
            meshRenderer.enabled = false;
        }
    }

    public void EnableChildMeshRenderers(GameObject parent)
    {
        MeshRenderer[] childMeshRenderers = parent.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in childMeshRenderers)
        {
            meshRenderer.enabled = true;
        }
    }
}

