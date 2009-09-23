using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hana.Model;
using Machine.Specifications;
namespace Hana.Specs {


    [Subject("New Comment")]
    public class when_created_without_specifying_details : with_null_comment {

        Because of = () => {
            comment = new Comment();
        };

        It should_not_be_null = () => {
            comment.ShouldNotBeNull();
        };
        It should_have_id = () => {
            comment.ID.ShouldNotEqual(Guid.Empty);
        };

        It should_have_created_date_equal_now = () => {
            comment.CreatedAt.ShouldBeGreaterThan(DateTime.Now.AddSeconds(-1));
            comment.CreatedAt.ShouldBeLessThan(DateTime.Now.AddSeconds(1));
        };

        It should_have_status_of_NotScanned = () => {
            comment.Status.ShouldEqual(CommentStatus.NotScanned);
        };


    }


    [Subject("New Comment")]
    public class when_created_with_details : with_null_comment {

        Because of = () => {
            comment = new Comment(1,"Author","Email","URL","Body");
        };

        It should_not_be_null = () => {
            comment.ShouldNotBeNull();
        };
        It should_have_id = () => {
            comment.ID.ShouldNotEqual(Guid.Empty);
        };
        It should_have_postid = () => {
            comment.PostID.ShouldNotEqual(Guid.Empty);
        };
        It should_have_created_date_equal_now = () => {
            comment.CreatedAt.ShouldBeGreaterThan(DateTime.Now.AddSeconds(-1));
            comment.CreatedAt.ShouldBeLessThan(DateTime.Now.AddSeconds(1));
        };
        It should_have_author_email_url_body = () => {
            comment.Author.ShouldEqual("Author");
            comment.Email.ShouldEqual("Email");
            comment.AuthorUrl.ShouldEqual("URL");
            comment.Body.ShouldEqual("Body");
        };
    }

    [Subject("New Comment")]
    public class base_properties : with_null_comment {
        static Comment comment2;
        Because of = () => {
            var postID = 1;
            comment = new Comment(postID,"Author", "Email", "URL", "Body");
            comment2 = new Comment(postID,"Author", "Email", "URL", "Body");
        };

        It should_have_title_as_main_identifier = () => {
            comment.ToString().ShouldEqual("Body");
        };

        It should_be_equal_to_other_comment_with_same_author_url_body_postid = () => {
            comment.ShouldEqual(comment2);
        };
        It should_have_same_hash_code_as_ID = () => {
            comment.GetHashCode().ShouldEqual(comment.ID.GetHashCode());
        };
    }


    public abstract class with_null_comment {
        protected static Comment comment;
        Establish context = () => {
            comment = null;
        };

    }

      
}
