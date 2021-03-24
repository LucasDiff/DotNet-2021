using BreakingBricksCore.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BreakingBricksCore.Service
{
    public class RatingServiceFile : IRatingService
    {
        private const string FileName = "rating.bin";

        private List<Rating> _ratings = new List<Rating>();
        void IRatingService.AddRating(Rating rating)
        {
            _ratings.Add(rating);
            SaveRatings();
        }

        IList<Rating> IRatingService.GetTopRatings()
        {
            LoadRatings();
            return _ratings.OrderByDescending(s => s.PlayerRating).Take(3).ToList();

        }
        void IRatingService.ResetRatings()
        {
            _ratings.Clear();
            File.Delete(FileName);
        }
        private void SaveRatings()
        {
            using var fs = File.OpenWrite(FileName);
            var bf = new BinaryFormatter();
            bf.Serialize(fs, _ratings);
        }
        private void LoadRatings()
        {
            if (File.Exists(FileName))
            {
                using var fs = File.OpenRead(FileName);
                var bf = new BinaryFormatter();
                _ratings = (List<Rating>)bf.Deserialize(fs);
            }
        }
    }
}