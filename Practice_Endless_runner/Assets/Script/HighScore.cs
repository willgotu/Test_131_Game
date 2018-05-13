using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections;

class HighScore //:IComparable<HighScore>
{
    public int Score { get; set; }
    public string Name { get; set; }
    public int ID { get; set; }

    public HighScore(int id, int score, string name)
    {
        this.Score = score;
        this.Name = name;
        this.ID = id;
    }

    //public int CompareTo(HighScore other)
    //{
        //first > second return -1
        //first < second return 1: needs to swap
        //first == second return 0
        //if (other.Score < this.Score)
        //{
          //  return -1;
        //}
       // else if (other.Score > this.Score)
       // {
          //  return 1;
       // }

       // else return 0;

       



    //}
}