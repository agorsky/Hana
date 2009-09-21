using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hana.Model;
using Machine.Specifications;

namespace Hana.Specs {



    [Subject("New PostViewModel")]
    public class when_creating_with_0_counts_and_null_lists : with_null_post_view_model {

        Because of = () => {

            post = new PostViewModel(0, 0, null, null, null, null);
        };

        It should_have_0_total_posts = () => {
            post.TotalPosts.ShouldEqual(0);
        };
        It should_have_0_total_comments = () => {
            post.TotalComments.ShouldEqual(0);
        };
        It should_have_0_recentComments = () => {
            post.RecentComments.Count.ShouldEqual(0);
        };
        It should_have_0_subsonic_posts = () => {
            post.SubSonicPosts.Count.ShouldEqual(0);
        };

        It should_have_0_feature_posts = () => {
            post.FeaturePosts.Count.ShouldEqual(0);
        };
        It should_have_0_opinion = () => {
            post.OpinionPosts.Count.ShouldEqual(0);
        };
        It should_have_VolumeNumber_set_to_weeks_between_nov_2004_and_now = () => {
            var then = new DateTime(2004, 11, 1);
            var weeks = DateTime.Now.Subtract(then).Days / 7;
            post.VolumeNumber.ShouldEqual(weeks);
        };
    }




    [Subject("PostViewModel")]
    public class when_creating_with_post_lists_and_totalPosts_100_and_totalComments_1000 : with_1_post_of_each_type {

        Because of = () => {

        };

        It should_have_100_total_posts = () => {
            post.TotalPosts.ShouldEqual(100);
        };
        It should_have_1000_total_comments = () => {
            post.TotalComments.ShouldEqual(1000);
        };
        It should_have_0_recentComments = () => {
            post.RecentComments.Count.ShouldEqual(0);
        };
        It should_have_1_subsonic_posts = () => {
            post.SubSonicPosts.Count.ShouldEqual(1);
        };

        It should_have_1_feature_posts = () => {
            post.FeaturePosts.Count.ShouldEqual(1);
        };
        It should_have_1_opinion = () => {
            post.OpinionPosts.Count.ShouldEqual(1);
        };
    }

      

    public abstract class with_null_post_view_model {
        protected static PostViewModel post;
        Establish context = () => {
            post = null;
        };

    }
    public abstract class with_1_post_of_each_type {
        protected static PostViewModel post;
        Establish context = () => {

            var p = new Post();
            var list=new List<Post>();
            list.Add(p);
            post = new PostViewModel(100,1000,list,list,list,null);
        };

    }
      
}
