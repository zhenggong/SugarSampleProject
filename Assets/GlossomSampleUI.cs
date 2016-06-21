using UnityEngine;
using System.Collections;

public class GlossomSampleUI : MonoBehaviour {
	WWW www;
	Texture2D galleryImage ; 

	
	public void Initialize()
	{

	}

	public void PlayGallery()
	{

	}
	
	public void PlayAVideo()
	{
		AndroidJavaClass ajc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ajo = new AndroidJavaObject ("com.example.gallery.UnityBinder");  

		// If you wish to use a the customID feature, you should call  that now.
		// Then, configure AdColony:
		ajo.CallStatic ( "ShowVideo" ,ajc.GetStatic <AndroidJavaObject>("currentActivity"));
	}
	
	// Use this for initialization
	private string info;//显示的信息/ 
	void Start()  
	{  
		//初始化/  
		info = "ボタンをクリックしてください";   
		// Assign any AdColony Delegates before calling Configure
				AndroidJavaClass ajc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
				AndroidJavaObject ajo = new AndroidJavaObject ("com.example.gallery.UnityBinder");
		//
		// If you wish to use a the customID feature, you should call  that now.
		// Then, configure AdColony:
				ajo.Call ( "Configure" ,ajc.GetStatic <AndroidJavaObject>("currentActivity"));
	}
	
	
	void OnGUI()
	{
		GUILayout.BeginArea(new Rect (50 , 50, 400, Screen.width / 2));
		
		GUILayout.Label(info);
		
		
		
		if (GUILayout.Button ("Play  Gallery")) {
			info = "ボタンをクリックしてください"; 
			PlayGallery();
		}
		
		if (GUILayout.Button (" Play  Adcolony")) {
			info = "ボタンをクリックしてください"; 
			PlayAVideo();
		}

		 if ( www  != null && www.isDone){
			galleryImage = new Texture2D(www.texture.width,www.texture.height);
			galleryImage .SetPixels32(www.texture.GetPixels32());
			galleryImage.Apply();
			www = null;

		}
		GUILayout.EndArea(); 
	}

	 public void OnPhotoPick(string filePath){
		Debug.Log (filePath);

	}
}