using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hana.Model {

    public class PostService {
        IBlogRepository _repo;
        public PostService() {
            _repo = null;
        }
        public PostService(IBlogRepository repo) {
            _repo = repo;
        }

        /// <summary>
        /// pulls the data for use on the home page
        /// </summary>
        /// <returns></returns>
        public PostViewModel GetHomePage() {
            
            var totalPosts = _repo.All<Post>().Count();
            var totalComments = _repo.All<Comment>().Count();

            var featured=(from p in _repo.All<Post>()
                       where p.PublishedAt <= DateTime.Now && p.Status==PostStatus.Published
                       select p);
            

            var subsonicCategory=new Category("SubSonic");
            var subsonic = _repo.GetAssociated<Category, Post>(subsonicCategory);

            var opinionCat = new Category("Opinion");
            var opinion = _repo.GetAssociated<Category, Post>(opinionCat);

            var recentComments = (from c in _repo.All<Comment>()
                                  orderby c.CreatedAt descending
                                  where c.Status==CommentStatus.Approved
                                  select c);


            return new PostViewModel(totalPosts, totalComments, featured, 
                subsonic, opinion, recentComments);

        }
        /// <summary>
        /// pulls the data for use on the home page
        /// </summary>
        /// <returns></returns>
        public PostViewModel GetPostPage(string slug) {

            return GetPostPage(slug, 0, 0, 0);

        }
        /// <summary>
        /// pulls the data for use on the home page
        /// </summary>
        /// <returns></returns>
        public PostViewModel GetPostPage(string slug, int year, int month, int day) {

            var totalPosts = _repo.All<Post>().Count();
            var totalComments = _repo.All<Comment>().Count();
            Post post = null;
            if (year > 0 && month > 0 && day > 0) {
                post = _repo.Single<Post>(x => x.Slug == slug && x.PublishedAt.Year==year
                    && x.PublishedAt.Month==month
                    && x.PublishedAt.Day==day);
            } else {
                post = _repo.Single<Post>(x => x.Slug == slug);
            }

            if(post!=null)
                post.Comments = _repo.Find<Comment>(x => x.PostID == post.ID);

            //find related
            //stubbed 
            //TODO: Make related posts mean something
            var related = _repo.All<Post>().Take(5);

            return new PostViewModel(post, related,totalPosts, totalComments);

        }
    }
}
