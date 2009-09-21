using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hana.Model {

    public class PostService {
        IRepository _repo;
        public PostService() {
            _repo = null;
        }
        public PostService(IRepository repo) {
            _repo = repo;
        }



    }
}
