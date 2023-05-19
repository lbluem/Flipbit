using UnityEngine;
/// <summary>
/// Adapter for KutiInput. Will use Keyboard on any device expect Android.
/// Uses GPIO supported Buttons for Input on Android
/// </summary>
public class KutiInput : MonoBehaviour {


	// Player 1 mapping
	private static string player1MiddleButtonMapping = "w";
	private static string player1LeftButtonMapping = "a";
	private static string player1RightButtonMapping = "d";

	//Direction respective to the player 2 mapping
	private static string player2MiddleButtonMapping = "u";
	private static string player2LeftButtonMapping = "h";
	private static string player2RightButtonMapping = "k";

    //menu
	private static string menuButtonMapping = "5";
 
	private static string GetButtonMapping(EKutiButton button)
	{
		string returnValue;
		switch (button)
		{
			case EKutiButton.P1_LEFT:
				returnValue = player1LeftButtonMapping;
				break;
			case EKutiButton.P1_MID:
				returnValue =player1MiddleButtonMapping;
				break;
			case EKutiButton.P1_RIGHT:
				returnValue = player1RightButtonMapping;
				break;

			case EKutiButton.P2_LEFT:
				returnValue = player2LeftButtonMapping;
				break;
			case EKutiButton.P2_MID:
				returnValue = player2MiddleButtonMapping;
				break;
			case EKutiButton.P2_RIGHT:
				returnValue = player2RightButtonMapping;
				break;
			case EKutiButton.MENU:
				returnValue = menuButtonMapping;
				break;

			default:
				returnValue = "noInputMappingFound";
				break;
		}

		return returnValue;
	}

	public static bool GetKutiButton(EKutiButton button)
	{
        if(AndroidInput.isInitialized)
        {
            return AndroidInput.GetKutiButton(button);
        }

#if !ANDROID
        if (Input.GetKey(GetButtonMapping(button)))
        {
            return true;
        }
#endif
        return false;
	}

	public static bool GetKutiButtonDown(EKutiButton button)
	{
        if (AndroidInput.isInitialized)
        {
            return AndroidInput.GetKutiButtonDown(button);
        }

#if !ANDROID
        if (Input.GetKeyDown(GetButtonMapping(button)))
        {
            return true;
        }
#endif
        return false;
	}


	public static bool GetKutiButtonUp(EKutiButton button)
	{
        if (AndroidInput.isInitialized)
        {
            return AndroidInput.GetKutiButtonUp(button);
        }

#if !ANDROID
        if (Input.GetKeyUp(GetButtonMapping(button)))
        {
            return true;
        }
#endif
        return false;
	}

	public static bool GetAnyButtonDownPlayer1()
	{
		return
			(
			GetKutiButtonDown(EKutiButton.P1_LEFT) ||
			GetKutiButtonDown(EKutiButton.P1_MID) ||
			GetKutiButtonDown(EKutiButton.P1_RIGHT)
			);
	}

	public static bool GetAnyButtonDownPlayer2()
	{
		return
			(
			GetKutiButtonDown(EKutiButton.P2_LEFT) ||
            GetKutiButtonDown(EKutiButton.P2_MID) ||
			GetKutiButtonDown(EKutiButton.P2_RIGHT)
			);
	}

	public static bool GetAnyButtonDown()
	{
		return (GetAnyButtonDownPlayer1() || GetAnyButtonDownPlayer2());
	}

}
