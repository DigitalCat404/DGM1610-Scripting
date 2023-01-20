using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    
    //[Access Modifier] [Data-Type] [Name] [Access Operator] = [Value];
    //ex. public string heroName = "Bob";

    //declare variables
    public int one, two;
    public float floater = 1.5f;
    public double doubler = 257.98d;
    public char character, letter;
    public string mean, bean;
    private bool truth, lie;


    // Start is called before the first frame update
    void Start(){

    //assign variables
    one = 1;
    two = 2;
    character = 'c';
    letter = 'L';
    mean = "This is rude.";
    bean = "It's in coffee.";
    truth = true;
    lie = false;

      Console.WriteLine(one);
      Console.WriteLine(two);
      Console.WriteLine(floater);
      Console.WriteLine(doubler);
      Console.WriteLine(character);
      Console.WriteLine(letter);
      Console.WriteLine(mean);
      Console.WriteLine(bean);
      Console.WriteLine(truth);
      Console.WriteLine(lie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
