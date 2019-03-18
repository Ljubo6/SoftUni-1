using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MeTube_Stats
{
    class MeTube
    {
        static void Main()
        {
            var videosViews = new Dictionary<string, int>();
            var videosLikes = new Dictionary<string, int>();


            string[] input = Console.ReadLine()
                .Split(new char[] { '-', ':' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (string.Join(' ', input) != "stats time")
            {
                if (input[0] != "like" && input[0] != "dislike")
                {
                    string videoName = input[0];

                    int views = int.Parse(input[1]);

                    if (!videosViews.ContainsKey(videoName))
                    {
                        videosViews.Add(videoName, views);
                        videosLikes.Add(videoName, 0);
                    }
                    else
                    {
                        videosViews[videoName] += views;
                    }
                }
                else
                {
                    string videoName = input[1];


                    if (!videosLikes.ContainsKey(videoName))
                    {
                        videosLikes.Add(videoName, 0);
                    }


                    if (input[0] == "like")
                    {
                        videosLikes[videoName]++;
                    }
                    else if (input[0] == "dislike")
                    {
                        videosLikes[videoName]--;
                    }
                }

                input = Console.ReadLine()
                    .Split(new char[] { '-', ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            string[] orderingBy = Console.ReadLine().Split();

            if (orderingBy[1] == "likes")
            {
                videosLikes = videosLikes.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                foreach (var video in videosLikes)
                {
                    Console.WriteLine($"{video.Key} - {videosViews[video.Key]} views - {video.Value} likes");
                }
            }
            else if (orderingBy[1] == "views")
            {
                videosViews = videosViews.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                foreach (var video in videosViews)
                {
                    Console.WriteLine($"{video.Key} - {video.Value} views - {videosLikes[video.Key]} likes");
                }
            }
        }
    }
}
