using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

static class Result
{
    public static List<string> mostActive(List<string> customers)
    {
        var q = from x in customers
                group x by x into g
                let percentage = g.Count()/customers.Count()
                orderby percentage descending
                where percentage > 0.5
                select new { Value = g.Key, Count = percentage };

        var result = new List<string>(); 

        foreach (var item in q)
        {
            result.Add(item.Value);
        }
        return result;
    }

    public static string kangaroo(int x1, int v1, int x2, int v2)
    {
        if(v1 >= v2 && x2 < x1)
            return "NO";
        if(v1 < v2 && x2 >= x1)
            return "NO";
        if(v1 == v2 && x2 == x1)
            return "YES";
        if(v1 == v2 && x2 != x1)
            return "NO";
        if(v2!=v1 && x2 ==x1)
            return "NO";
        int xdiff = x2 - x1;
        int vdiff = v1 - v2; 
        float div = (float)xdiff / vdiff;
        if(Math.Floor(div) == Math.Ceiling(div) )
            return "YES";
        else
            return "NO";
    }

    public static int hourglassSum(List<List<int>> arr)
    {
        int column = arr.Count();
        int width = arr[0].Count();
        int sum = int.MinValue;

        if(width < 3 || column < 3)
            return sum;

        for(int startX = 0; startX < width -2; startX ++ ){
            for(int starty = 0; starty < column -2; starty ++){
                int x0 = arr[starty][startX] + arr[starty][startX+1] + arr[starty][startX+2];
                int center = arr[starty+1][startX+1];
                int x2 = arr[starty+2][startX] + arr[starty+2][startX+1] + arr[starty+2][startX+2];
                int temp = x0+center+x2;
                if(temp > sum)
                    sum = temp;
            }
        }
        return sum;
    }
    public static int sockMerchant(int n, List<int> ar)
    {
        int pair = 0;
        var temp = ar.Distinct().ToList();
        if(temp.Count == ar.Count)
            return 0;
        if(temp.Count == 1 && ar.Count > 1)
            return ar.Count/2;
        ar.Sort();
        for(int i = 0; i < ar.Count; i+=2){
            if(i+1 < ar.Count && ar[i] == ar[i+1]){
                pair++;
            }else if(i+2 < ar.Count && ar[i+1] == ar[i+2]){
                pair++;
                i++;
            }
        }
        return pair;
    }

    public static int countingValleys(int steps, string path)
    {
        char [] stepArr = path.ToCharArray();
        int count = 0;
        int level = 0;
        int index = 0;
        bool start = false;
        while(index < stepArr.Length){

            if(start == false && level == 0 && stepArr[index] == 'D')
                start = true;
            if(level == -1 && start == true && stepArr[index] == 'U'){
                count++;
                start = false;
            }
            if(stepArr[index] == 'U')
                level ++;
            else
                level --;
            index++;
        }
        return count;
    }
    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
        List<int> playerRank = new List<int>(); 
        var DisRanked = ranked.Distinct().ToList();

        //ranked = ListInt.Select(x => x - someValue).ToList();


        for(int i = 0; i < player.Count; i++){
            ranked.Add(player[i]);
            if(player[i] == ranked.Min()){
                playerRank.Add(ranked.Distinct().ToList().Count);
            }else if(player[i] == ranked.Max()){
                playerRank.Add(1);
            }else{
                ranked =  ranked.Distinct().ToList();
                ranked.Sort();
                playerRank.Add(ranked.Count - ranked.FindIndex(a => a == player[i]));
            }
        }
        return playerRank;
    }

}

class Solution2
{
    public static void Main(string[] args)
    {
        List<List<int>> arr = new List<List<int>>();
        for(int i = 0; i<2; i++){
            arr.Insert(i,new List<int>());
            for(int j = 0; j < 3; j++){
                
                arr[i].Insert(j, i );
            } 
        }
        //Result.hourglassSum(arr);
        //Result.sockMerchant(0, new List<int>{0,2,1,2,1,3});
        //Result.countingValleys(0, "UDUDUDUDUIDU");
        Result.climbingLeaderboard(new List<int>{0,2,1,2,1,3}, new List<int>{0,2,1,2,1,3});
    }
}
