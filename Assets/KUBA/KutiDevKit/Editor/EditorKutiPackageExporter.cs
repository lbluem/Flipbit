using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Object = UnityEngine.Object;

/// <summary>
/// Editor window for the Kuti Package exporter.
/// Handles the user input to create Unitypackage that contains all
/// relevant files of the Game for the Framework.
/// 
/// The Exporter does not allow faulty Unitypackages to be exported.
/// </summary>
public class EditorKutiPackageExporter : EditorWindow{
    
    /// <summary>
    /// The starting scene of the Game. This will be used by the KutiMenu
    /// to load the game when selected.
    /// </summary>
    private static SceneAsset startingScene;

    /// <summary>
    /// The Game icon that is used by the KutiMenu
    /// </summary>
    private static Object gameIcon;

    /// <summary>
    /// MetaData object. WriteKutiGameMetaData must before changes
    /// take effect.
    /// </summary>
    private static KutiGameMetaData kutiGameMetaData;

    /// <summary>
    /// The Name that is displayed by the KutiMenu
    /// </summary>
    private string displayedGameName;


	/// <summary>
	/// The description that is displayed by the KutiMenu
	/// </summary>
	private string gameDescription;

	/// <summary>
	/// On startup the kutiGameMetaData is loaded.
	/// </summary>
	void OnEnable()
    {
        //Finds the first KutiGameMetaData. If the Project is properly initialized there should be only one KutiGameMetaData Object
        //if there are more than one Object it is not possible to differentiate them and the first one found will be picked regardless of data.
        string gameInfoGUID = AssetDatabase.FindAssets("t:KutiGameMetaData")[0];
        string assetPath = AssetDatabase.GUIDToAssetPath(gameInfoGUID);
        kutiGameMetaData = AssetDatabase.LoadAssetAtPath<KutiGameMetaData>(assetPath);
    }


    /// <summary>
    /// Method that allows unity to disable the menu entry to export the Project
    /// </summary>
    /// <returns>Returns true if the project is initalized (there is at least 1 KutiGameMetaData file)</returns>
    [MenuItem("Kuti menu/Export KutiPackage", true, 11)]
    static bool IsKutiProjectInitialized()
    {
        string[] KutiGameMetaDataGUIDs = AssetDatabase.FindAssets("t:KutiGameMetaData");
        return KutiGameMetaDataGUIDs.GetLength(0) != 0;
    }


    /// <summary>
    /// Starts the Export window
    /// </summary>
    [MenuItem("Kuti menu/Export KutiPackage", false, 11)]
    static void ExportKutiPackage()
    {
        EditorKutiPackageExporter window =
            (EditorKutiPackageExporter)EditorWindow.GetWindow(
                typeof(EditorKutiPackageExporter));
        window.Show();
    }
    

    /// <summary>
    /// GUI update function
    /// </summary>
    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        startingScene = (SceneAsset)EditorGUILayout.ObjectField(
            "Starting Scene",startingScene, typeof(SceneAsset), false);


        gameIcon = EditorGUILayout.ObjectField("Game Icon sprite",
            gameIcon, typeof(Sprite), false);

        displayedGameName = EditorGUILayout.TextField("Displayed gamename", displayedGameName);

		EditorGUILayout.LabelField("Game description. Keep it short. Will use newline.");
		EditorGUILayout.LabelField("Will use newline. No more than 2 lines of text.");
		gameDescription = EditorGUILayout.TextArea(gameDescription);


		EditorGUILayout.EndVertical();
        if (GUILayout.Button("Export"))
        {
            OnClickExport();
            GUIUtility.ExitGUI();
        }
    }
    

    /// <summary>
    /// This method is called when export is clicked. 
    /// All files and user inputs will be checked for any violation
    /// of conventions or erros.
    /// If everything is correct a unitypackage can be exported.
    /// If not an Error message will be shown stating everything that is wrong.
    /// </summary>
    void OnClickExport()
    {

		//TODO: check for:
		//Correct use of namespaces
		
		//Is the displayed gamename valid
		//IF YES: display error message with all failed checks and dont export

		if (gameIcon == null)
		{
			throw new NullReferenceException ( "GameIcon not set!" );
		}

	    if ( !IsSpriteValid( (Sprite) gameIcon ) )
	    {
		    //throw new ArgumentOutOfRangeException( "GameIcon is not the right size! Make sure your Icon is 512x512." );
	    }

		if ( startingScene == null )
	    {
		    throw new NullReferenceException("StartingScene not set!");
	    }

	    if ( displayedGameName == "" )
	    {
			throw new NullReferenceException ( "DisplayedGameName is not set. Make sure you entered one." );
		}

        //SOFTCHECKS:
        //Are all scenes in the Project in the KutiScenes folder 
        //  (with exeption to the Scene in the scenefolders of the Kutidevkit)
        //IF YES: display warning message and ask the user if he knows what he is doing (continue? yes/no)

        var startingScenePath = KutiPaths.getScenePathInBuild(kutiGameMetaData.InternalGameName,startingScene.name);
        var updatedMetaData = KutiGameMetaData.CreateKutiGameMetaDataInstance (
            kutiGameMetaData.InternalGameName, 
            displayedGameName, 
            (Sprite)gameIcon,
            startingScenePath,
			gameDescription, "0", null, null, null, 0);

        KutiGameMetaData.WriteKutiGameMetaData(updatedMetaData);

        string[] assetPaths =  new string[2];
        assetPaths[0] = KutiPaths.GetKutiGamePath(kutiGameMetaData.InternalGameName);
        assetPaths[1] = KutiPaths.KutiGameMetaDataPath;
        string fullPath = EditorUtility.SaveFilePanel("Export KutiPackage", "",
            kutiGameMetaData.InternalGameName, "unitypackage");
        AssetDatabase.ExportPackage(assetPaths, fullPath, ExportPackageOptions.Recurse);
        Close();
    }

	private bool IsSpriteValid( Sprite sprite )
	{
		if ( sprite.texture.height != 512 || sprite.texture.width != 512 )
		{
			return false;
		}
		return true;
	}
}
