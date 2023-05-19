using UnityEngine;
using UnityEditor;


/// <summary>
/// The Editor window that is used to initalize the Kuti Project.
/// The window will start with Unity if the project is not initialized yet.
/// </summary>
[InitializeOnLoad]
public class EditorKutiInitialiser : EditorWindow
{
    /// <summary>
    /// Name used as identifier for this Game. Must be unique
    /// </summary>
    private string internalGameName;

    /// <summary>
    /// Checkbox variable. If true will generate the standard Kuti folder structure
    /// </summary>
    private bool useKutiFolderStructure = true;


    /// <summary>
    /// Explanation text for Initial setup
    /// </summary>
    private static readonly string explanationTextInit = 
        "Initialise your Project\n" +
        "To Start developing a Kuti Game, please enter an internal Gamename.\n" +
        "This name will be used to identify your Game within the System.\n" +
        "The name needs to be unique to avoid collisions with other games\n" +
        "\n" +
        "The accual Game Name that will be displayed can be defined later when exporting your game.\n";


    /// <summary>
    /// Explanation text how to work with the Framework
    /// </summary>
    /// <param name="gameName"> Used to display what the namespace of the game will be</param>
    /// <returns></returns>
    private static string explanationtextKUBA(string gameName) {
        return "How to develop Games within KUBA\n" +
                "-----------------------------------------------------------\n" +
               "When developing your Game look out for these things:\n" +
               "\n" +
               "1. All of your Scripts need to be part of your\n" +
               "    own NameSpace (" + gameName + "), like this:\n" +
               "\n" +
               "namespace "+gameName+" { \n" +
               "\n" +
               "public class MyAwesomeClass { }\n" +
               "\n" +
               "}\n" +
               "\n" +
               "2. When using Inputs use the Kuti Buttons class" +
                "   functions.\n" +
               "\n" +
               "3. KUBA provides this working folder for you:\n" +
               "    “Assets/" + gameName + "”\n" +
               "    everything that is used in your game \n" +
               "    needs to be in this folder.\n" +
               "\n" +
               "4. All scenes that you want to be part of your game\n" +
               "    need to go into the " + gameName + "/KutiScenes Folder.\n" +
               "\n" +
               "5. The KutiDevKit offers utility functions you can use\n" +
               "    to develop your game. Checkout the .\n" +
               "    Documentation\n" +
               "\n" +
               "How to export my Game for the Kuti\n" +
               "-----------------------------------------------------------\n" +
               "1. Go to KutiMenu -> Export Kutipackage.\n" +
               "\n" +
               "2. Your Game needs an Icon. It’s resolution\n" +
               "    must be 512 x 512.\n" +
               "\n" +
               "3. Choose your Starting scene.\n"+
               "\n" +
               "4. Click export and send the file to\n"+
               "    the Kuti operator.\n";

    }


    /// <summary>
    /// Creates All necessary folders. If useKutiFolderStructure = true will also generate
    /// the standard Kuti folder structure
    /// </summary>
    void CreateKutiGameFolderStructure() {
        var gameBasePath = KutiPaths.GetKutiGamePath (internalGameName);

        //Create Folder for the Kutigame
        KutiPaths.createFolder(KutiPaths.GetKutiGameScenesPath(internalGameName));

        if (useKutiFolderStructure)
        {
            KutiPaths.createFolder(gameBasePath + "/Scripts");
            KutiPaths.createFolder(gameBasePath + "/Plugins");
            KutiPaths.createFolder(gameBasePath + "/Editor");
            KutiPaths.createFolder(gameBasePath + "/Content/Audio");
            KutiPaths.createFolder(gameBasePath + "/Content/Materials");
            KutiPaths.createFolder(gameBasePath + "/Content/Meshes");
            KutiPaths.createFolder(gameBasePath + "/Content/Prefabs");
            KutiPaths.createFolder(gameBasePath + "/Content/Textures");
        }


        AssetDatabase.SaveAssets ();
    }


    /// <summary>
    /// Creates a MetaData file that stores the internalGamename for later use.
    /// </summary>
    void CreateMetaData () {
        KutiPaths.createFolder (KutiPaths.KutiGameMetaDataPath);
        var gameMetaData = KutiGameMetaData.CreateKutiGameMetaDataInstance(internalGameName, internalGameName, null, null, null, null, null, null, null, 0);
        KutiGameMetaData.WriteKutiGameMetaData(gameMetaData);
    }


    /// <summary>
    /// On Unity startup shows Initialize Kuti Project window if not initialized yet
    /// </summary>
    static EditorKutiInitialiser()
    {
        //EditorApplication.update += StartupWindow;
    }

    /// <summary>
    /// Helper method is invoked after everything is loaded
    /// </summary>
    static void StartupWindow()
    {
        InitalizeKutiProject();
        EditorApplication.update -= StartupWindow;
    }


/// <summary>
/// Method that allows unity to disable the menu entry to initialize the Project
/// </summary>
/// <returns>Returns true if the project is not initalized (there is no KutiGameMetaData file)</returns>
[MenuItem("Kuti menu/Initialise KutiProject", true, 5)]
    static bool isTheKutiProjectNotInitialized()
    {
        string[] KutiGameMetaDataGUIDs = AssetDatabase.FindAssets("t:KutiGameMetaData");
        return KutiGameMetaDataGUIDs.GetLength(0) == 0;
    }


    /// <summary>
    /// Entry point to create the Initalize Window
    /// </summary>
    [MenuItem("Kuti menu/Initialize KutiProject",false,5)]
    static void InitalizeKutiProject()
    {
        EditorKutiInitialiser window = (EditorKutiInitialiser)EditorWindow.GetWindow(typeof(EditorKutiInitialiser));
        window.minSize = new Vector2(600, 180);
        window.Show();
    }


    /// <summary>
    /// Is called when the initialize button is clicked. 
    /// calls all functions that handle the initalize proccess
    /// </summary>
    void OnButtonClick()
    {
        //Use this function to make it robust
        if (string.IsNullOrEmpty(internalGameName))
        {
            EditorUtility.DisplayDialog("Unable to initialize Kuti Project with that name", "Please specify a valid internalGamename.", "Close");
            return;
        }

        CreateKutiGameFolderStructure();
        CreateMetaData();
        Close();


        EditorUtility.DisplayDialog("Project Initialized", explanationtextKUBA(internalGameName), "I understand");

    }


    /// <summary>
    /// Update method of the GUI
    /// </summary>
    void OnGUI()
    {
        EditorGUILayout.TextArea(explanationTextInit);
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Internal Gamename: ");
        internalGameName = EditorGUILayout.TextField(internalGameName);
        EditorGUILayout.EndHorizontal();
        useKutiFolderStructure = GUILayout.Toggle(useKutiFolderStructure, "Use Kuti folder structure");
        if (GUILayout.Button("Initialise Kuti Project"))
        {
            OnButtonClick();
            GUIUtility.ExitGUI();
        }
    }
}
