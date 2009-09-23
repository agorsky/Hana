using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic.Extensions;
namespace Hana.Model {
    public class PostViewModel {

        public PostViewModel(Post selectedPost, IEnumerable<Post> related, int totalPosts, int totalComments) {
            TotalPosts = totalPosts;
            TotalComments = totalComments;
            SelectedPost = selectedPost;
            if (related != null)
                Related = related.Take(5).ToList();
            else
                Related = new List<Post>();

        }

        public PostViewModel(int totalPosts, 
            int totalComments, 
            IEnumerable<Post> featured,
            IEnumerable<Post> subsonic,
            IEnumerable<Post> opinion,
            IEnumerable<Comment> comments) {
            TotalPosts = totalPosts;
            TotalComments = totalComments;

            if (featured != null)
                FeaturePosts = featured.OrderByDescending(x => x.PublishedAt).Take(2).ToList();
            else
                FeaturePosts = new List<Post>();


            if (subsonic != null)
                SubSonicPosts = subsonic.OrderByDescending(x => x.PublishedAt).Take(5).ToList();
            else
                SubSonicPosts = new List<Post>();


            if (opinion != null)
                OpinionPosts = opinion.OrderByDescending(x => x.PublishedAt).Take(5).ToList();
            else
                OpinionPosts = new List<Post>();


            if (comments != null)
                RecentComments = comments.OrderByDescending(x => x.CreatedAt).Take(5).ToList();
            else
                RecentComments = new List<Comment>();

        }

        public int TotalPosts { get; set; }
        public int TotalComments { get; set; }
        public int VolumeNumber {
            get {
                
                //volume should be the number of  weeks since I started blogging :)
                //which was... I think November of 2004. Ahhh... .Text....
                var then = new DateTime(2004,11,1);
                var now = DateTime.Now;

                var ticks = now.Subtract(then);
                var days = ticks.Days;

                return days / 7;
            }
        }

        public IList<Post> FeaturePosts { get; set; }
        public IList<Post> SubSonicPosts { get; set; }
        public IList<Post> OpinionPosts { get; set; }
        public IList<Comment> RecentComments { get; set; }
        public IList<Post> Related { get; set; }
        public Post SelectedPost { get; set; }


    }
}
