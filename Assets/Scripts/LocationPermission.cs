using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

// opens dialog to ask for permission to use location services of android device
public class LocationPermission : MonoBehaviour
{
    GameObject dialog = null;

    // Start is called before the first frame update
    public void Start()
    {

        // asks for permission if user hasn't authorized it yet
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            dialog = new GameObject();
        }
#endif
    }

    void OnGUI()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            // The user denied permission to use location services.
            // Display a message explaining why you need it with Yes/No buttons.
            // If the user says yes then present the request again
            // Display a dialog here.
            dialog.AddComponent<PermissionsRationaleDialog>();
           return;
        }
        else if (dialog != null)
        {
            Destroy(dialog);
            
        // do something here
        }
#endif
    }
}