using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic.Extensions;
using System.Text.RegularExpressions;

namespace Hana.Model {

    public enum PostStatus {
        Draft,
        Published,
        Offline
    }

    public class Post {

        public Post(string author, string title, string body):this() {
            Author = author;
            Title = title;
            Body = body;
            Slug = CreateSlug(title);
            Excerpt = CreateSummary();
        }

        public Post() {
            ID = Guid.NewGuid();
            Title = "";
            Slug = "";
            Body = "";
            Author = "";
            Excerpt = "";
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
            PublishedAt = DateTime.Now;
            Status = PostStatus.Draft;
            Comments = new List<Comment>();
            Tags = new List<Tag>();
            Categories = new List<Category>();
        }

        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public PostStatus Status { get; set; }
        public string Excerpt { get; set; }

        public IList<Comment> Comments { get; set; }
        public IList<Tag> Tags { get; set; }
        public IList<Category> Categories{ get; set; }


        public bool IsViewable {
            get {
                return PublishedAt <= DateTime.Now && Status == PostStatus.Published;
            }
        }

        string CreateSummary() {
            string result = this.Body;
            if (Body.Length > 300) {


                if (Body.Length > 500) {
                    result = result.Substring(0, 500);
                }

                result = result.StripHTML();



                if (result.Length > 300) {
                    //find the next period, after the 300 mark
                    var period = result.IndexOf(".");
                    result = result.Substring(0, period + 1);

                }

            }
            return result;
        }

        string CreateSlug(string source) {
            var regex = new Regex(@"([^a-z0-9\-]?)");
            string slug = "";

            if (!string.IsNullOrEmpty(source)) {
                slug = source.Trim().ToLower();
                slug = slug.Replace(' ', '-');
                slug = slug.Replace("---", "-");
                slug = slug.Replace("--", "-");
                if (regex != null)
                    slug = regex.Replace(slug, "");

                if (slug.Length * 2 < source.Length)
                    return "";

                if (slug.Length > 100)
                    slug = slug.Substring(0, 100);
            }

            return slug;

        }

        #region Object Overrides

        public override bool Equals(object obj) {
            if (obj.GetType() == typeof(Post)) {
                Post compare = (Post)obj;
                bool result = compare.Slug.Equals(this.Slug, StringComparison.CurrentCultureIgnoreCase)
                    && compare.CreatedAt.Year == CreatedAt.Year
                    && compare.CreatedAt.Month == CreatedAt.Month
                    && compare.CreatedAt.Day == CreatedAt.Day;

                return result;
            } else {
                return base.Equals(obj);
            }

        }

        public override string ToString() {
            return Title;
        }

        public override int GetHashCode() {
            return ID.GetHashCode();
        }
        #endregion


    }

}
