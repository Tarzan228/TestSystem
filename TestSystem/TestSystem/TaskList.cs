﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystem
{   
    
    public class TaskList
    {
        class Task
        {
            private string Question;
            string [] Ans = new string[5];
            Task(string Question, string Ans1, string Ans2, string Ans3, string Ans4, string Ans5)
            {
                this.Question = Question;
                this.Ans[1] = Ans1;
                this.Ans[2] = Ans2;
                this.Ans[3] = Ans3;
                this.Ans[4] = Ans4;
                this.Ans[5] = Ans5;
            }
            public string GetQuestion()
            {
                return Question;
            } 
            public string [] GetAnswers()
            {
                Random rand = new Random();
                string[] str = this.Ans.OrderBy(x => rand.Next()).ToArray();
                Array.Resize(ref str, 5);
                return new string[] { str[1], str[2], str[3], str[4], str[5] };
            }      
        }
        byte current = 1;
        int[][] Tasks = new int[50][];
        
    }
}
