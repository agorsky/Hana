using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic.Extensions;
namespace Hana.Model {
    public class PostViewModel {

        public PostViewModel(int totalPosts, 
            int totalComments, 
            IList<Post> featured, 
            IList<Post> subsonic, 
            IList<Post> opinion, 
            IList<Comment> comments) {
            TotalPosts = totalPosts;
            TotalComments = totalComments;
            FeaturePosts = featured ?? new List<Post>();
            SubSonicPosts = subsonic ?? new List<Post>();
            OpinionPosts = opinion ?? new List<Post>();
            RecentComments = comments ?? new List<Comment>();
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
        public Post SelectedPost { get; set; }


    }
}
