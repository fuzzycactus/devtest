using System;
using System.Collections.Generic;
using System.Text;

namespace dsnybff.ServiceModel
{
    public class Location
    {
        public string Id { get { return Id_; } set { Id_ = value?.Trim(); } }
        public string Title { get { return Title_; } set { Title_ = value?.Trim(); } }
        public string Topics { get { return Topics_; } set { Topics_ = value?.Trim(); } }
        public string Abv { get; set; }
        public int IconImageId { get; set; }

        private string Id_ = string.Empty;
        private string Title_ = string.Empty;
        private string Topics_ = string.Empty;
    }
}
