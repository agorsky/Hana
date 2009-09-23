using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic.SqlGeneration.Schema;

namespace Hana.Model {

    public enum CommentStatus {
        Approved,
        ModerationQueue,
        MarkedAsSpam,
        NotScanned
    }

    [SubSonicTableNameOverride("wp_comments")]
    public class Comment {

        public Comment() {
            Status = CommentStatus.NotScanned;
            CreatedAt = DateTime.Now;
        }


        public Comment(int postID, string author, string email, string url, string body):this() {
            Author = author;
            Email = email;
            this.AuthorUrl = url;
            Body = body;
            PostID = postID;

        }


        public CommentStatus Status { get; set; }

        public int ReplyTo { get; set; }

        public int ID { get; set; }
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string IP { get; set; }
        public string AuthorUrl { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Meta { get; set; }
        public string PermaLink { get; set; }

        public override bool Equals(object obj) {

            if (obj.GetType() == typeof(Comment)) {
                var compare = (Comment)obj;
                return compare.Author.Equals(this.Author, StringComparison.InvariantCultureIgnoreCase)
                    && compare.Email.Equals(this.Email, StringComparison.InvariantCultureIgnoreCase)
                    && compare.Body.Equals(this.Body, StringComparison.InvariantCultureIgnoreCase)
                    && compare.PostID.Equals(this.PostID);
            }

            return base.Equals(obj);
        }

        public override string ToString() {
            return Body;
        }

        public override int GetHashCode() {
            return ID.GetHashCode();
        }
    }
}
