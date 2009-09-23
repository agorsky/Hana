using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Hana.Model;

namespace Hana.Specs {

    /*  Post Musings
    
     * A "Post" is a single entry on my blog. A chunk of text with a date, some categories,
     * and 0 or more tags. It's HTML - written by a remote editor (usually) and "posted" through
     * a MetaWeblog API magic function.
     * 
     * The post is identified by a "slug", which is a semi-unique title made up of URL "safe"
     * characters that replace whitespace and non-URL friendly characters. The slug is created 
     * when the post is, and can be specifed by the author or created automatically. The Slug is 
     * alpha-numeric with the exception of dashes replacing whitespace.
     * 
     * Because a slug isnt' guaranteed to be unique over the long run, adding the year/month/day to the
     * URL will further make it unique. If, for some dumb reason, I post 2 posts on the same day
     * with the same title - consider it a duplicate and simply overwrite the first.
     * 
     * A Post can have 0 or more comments as well.
     * 
     * A Post *must* have an excerpt - this is not only for formatting, but for the option (in the future) 
     * of sending out the excerpt thru RSS instead of whole post. The excerpt will be defined by the user 
     * through LiveWriter, or determined by a method of the post.
     * 
     * A post can have one or more categories - with a default category of "blog". This is to fit in
     * with my left over Graffiti posts which used /category/slug and it's also good housekeeping
     * 
     * When a post is created, a ping should be sent out to various services
     * 
     * A post should have a status - intially offline or published
     * 
     * A post should have a published date
     * 
     * A viewable Post = PublishedDate <= today and Status==published.
     * 
     * A new post should require a title, author, body
     * 
     * A new post should default published date to current date, accepting as override in ctor
     * 
    */


    [Subject("New Post")]
    public class when_creating : with_null_post {

        Because of = () => {
            post = new Post();
        };
        It should_default_published_date_to_now = () => {
            post.PublishedAt.ShouldBeGreaterThan(DateTime.Now.AddSeconds(-1));
            post.PublishedAt.ShouldBeLessThan(DateTime.Now.AddSeconds(1));

        };
        It should_default_status_to_draft = () => {
            post.Status.ShouldEqual(PostStatus.Draft);
        };

        It should_be_instantiated = () => {
            post.ShouldNotBeNull();
        };
        It should_default_all_dates_to_current_date = () => {
            post.CreatedAt.ShouldBeGreaterThan(DateTime.Now.AddSeconds(-1));
            post.CreatedAt.ShouldBeLessThan(DateTime.Now.AddSeconds(1));
            post.ModifiedAt.ShouldBeGreaterThan(DateTime.Now.AddSeconds(-1));
            post.ModifiedAt.ShouldBeLessThan(DateTime.Now.AddSeconds(1));
            post.PublishedAt.ShouldBeGreaterThan(DateTime.Now.AddSeconds(-1));
            post.PublishedAt.ShouldBeLessThan(DateTime.Now.AddSeconds(1));
        };

        It should_have_new_Guid_as_ID = () => {
            post.ID.ShouldNotEqual(Guid.Empty);
        };
        It should_have_empty_title_string_slug_author = () => {
            post.Title.ShouldEqual("");
            post.Slug.ShouldEqual("");
            post.Body.ShouldEqual("");
            post.Author.ShouldEqual("");
        };
        It should_not_be_viewable = () => {
            post.IsViewable.ShouldBeFalse();
        };

        It should_have_0_tags = () => {
            post.Tags.Count.ShouldEqual(0);
        };
        It should_have_0_comments = () => {
            post.Comments.Count.ShouldEqual(0);
        };
        It should_have_0_categories = () => {
            post.Categories.Count.ShouldEqual(0);
        };


    }



    [Subject("New Post")]
    public class creating_with_author_title_body : with_null_post {

        Because of = () => {
            var title = "This is a test post";
            var body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ut mauris nec ipsum volutpat hendrerit. Etiam mollis ultrices enim nec pulvinar. Vestibulum vitae eros ligula, eu aliquet lorem. Proin quis turpis vitae mauris feugiat pretium. Maecenas vestibulum blandit est ac faucibus. Duis diam nulla, eleifend id aliquet porttitor, aliquet et diam. Nunc lorem dui, dictum non commodo ut, luctus sit amet elit. Nulla malesuada, dolor eu feugiat viverra, ipsum nisl iaculis sapien, vel hendrerit lectus est eget nulla. Sed laoreet ultrices lacus, in porta ligula facilisis eget. Integer interdum euismod ante eu iaculis. Curabitur nec arcu vel nulla molestie elementum. Curabitur vitae pharetra diam. Ut fringilla tortor sed lectus ultricies non sagittis libero posuere. Fusce quis malesuada lorem. Integer vulputate sodales elit vitae tempus.";
            var author = "Test Author";
            post = new Post(author,title,body);
        };

        It should_have_author_set_to_Test_Author = () => {
            post.Author.ShouldEqual("Test Author");
        };

        It should_have_proper_slug = () => {
            post.Slug.ShouldEqual("this-is-a-test-post");
        };
        It should_have_Body = () => {
            post.Body.Length.ShouldBeGreaterThan(0);
        };        
        
        It should_have_Excerpt_of_500 = () => {
            post.Excerpt.Length.ShouldBeGreaterThan(0);
        };

        It should_have_0_comments = () => {
            post.Comments.Count.ShouldEqual(0);
        };

    }

    [Subject("New Post")]
    public class object_overrides : with_null_post {
        protected static Post post2;
        Because of = () => {
            var title = "This is a test post";
            var author = "Test Author";
            post = new Post(author, title, "");
            post2 = new Post(author, title, "");
        };

        It should_have_title_as_main_identifier = () => {
            post.ToString().ShouldEqual("This is a test post");
        };

        It should_be_equal_to_other_post_with_same_slug_year_month_and_day = () => {
            post.ShouldEqual(post2);
        };
        It should_have_same_hash_code_as_ID = () => {
            post.GetHashCode().ShouldEqual(post.ID.GetHashCode());
        };
    }


      


    public abstract class with_null_post {
        protected static Post post;
        Establish context = () => {
            post = null;
        };

    }
      
}
