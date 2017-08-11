using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter {

	public string prefix;
	public Text text;

	int value;

	public Counter(Text text, string prefix, int startingValue) {
		this.text = text;
		this.prefix = prefix;
		this.value = startingValue;

		UpdateText ();
	}

	public void Add(int n) {
		value += n;
		UpdateText ();
	}

	public void Subtract(int n) {
		value -= n;
		UpdateText ();
	}

	public void Reset() {
		value = 0;
		UpdateText ();
	}
		
	public int GetValue() {
		return value;
	}

	void UpdateText() {
		text.text = prefix + value.ToString ();
	}
}
