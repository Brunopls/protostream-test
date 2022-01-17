using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using protostream.Models;

namespace protostream
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new MovieContext())
            {
                if (!db.Set<Movie>().Any())
                {
                    using WebClient wc = new WebClient();
                    string csvData = wc.DownloadString("https://gist.githubusercontent.com/tiangechen/b68782efa49a16edaf07dc2cdaa855ea/raw/0c794a9717f18b094eabab2cd6a6b9a226903577/movies.csv");
                    List<Movie> movies = new List<Movie>();
                    var lines = csvData.Split('\n');

                    for (int i = 1; i < lines.Length; i++)
                    {

                        string[] csvRow = lines[i].Split(',');
                        csvRow[6] = csvRow[6].Remove(0, 1);

                        movies.Add(new Movie
                        {
                            id = i,
                            film = csvRow[0],
                            genre = csvRow[1],
                            leadStudio = csvRow[2],
                            audienceScore = Convert.ToByte(csvRow[3]),
                            profitability = Convert.ToDecimal(csvRow[4]),
                            rottenTomatoes = Convert.ToByte(csvRow[5]),
                            worldwideGross = Convert.ToDecimal(csvRow[6]),
                            year = Convert.ToUInt16(csvRow[7])
                        });
                    }
                    db.AddRange(movies.ToArray());
                    db.SaveChanges();
                }
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
