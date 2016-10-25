using UnityEngine;
using System.Collections;

public class QuitOnClick : MonoBehaviour
{
//	public void Quit()
//
//	{
////		#if UNITY_EDTIOR
////			UnityEditor.EditorApplication.isPlaying = false;
////
////		#else
////
////			Application.Quit();
////
////		#endif
//		Application.Quit();
//	}
	void Update(){

		if(Input.GetKeyDown(KeyCode.Escape)){

			Application.Quit();
		}
	}
}
