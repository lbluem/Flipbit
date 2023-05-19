using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// File that contains all relevant MetaData of a KutiGame.
/// Initial files will only contain the internalGameName used
/// to identify the Game. 
/// When exported all variables must be valid. The exporter
/// makes sure this happens.
/// 
/// This file is the main interface between the MainKutiBuild and KutiGameDevelopment.
/// </summary>
public class KutiGameMetaData : ScriptableObject {

    [SerializeField]
    private Sprite _gameIcon;

    [SerializeField]
    private string _startingSceneName;

    [SerializeField]
    private string _internalGameName;

    [SerializeField]
    private string _displayedGameName;

	[SerializeField]
	private string _gameDescription;

    [SerializeField]
    private string _locked;

    [SerializeField]
    private string _sortOrder;

    [SerializeField]
    private string _quizText;

    [SerializeField]
    private Sprite _quizBackground;

    [SerializeField]
    private int _quizBackgroundNumber;

    public string GameDescription
	{
		get { return _gameDescription; }
	}
	public string DisplayedGameName
    {
        get { return _displayedGameName; }
    }
    public Sprite GameIcon
    {
        get { return _gameIcon; }
    }
    public string StartingSceneName
    {
        get { return _startingSceneName; }
    }
    public string InternalGameName
    {
        get { return _internalGameName; }
    }
    public string Locked {
        get { return _locked; }
        set { _locked = value; }
    }public string SortOrder {
        get { return _sortOrder; }
        set { _sortOrder = value; }
    }
    public string QuizText {
        get { return _quizText; }
    }
    public Sprite QuizBackground {
        get { return _quizBackground; }
    }
    public int QuizBackgroundNumber {
        get { return _quizBackgroundNumber; }
    }

    public static KutiGameMetaData CreateKutiGameMetaDataInstance (string internalGameName, string displayedGameName, Sprite icon, string startingSceneName, string gameDescription, string sortOrder, string locked, string quizText, Sprite quizBackground, int quizBackgroundNumber) {
        var scriptableObject = ScriptableObject.CreateInstance<KutiGameMetaData> ();
        scriptableObject._startingSceneName = startingSceneName;
        scriptableObject._gameIcon = icon;
        scriptableObject._internalGameName = internalGameName;
        scriptableObject._displayedGameName = displayedGameName;
		scriptableObject._gameDescription = gameDescription;
        scriptableObject._locked = locked;
        scriptableObject._sortOrder = sortOrder;
        scriptableObject._quizText = quizText;
        scriptableObject._quizBackground = quizBackground;
        scriptableObject._quizBackgroundNumber = quizBackgroundNumber;

        return scriptableObject;
    }
#if UNITY_EDITOR
	public static void WriteKutiGameMetaData(KutiGameMetaData gameInformation)
    {
        AssetDatabase.CreateAsset(gameInformation, KutiPaths.KutiGameMetaDataPath + "/" + gameInformation._internalGameName + ".asset");
        AssetDatabase.SaveAssets();
    }
#endif
}
