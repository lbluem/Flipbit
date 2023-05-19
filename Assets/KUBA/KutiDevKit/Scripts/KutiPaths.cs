using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

/// <summary>
/// Utility class that stores all relevant paths and path related functions.
/// </summary>
public static class KutiPaths{

    /// <summary>
    /// Path to the Scenes of the KutiMenu. Does not end on a /
    /// </summary>
    public static readonly string KutiMenuScenesPath = "Assets/KUBA/KutiMenu/Scenes";


    /// <summary>
    /// Path to the Scenes of the KutiSystem. Does not end on a /
    /// </summary>
    public static readonly string KutiSystemScenesPath = "Assets/KUBA/KutiSystem/Scenes";


    /// <summary>
    /// Path to the Scenes KutiDevkit. Does not end on a /
    /// </summary>
    public static readonly string KutiDevKitScenesPath = "Assets/KUBA/KutiDevKit/Scenes";


    /// <summary>
    /// Path of the inital Scene that is loaded on Kuti Startup. Does not end on a /
    /// </summary>
    public static readonly string KutiInitialiserScenePath = "Assets/KUBA/KutiSystem/Scenes/KutiInitaliser";


    /// <summary>
    /// Path where the GameMetaData is stored. Does not end on a /
    /// </summary>
    public static readonly string KutiGameMetaDataPath = "Assets/KUBA/KutiDevKit/KutiInterface/GameMetaData";


    /// <summary>
    /// Path where all Scenes is stored. Does not end on a /
    /// Call GetKutiGameScenePath to get the accual path since the Gamename folder are part
    /// of the path and are dynamicly created
    /// </summary>
    private static readonly string _kutiGameScenesPath = "KutiScenes";

    /// <summary>
    /// Returns the Path to data from gameName. Does not end on a /
    /// </summary>
    public static string GetKutiGamePath(string internalGameName)
    {
        return "Assets/" + internalGameName;
    }


    /// <summary>
    /// Path where the all Scenes of given Kuti game is stored. Does not end on a /
    /// </summary>
    public static string GetKutiGameScenesPath(string internalGameName)
    {
        return "Assets/"+internalGameName+"/"+_kutiGameScenesPath;
    }

    /// <summary>
    /// Gets the scene Path without Assets/. Is used to get the path used
    /// for loading by Scenepath
    /// </summary>
    /// <param name="internalGameName">identifier of the Game of the Scene</param>
    /// <param name="sceneName">name of the Scene</param>
    /// <returns>path that can be used to load scene by scenepath</returns>
    public static string getScenePathInBuild(string internalGameName, string sceneName)
    {
        return internalGameName + "/" + _kutiGameScenesPath + "/" + sceneName;
    }
#if UNITY_EDITOR
	/// <summary>
	/// Creates all non-existing Folders in given path
	/// </summary>
	/// <param name="fullFolderPath"></param>
	public static void createFolder(string fullFolderPath)
    {
        Stack pathStack = new Stack();
        getAllPathsInFolderPath(fullFolderPath, pathStack);


        foreach(string path in pathStack){
            createFolderIfNotExist(path);
        }
    }


    /// <summary>
    /// Recursive method to get all Subpaths of a Folderpath
    /// e.g. : Assets/Batman/Batmobile returns the paths:
    /// Assets
    /// Assets/Batman
    /// Assets/Batman/Batmobile
    /// </summary>
    static void getAllPathsInFolderPath(string FullFolderPath, Stack pathStack)
    {
        string folderPath = Path.GetDirectoryName(FullFolderPath);
        if(folderPath == string.Empty)
        {
            return;
        }
        else
        {
            pathStack.Push(FullFolderPath);
            getAllPathsInFolderPath(folderPath, pathStack);
        }
    }


	/// <summary>
	/// Creates the last folder in path if it does not exist.
	/// </summary>
	/// <param name="FullFolderPath"></param>
	static void createFolderIfNotExist(string FullFolderPath)
    {
        string folderPath = Path.GetDirectoryName(FullFolderPath);
        string folderName = Path.GetFileName(FullFolderPath);

        if (!AssetDatabase.IsValidFolder(FullFolderPath))
        {
            AssetDatabase.CreateFolder(folderPath, folderName);
        }
    }
#endif
}
