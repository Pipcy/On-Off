using UnityEngine;

public class ShowMesh : MonoBehaviour
{
    public GameObject parent;
    public GameObject parent2;


    private void Update()
    {
        // Leave the update empty
    }

    public void ShowingMesh(GameObject obj)
    {
        // Enable MeshRenderer if the object has one
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = true;
        }

        // Recursively call ShowMesh on the children
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            GameObject child = obj.transform.GetChild(i).gameObject;
            ShowingMesh(child);
        }
    }

    public void HideMesh(GameObject obj)
    {
        // Disable MeshRenderer if the object has one
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }

        // Recursively call HideMesh on the children
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            GameObject child = obj.transform.GetChild(i).gameObject;
            HideMesh(child);
        }
    }
}
