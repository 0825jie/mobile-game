using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {



		// Use this for initialization
		public void Restart (int startIndex){
		SceneManager.LoadScene (startIndex);
		}


}
