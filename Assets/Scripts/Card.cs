using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    enum Color{ RED, GREEN, BLUE, YELLOW}
    private int number;
	private enum Color color;

	public Card (int numb, string color) {
    	number = numb;
    	this.color = color;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}