using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hana.Model {

    public enum PostStatus {
        Draft,
        Published,
        Offline
    }

    public class Post {

        public Post() {
            ID = Guid.NewGuid();
            Title = "";
            Slug = "";
            Body = "";
            Author = "";
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
            PublishedAt = DateTime.Now;
            Tags = new string[0];
            Status = PostStatus.Draft;
        }

        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public string[] Tags { get; set; }
        public PostStatus Status { get; set; }
        
        //Comments
        //Categories

        public bool IsViewable {
            get {
                return PublishedAt <= DateTime.Now && Status == PostStatus.Published;
            }
        }



        #region Object Overrides

        public override bool Equals(object obj) {
            if (obj.GetType() == typeof(Post)) {
                Post compare = (Post)obj;
                return compare.Slug.Equals(this.Slug, StringComparison.CurrentCultureIgnoreCase);
            } else {
                return base.Equals(obj);
            }

        }

        public override string ToString() {
            return Title;
        }

        public override int GetHashCode() {
            return Slug.GetHashCode();
        }
        #endregion


    }

}
