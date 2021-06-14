using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component, new() {
    static T _instance;

    void Awake(){
		if (_instance == null) {
			_instance = this as T;
			DontDestroyOnLoad (this);
		} else {
			Destroy (gameObject);
		}
        Init();
    }

    protected virtual void Init(){}

    public static T GetInstance(){
        if(_instance != null)
            return _instance;
        _instance = new T();
        return _instance;
    }
}