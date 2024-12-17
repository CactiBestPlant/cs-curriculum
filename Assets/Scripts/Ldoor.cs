using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openingSpeed = 2f;         // Speed at which the door opens
    public bool isOpen = false;            // Whether the door is open or closed
    private Vector3 closedPosition;        // The initial position of the door
    private Vector3 openPosition;          // The position where the door opens to
    private bool isMoving = false;         // To prevent multiple simultaneous movements

    private void Start()
    {
        // Set the door's closed position to its initial position
        closedPosition = transform.position;

        // Automatically calculate open position (adjust as necessary)
        openPosition = transform.position + Vector3.up * 1.5f; //5f // 5 units forward (adjust this for your needs)
    }

    private void Update()
    {
        if (isMoving)
        {
            // Move the door towards the open or closed position
            transform.position = Vector3.Lerp(transform.position, isOpen ? openPosition : closedPosition, openingSpeed * Time.deltaTime);

            // If the door is near its target position, stop the movement
            if (Vector3.Distance(transform.position, isOpen ? openPosition : closedPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }

    // Method to toggle the door state
    public void ToggleDoor()
    {
        isOpen = !isOpen;
        isMoving = true;  // Start moving the door
    }

    // Optionally, you can expose this method to manually set the door state (open or closed)
    public void SetDoorState(bool open)
    {
        isOpen = open;
        isMoving = true;
    }
}