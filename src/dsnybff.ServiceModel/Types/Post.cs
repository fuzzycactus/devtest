using System;
using System.Collections.Generic;
using System.Text;

namespace dsnybff.ServiceModel
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get { return Title_; } set { Title_ = value?.Trim(); } }
        public string Topics { get { return Topics_; } set { Topics_ = value?.Trim(); } }
        public string Locations { get { return Locations_; } set { Locations_ = value?.Trim(); } }
        public DateTime PublishedDate { get; set; }
        public string TripDate { get; set; }
        public string Slides { get; set; }
        public bool IsDraft { get; set; }
        public bool HasJr { get; set; }
        public bool HasSr { get; set; }
        public bool HasSlides { get; set; }

        private string Title_ = string.Empty;
        private string Topics_ = string.Empty;
        private string Locations_ = string.Empty;
    }
}
