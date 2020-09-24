using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;
    
    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("KLIK AKANA");
            Cast();
        }
       
    }

    public void Cast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
            else
            {
                //Debug.Log("Tidak ada colider");
            }
    }
}