using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private bool isInPointer;
    [SerializeField] private bool isDragging;

    [SerializeField] private Camera mainCamera;
    private Vector3 offsetValue;
    private Vector3 positionOfScreen;
    private Vector3 currentScreenSpace;
    private Vector3 currentPosition;

    [SerializeField] private CakeLayer cakeLayer;

    [SerializeField] private AudioClip overCake;
    [SerializeField] private AudioClip clickCake;
    [SerializeField] private AudioClip dropCake;
    private void Update()
    {
        if(isInPointer && Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioPlayer.instance.PlaySFX(clickCake);

            isDragging = true;

            cakeLayer.isSelected = true;

            //Convert world position to screen position
            positionOfScreen = mainCamera.WorldToScreenPoint(transform.position);
            offsetValue = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
        }

        if(isDragging)
        {
            //Tracks mouse position
            currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

            //Convert screen position to world position with offset changes
            currentPosition = mainCamera.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

            //Update object's position
            transform.position = new Vector3(currentPosition.x, currentPosition.y, -19.52f);
        }

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (isDragging)
            {
                AudioPlayer.instance.PlaySFX(dropCake);
                isDragging = false;
            }
            if (cakeLayer.isSelected)
            {
                cakeLayer.UpdatePosition();
                cakeLayer.isSelected = false;
            }
        }
    }

    private void OnMouseEnter()
    {
        isInPointer = true;
        if (!isDragging)
        {
            AudioPlayer.instance.PlaySFX(overCake);
        }
    }

    private void OnMouseExit()
    {
        isInPointer = false;
    }
}