using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Hana.Model {
    public interface IBlogRepository {

        IQueryable<Post> GetPosts { get; set; }
        IQueryable<Comment> GetComments { get; set; }
        Post GetPost { get; set; }

    }
}
