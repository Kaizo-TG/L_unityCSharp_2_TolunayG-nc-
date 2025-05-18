using UnityEngine;

public class RaycastInteractor : MonoBehaviour
{
    [SerializeField]
    private float maxRayDistance = 100f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Keine Hauptkamera gefunden!");
        }
    }

    private void Update()
    {
        HandleMouseClick();
    }

  
    private void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * maxRayDistance, Color.green, 2f);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, maxRayDistance))
            {
                InteractWithObject(hitInfo.collider.gameObject);
            }
        }
    }

//obekt Interaktion?
    private void InteractWithObject(GameObject obj)
    {
        ChangeObjectColor(obj);
        LogObjectInfo(obj);
    }

  //random Farbe

   
    private void ChangeObjectColor(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Random.ColorHSV();
        }
        else
        {
            Debug.LogWarning($"Objekt {obj.name} hat keinen Renderer.");
        }
    }

  
    ///Print Name und Position des Objekts 
    
    private void LogObjectInfo(GameObject obj)
    {
        Vector3 pos = obj.transform.position;
        Debug.Log($"Interagiert mit Objekt: \"{obj.name}\" an Position: {pos}");
    }
}
