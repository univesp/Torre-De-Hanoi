using UnityEngine;

//Esse script vai em todas as camadas do bolo
public class CakeLayer : MonoBehaviour
{
    public MeshFilter cakeMesh;
    public Collider cakeCollider;
    public Vector3 cakeSize;
    public Vector3 currentPosition;
    public Tower currentTower;

    [HideInInspector] public bool isSelected; //Essa variável fica verdadeira no script DragAndDrop
    private bool isIn;
    [SerializeField] private Tower nextTower;

    [SerializeField] private Renderer materialRenderer;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color hoverColor;

    //Calcula o tamanho real do objeto
    private void Awake()
    {
        cakeSize = new Vector3 (cakeMesh.mesh.bounds.size.x * transform.localScale.x, cakeMesh.mesh.bounds.size.z * transform.localScale.z, cakeMesh.mesh.bounds.size.y * transform.localScale.y);
        gameObject.SetActive(false);
    }

    public void UpdatePosition()
    {
        if (isIn)
        {
            nextTower.AddChild(this);
        }
        else
        {
            transform.position = currentPosition;
        }
        nextTower.plateRenderer.material.color = normalColor;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tower"))
        {
            isIn = true;
            nextTower = other.GetComponent<Tower>();

            if(isSelected)
            {
                nextTower.plateRenderer.material.color = hoverColor;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Tower"))
        {
            isIn = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Tower"))
        {
            isIn = false;
            other.GetComponent<Tower>().plateRenderer.material.color = normalColor;
        }
    }

    private void OnMouseEnter()
    {
        materialRenderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        materialRenderer.material.color = normalColor;
    }
}
