using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hana.Model;
using Machine.Specifications;
using System.Linq.Expressions;

namespace Hana.Specs {



    [Subject("PostService")]
    public class when_getting_homepage_model : with_post_service {

        Because of = () => {
            model = svc.GetHomePage();
        };

        It should_have_2_featured_posts = () => {
            model.FeaturePosts.Count.ShouldEqual(2);
        };
        It should_sort_featured_posts_descending = () => {
            model.FeaturePosts[0].PublishedAt.ShouldBeGreaterThan(model.FeaturePosts[1].PublishedAt);
        };

        It should_have_5_subsonic_posts = () => {
            model.SubSonicPosts.Count.ShouldEqual(5);
        };
        It should_sort_subsonic_posts_descending = () => {
            model.SubSonicPosts[0].PublishedAt.ShouldBeGreaterThan(model.SubSonicPosts[1].PublishedAt);
        };

        
        It should_have_5_opinion_posts = () => {
            model.OpinionPosts.Count.ShouldEqual(5);
        };
        It should_sort_opinion_posts_descending = () => {
            model.OpinionPosts[0].PublishedAt.ShouldBeGreaterThan(model.OpinionPosts[1].PublishedAt);
        };
        It should_have_5_recent_comments = () => {
            model.RecentComments.Count.ShouldEqual(5);
        };

    }
    [Subject("PostService")]
    public class when_getting_empty_homepage_model : with_post_service_no_posts {

        Because of = () => {
            model = svc.GetHomePage();
        };

        It should_have_0_featured_posts = () => {
            model.FeaturePosts.Count.ShouldEqual(0);
        };

        It should_have_0_subsonic_posts = () => {
            model.SubSonicPosts.Count.ShouldEqual(0);
        };

        It should_have_0_opinion_posts = () => {
            model.OpinionPosts.Count.ShouldEqual(0);
        };
        It should_have_0_recent_comments = () => {
            model.RecentComments.Count.ShouldEqual(0);
        };

    }

    [Subject("PostService")]
    public class when_getting_postpage_model_with_slug_only : with_post_service {

        Because of = () => {
            model = svc.GetPostPage("slug1");
        };

        It should_have_selected_post = () => {
            model.SelectedPost.ShouldNotBeNull();
        };
        It should_have_post_with_5_comments = () => {
            model.SelectedPost.Comments.Count.ShouldEqual(5);
        };
    }
    [Subject("PostService")]
    public class when_getting_postpage_model_with_not_posts_slug_only : with_post_service_no_posts {

        Because of = () => {
            model = svc.GetPostPage("slug1");
        };

        It should_not_have_selected_post = () => {
            model.SelectedPost.ShouldBeNull();
        };
        It should_have_0_related = () => {
            model.Related.Count.ShouldEqual(0);
        };
    }
    [Subject("PostService")]
    public class when_getting_postpage_model_with_slug_and_date_info : with_post_service {

        Because of = () => {
            //offset the day because we're pulling the 2nd Post
            model = svc.GetPostPage("slug1",DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.AddDays(-1).Day);
        };

        It should_have_selected_post = () => {
            model.SelectedPost.ShouldNotBeNull();
        };
        It should_have_post_with_5_comments = () => {
            model.SelectedPost.Comments.Count.ShouldEqual(5);
        };
        It should_have_post_with_5_related = () => {
            model.Related.Count.ShouldEqual(5);
        };

    }

    [Subject("PostService")]
    public class when_getting_postpage_model_with_slug_and_date_info_no_posts : with_post_service_no_posts {

        Because of = () => {
            //offset the day because we're pulling the 2nd Post
            model = svc.GetPostPage("slug1", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(-1).Day);
        };

        It should_have_selected_post = () => {
            model.SelectedPost.ShouldBeNull();
        };

        It should_have_post_with_0_related = () => {
            model.Related.Count.ShouldEqual(0);
        };

    }
    public abstract class with_post_service {
        
        protected static PostService svc;
        protected static PostViewModel model;
        Establish context = () => {
            var mock = new Moq.Mock<IBlogRepository>();
            var posts=new List<Post>();
            var comments = new List<Comment>();
            var subCat = new Category("SubSonic");
            var opCat = new Category("Opinion");


            //add 10 total posts
            for(int i=0;i<10;i++){

                Post p = new Post("Author", "Title " + i, "Body " + i);
                p.Slug = "slug" + i;
                p.PublishedAt = DateTime.Now.AddDays(-i);
                p.Status = PostStatus.Published;

                if (i < 5) {
                    p.Categories.Add(subCat);
                } else {
                    p.Categories.Add(opCat);
                }

                //add 5 comments
                for (int x = 0; x < 5; x++) {
                    Comment c = new Comment(p.ID, "Comment Author " + i, "Email " + i, "Url " + i, "Comment body" + i);
                    c.Status = CommentStatus.Approved;
                    p.Comments.Add(c);
                    comments.Add(c);
                }
                posts.Add(p);
            }
            var post = posts.SingleOrDefault(x => x.Slug == "slug1");

            mock.Setup(x => x.All<Post>()).Returns(posts.AsQueryable());
            mock.Setup(x => x.All<Comment>()).Returns(comments.AsQueryable());
            mock.Setup(x => x.Single<Post>(Moq.It.IsAny<Expression<Func<Post,bool>>>())).Returns(posts[1]);

            mock.Setup(x => x.Find<Comment>(Moq.It.IsAny<Expression<Func<Comment, bool>>>())).Returns(posts[1].Comments);
            
            mock.Setup(x => x.GetAssociated<Category, Post>(subCat))
                .Returns(posts.Where(y => y.Categories.Contains(subCat)).ToList());
            mock.Setup(x => x.GetAssociated<Category, Post>(opCat))
                .Returns(posts.Where(y => y.Categories.Contains(opCat)).ToList());
            
            
            svc = new PostService(mock.Object);
        };

    }


    public abstract class with_post_service_no_posts {

        protected static PostService svc;
        protected static PostViewModel model;
        Establish context = () => {
            var mock = new Moq.Mock<IBlogRepository>();

            svc = new PostService(mock.Object);
        };

    }


}
