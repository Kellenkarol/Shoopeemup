using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
	private bool IsPaused;

	public void Pause()
	{
		Time.timeScale = IsPaused ? 1 : 0;
		IsPaused = !IsPaused;
	}
}
