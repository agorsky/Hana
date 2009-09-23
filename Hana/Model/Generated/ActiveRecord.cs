


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;

namespace WP
{
    
    
    /// <summary>
    /// A class which represents the wp_comments table in the wekeroad Database.
    /// </summary>
    public partial class wp_comment: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<wp_comment> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<wp_comment>(new WP.wekeroadDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<wp_comment> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(wp_comment item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                wp_comment item=new wp_comment();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<wp_comment> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WP.wekeroadDB _db;
        public wp_comment(string connectionString, string providerName) {

            _db=new WP.wekeroadDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                wp_comment.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_comment>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public wp_comment(){
             _db=new WP.wekeroadDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public wp_comment(Expression<Func<wp_comment, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<wp_comment> GetRepo(string connectionString, string providerName){
            WP.wekeroadDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WP.wekeroadDB();
            }else{
                db=new WP.wekeroadDB(connectionString, providerName);
            }
            IRepository<wp_comment> _repo;
            
            if(db.TestMode){
                wp_comment.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_comment>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<wp_comment> GetRepo(){
            return GetRepo("","");
        }
        
        public static wp_comment SingleOrDefault(Expression<Func<wp_comment, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            wp_comment single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static wp_comment SingleOrDefault(Expression<Func<wp_comment, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            wp_comment single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<wp_comment, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<wp_comment, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<wp_comment> Find(Expression<Func<wp_comment, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<wp_comment> Find(Expression<Func<wp_comment, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<wp_comment> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<wp_comment> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<wp_comment> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<wp_comment> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<wp_comment> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<wp_comment> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "comment_ID";
        }

        public object KeyValue()
        {
            return this.comment_ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<ulong>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.comment_author.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(wp_comment)){
                wp_comment compare=(wp_comment)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.comment_author.ToString();
        }

        public string DescriptorColumn() {
            return "comment_author";
        }
        public static string GetKeyColumn()
        {
            return "comment_ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "comment_author";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        ulong _comment_ID;
        public ulong comment_ID
        {
            get { return _comment_ID; }
            set
            {
                if(_comment_ID!=value){
                    _comment_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        ulong _comment_post_ID;
        public ulong comment_post_ID
        {
            get { return _comment_post_ID; }
            set
            {
                if(_comment_post_ID!=value){
                    _comment_post_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_post_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _comment_author;
        public string comment_author
        {
            get { return _comment_author; }
            set
            {
                if(_comment_author!=value){
                    _comment_author=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_author");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _comment_author_email;
        public string comment_author_email
        {
            get { return _comment_author_email; }
            set
            {
                if(_comment_author_email!=value){
                    _comment_author_email=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_author_email");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _comment_author_url;
        public string comment_author_url
        {
            get { return _comment_author_url; }
            set
            {
                if(_comment_author_url!=value){
                    _comment_author_url=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_author_url");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _comment_author_IP;
        public string comment_author_IP
        {
            get { return _comment_author_IP; }
            set
            {
                if(_comment_author_IP!=value){
                    _comment_author_IP=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_author_IP");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _comment_date;
        public DateTime comment_date
        {
            get { return _comment_date; }
            set
            {
                if(_comment_date!=value){
                    _comment_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _comment_date_gmt;
        public DateTime comment_date_gmt
        {
            get { return _comment_date_gmt; }
            set
            {
                if(_comment_date_gmt!=value){
                    _comment_date_gmt=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_date_gmt");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _comment_content;
        public string comment_content
        {
            get { return _comment_content; }
            set
            {
                if(_comment_content!=value){
                    _comment_content=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_content");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _comment_karma;
        public int comment_karma
        {
            get { return _comment_karma; }
            set
            {
                if(_comment_karma!=value){
                    _comment_karma=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_karma");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _comment_approved;
        public string comment_approved
        {
            get { return _comment_approved; }
            set
            {
                if(_comment_approved!=value){
                    _comment_approved=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_approved");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _comment_agent;
        public string comment_agent
        {
            get { return _comment_agent; }
            set
            {
                if(_comment_agent!=value){
                    _comment_agent=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_agent");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _comment_type;
        public string comment_type
        {
            get { return _comment_type; }
            set
            {
                if(_comment_type!=value){
                    _comment_type=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_type");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        ulong _comment_parent;
        public ulong comment_parent
        {
            get { return _comment_parent; }
            set
            {
                if(_comment_parent!=value){
                    _comment_parent=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_parent");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        ulong _user_id;
        public ulong user_id
        {
            get { return _user_id; }
            set
            {
                if(_user_id!=value){
                    _user_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="user_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _comment_reply_ID;
        public int comment_reply_ID
        {
            get { return _comment_reply_ID; }
            set
            {
                if(_comment_reply_ID!=value){
                    _comment_reply_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_reply_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<wp_comment, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the wp_links table in the wekeroad Database.
    /// </summary>
    public partial class wp_link: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<wp_link> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<wp_link>(new WP.wekeroadDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<wp_link> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(wp_link item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                wp_link item=new wp_link();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<wp_link> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WP.wekeroadDB _db;
        public wp_link(string connectionString, string providerName) {

            _db=new WP.wekeroadDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                wp_link.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_link>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public wp_link(){
             _db=new WP.wekeroadDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public wp_link(Expression<Func<wp_link, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<wp_link> GetRepo(string connectionString, string providerName){
            WP.wekeroadDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WP.wekeroadDB();
            }else{
                db=new WP.wekeroadDB(connectionString, providerName);
            }
            IRepository<wp_link> _repo;
            
            if(db.TestMode){
                wp_link.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_link>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<wp_link> GetRepo(){
            return GetRepo("","");
        }
        
        public static wp_link SingleOrDefault(Expression<Func<wp_link, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            wp_link single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static wp_link SingleOrDefault(Expression<Func<wp_link, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            wp_link single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<wp_link, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<wp_link, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<wp_link> Find(Expression<Func<wp_link, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<wp_link> Find(Expression<Func<wp_link, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<wp_link> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<wp_link> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<wp_link> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<wp_link> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<wp_link> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<wp_link> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "link_id";
        }

        public object KeyValue()
        {
            return this.link_id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<ulong>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.link_url.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(wp_link)){
                wp_link compare=(wp_link)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.link_url.ToString();
        }

        public string DescriptorColumn() {
            return "link_url";
        }
        public static string GetKeyColumn()
        {
            return "link_id";
        }        
        public static string GetDescriptorColumn()
        {
            return "link_url";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        ulong _link_id;
        public ulong link_id
        {
            get { return _link_id; }
            set
            {
                if(_link_id!=value){
                    _link_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _link_url;
        public string link_url
        {
            get { return _link_url; }
            set
            {
                if(_link_url!=value){
                    _link_url=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_url");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _link_name;
        public string link_name
        {
            get { return _link_name; }
            set
            {
                if(_link_name!=value){
                    _link_name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _link_image;
        public string link_image
        {
            get { return _link_image; }
            set
            {
                if(_link_image!=value){
                    _link_image=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_image");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _link_target;
        public string link_target
        {
            get { return _link_target; }
            set
            {
                if(_link_target!=value){
                    _link_target=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_target");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        long _link_category;
        public long link_category
        {
            get { return _link_category; }
            set
            {
                if(_link_category!=value){
                    _link_category=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_category");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _link_description;
        public string link_description
        {
            get { return _link_description; }
            set
            {
                if(_link_description!=value){
                    _link_description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _link_visible;
        public string link_visible
        {
            get { return _link_visible; }
            set
            {
                if(_link_visible!=value){
                    _link_visible=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_visible");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        ulong _link_owner;
        public ulong link_owner
        {
            get { return _link_owner; }
            set
            {
                if(_link_owner!=value){
                    _link_owner=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_owner");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _link_rating;
        public int link_rating
        {
            get { return _link_rating; }
            set
            {
                if(_link_rating!=value){
                    _link_rating=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_rating");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _link_updated;
        public DateTime link_updated
        {
            get { return _link_updated; }
            set
            {
                if(_link_updated!=value){
                    _link_updated=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_updated");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _link_rel;
        public string link_rel
        {
            get { return _link_rel; }
            set
            {
                if(_link_rel!=value){
                    _link_rel=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_rel");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _link_notes;
        public string link_notes
        {
            get { return _link_notes; }
            set
            {
                if(_link_notes!=value){
                    _link_notes=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_notes");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _link_rss;
        public string link_rss
        {
            get { return _link_rss; }
            set
            {
                if(_link_rss!=value){
                    _link_rss=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="link_rss");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<wp_link, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the wp_options table in the wekeroad Database.
    /// </summary>
    public partial class wp_option: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<wp_option> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<wp_option>(new WP.wekeroadDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<wp_option> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(wp_option item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                wp_option item=new wp_option();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<wp_option> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WP.wekeroadDB _db;
        public wp_option(string connectionString, string providerName) {

            _db=new WP.wekeroadDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                wp_option.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_option>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public wp_option(){
             _db=new WP.wekeroadDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public wp_option(Expression<Func<wp_option, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<wp_option> GetRepo(string connectionString, string providerName){
            WP.wekeroadDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WP.wekeroadDB();
            }else{
                db=new WP.wekeroadDB(connectionString, providerName);
            }
            IRepository<wp_option> _repo;
            
            if(db.TestMode){
                wp_option.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_option>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<wp_option> GetRepo(){
            return GetRepo("","");
        }
        
        public static wp_option SingleOrDefault(Expression<Func<wp_option, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            wp_option single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static wp_option SingleOrDefault(Expression<Func<wp_option, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            wp_option single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<wp_option, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<wp_option, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<wp_option> Find(Expression<Func<wp_option, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<wp_option> Find(Expression<Func<wp_option, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<wp_option> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<wp_option> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<wp_option> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<wp_option> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<wp_option> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<wp_option> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "option_id";
        }

        public object KeyValue()
        {
            return this.option_id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<ulong>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.option_name.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(wp_option)){
                wp_option compare=(wp_option)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.option_name.ToString();
        }

        public string DescriptorColumn() {
            return "option_name";
        }
        public static string GetKeyColumn()
        {
            return "option_id";
        }        
        public static string GetDescriptorColumn()
        {
            return "option_name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        ulong _option_id;
        public ulong option_id
        {
            get { return _option_id; }
            set
            {
                if(_option_id!=value){
                    _option_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="option_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _blog_id;
        public int blog_id
        {
            get { return _blog_id; }
            set
            {
                if(_blog_id!=value){
                    _blog_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="blog_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _option_name;
        public string option_name
        {
            get { return _option_name; }
            set
            {
                if(_option_name!=value){
                    _option_name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="option_name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _option_value;
        public string option_value
        {
            get { return _option_value; }
            set
            {
                if(_option_value!=value){
                    _option_value=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="option_value");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _autoload;
        public string autoload
        {
            get { return _autoload; }
            set
            {
                if(_autoload!=value){
                    _autoload=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="autoload");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<wp_option, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the wp_postmeta table in the wekeroad Database.
    /// </summary>
    public partial class wp_postmetum: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<wp_postmetum> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<wp_postmetum>(new WP.wekeroadDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<wp_postmetum> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(wp_postmetum item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                wp_postmetum item=new wp_postmetum();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<wp_postmetum> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WP.wekeroadDB _db;
        public wp_postmetum(string connectionString, string providerName) {

            _db=new WP.wekeroadDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                wp_postmetum.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_postmetum>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public wp_postmetum(){
             _db=new WP.wekeroadDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public wp_postmetum(Expression<Func<wp_postmetum, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<wp_postmetum> GetRepo(string connectionString, string providerName){
            WP.wekeroadDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WP.wekeroadDB();
            }else{
                db=new WP.wekeroadDB(connectionString, providerName);
            }
            IRepository<wp_postmetum> _repo;
            
            if(db.TestMode){
                wp_postmetum.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_postmetum>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<wp_postmetum> GetRepo(){
            return GetRepo("","");
        }
        
        public static wp_postmetum SingleOrDefault(Expression<Func<wp_postmetum, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            wp_postmetum single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static wp_postmetum SingleOrDefault(Expression<Func<wp_postmetum, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            wp_postmetum single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<wp_postmetum, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<wp_postmetum, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<wp_postmetum> Find(Expression<Func<wp_postmetum, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<wp_postmetum> Find(Expression<Func<wp_postmetum, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<wp_postmetum> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<wp_postmetum> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<wp_postmetum> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<wp_postmetum> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<wp_postmetum> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<wp_postmetum> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "meta_id";
        }

        public object KeyValue()
        {
            return this.meta_id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<ulong>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.meta_key.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(wp_postmetum)){
                wp_postmetum compare=(wp_postmetum)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.meta_key.ToString();
        }

        public string DescriptorColumn() {
            return "meta_key";
        }
        public static string GetKeyColumn()
        {
            return "meta_id";
        }        
        public static string GetDescriptorColumn()
        {
            return "meta_key";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        ulong _meta_id;
        public ulong meta_id
        {
            get { return _meta_id; }
            set
            {
                if(_meta_id!=value){
                    _meta_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="meta_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        ulong _post_id;
        public ulong post_id
        {
            get { return _post_id; }
            set
            {
                if(_post_id!=value){
                    _post_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _meta_key;
        public string meta_key
        {
            get { return _meta_key; }
            set
            {
                if(_meta_key!=value){
                    _meta_key=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="meta_key");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _meta_value;
        public string meta_value
        {
            get { return _meta_value; }
            set
            {
                if(_meta_value!=value){
                    _meta_value=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="meta_value");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<wp_postmetum, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the wp_posts table in the wekeroad Database.
    /// </summary>
    public partial class wp_post: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<wp_post> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<wp_post>(new WP.wekeroadDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<wp_post> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(wp_post item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                wp_post item=new wp_post();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<wp_post> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WP.wekeroadDB _db;
        public wp_post(string connectionString, string providerName) {

            _db=new WP.wekeroadDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                wp_post.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_post>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public wp_post(){
             _db=new WP.wekeroadDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public wp_post(Expression<Func<wp_post, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<wp_post> GetRepo(string connectionString, string providerName){
            WP.wekeroadDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WP.wekeroadDB();
            }else{
                db=new WP.wekeroadDB(connectionString, providerName);
            }
            IRepository<wp_post> _repo;
            
            if(db.TestMode){
                wp_post.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_post>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<wp_post> GetRepo(){
            return GetRepo("","");
        }
        
        public static wp_post SingleOrDefault(Expression<Func<wp_post, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            wp_post single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static wp_post SingleOrDefault(Expression<Func<wp_post, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            wp_post single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<wp_post, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<wp_post, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<wp_post> Find(Expression<Func<wp_post, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<wp_post> Find(Expression<Func<wp_post, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<wp_post> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<wp_post> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<wp_post> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<wp_post> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<wp_post> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<wp_post> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<ulong>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.post_content.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(wp_post)){
                wp_post compare=(wp_post)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.post_content.ToString();
        }

        public string DescriptorColumn() {
            return "post_content";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "post_content";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        ulong _ID;
        public ulong ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        ulong _post_author;
        public ulong post_author
        {
            get { return _post_author; }
            set
            {
                if(_post_author!=value){
                    _post_author=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_author");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _post_date;
        public DateTime post_date
        {
            get { return _post_date; }
            set
            {
                if(_post_date!=value){
                    _post_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _post_date_gmt;
        public DateTime post_date_gmt
        {
            get { return _post_date_gmt; }
            set
            {
                if(_post_date_gmt!=value){
                    _post_date_gmt=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_date_gmt");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _post_content;
        public string post_content
        {
            get { return _post_content; }
            set
            {
                if(_post_content!=value){
                    _post_content=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_content");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _post_title;
        public string post_title
        {
            get { return _post_title; }
            set
            {
                if(_post_title!=value){
                    _post_title=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_title");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _post_category;
        public int post_category
        {
            get { return _post_category; }
            set
            {
                if(_post_category!=value){
                    _post_category=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_category");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _post_excerpt;
        public string post_excerpt
        {
            get { return _post_excerpt; }
            set
            {
                if(_post_excerpt!=value){
                    _post_excerpt=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_excerpt");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _post_status;
        public string post_status
        {
            get { return _post_status; }
            set
            {
                if(_post_status!=value){
                    _post_status=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_status");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _comment_status;
        public string comment_status
        {
            get { return _comment_status; }
            set
            {
                if(_comment_status!=value){
                    _comment_status=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_status");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ping_status;
        public string ping_status
        {
            get { return _ping_status; }
            set
            {
                if(_ping_status!=value){
                    _ping_status=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ping_status");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _post_password;
        public string post_password
        {
            get { return _post_password; }
            set
            {
                if(_post_password!=value){
                    _post_password=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_password");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _post_name;
        public string post_name
        {
            get { return _post_name; }
            set
            {
                if(_post_name!=value){
                    _post_name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _to_ping;
        public string to_ping
        {
            get { return _to_ping; }
            set
            {
                if(_to_ping!=value){
                    _to_ping=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="to_ping");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _pinged;
        public string pinged
        {
            get { return _pinged; }
            set
            {
                if(_pinged!=value){
                    _pinged=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="pinged");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _post_modified;
        public DateTime post_modified
        {
            get { return _post_modified; }
            set
            {
                if(_post_modified!=value){
                    _post_modified=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_modified");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _post_modified_gmt;
        public DateTime post_modified_gmt
        {
            get { return _post_modified_gmt; }
            set
            {
                if(_post_modified_gmt!=value){
                    _post_modified_gmt=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_modified_gmt");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _post_content_filtered;
        public string post_content_filtered
        {
            get { return _post_content_filtered; }
            set
            {
                if(_post_content_filtered!=value){
                    _post_content_filtered=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_content_filtered");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        ulong _post_parent;
        public ulong post_parent
        {
            get { return _post_parent; }
            set
            {
                if(_post_parent!=value){
                    _post_parent=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_parent");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _guid;
        public string guid
        {
            get { return _guid; }
            set
            {
                if(_guid!=value){
                    _guid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="guid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _menu_order;
        public int menu_order
        {
            get { return _menu_order; }
            set
            {
                if(_menu_order!=value){
                    _menu_order=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="menu_order");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _post_type;
        public string post_type
        {
            get { return _post_type; }
            set
            {
                if(_post_type!=value){
                    _post_type=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_type");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _post_mime_type;
        public string post_mime_type
        {
            get { return _post_mime_type; }
            set
            {
                if(_post_mime_type!=value){
                    _post_mime_type=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="post_mime_type");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        long _comment_count;
        public long comment_count
        {
            get { return _comment_count; }
            set
            {
                if(_comment_count!=value){
                    _comment_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comment_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<wp_post, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the wp_term_relationships table in the wekeroad Database.
    /// </summary>
    public partial class wp_term_relationship: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<wp_term_relationship> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<wp_term_relationship>(new WP.wekeroadDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<wp_term_relationship> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(wp_term_relationship item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                wp_term_relationship item=new wp_term_relationship();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<wp_term_relationship> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WP.wekeroadDB _db;
        public wp_term_relationship(string connectionString, string providerName) {

            _db=new WP.wekeroadDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                wp_term_relationship.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_term_relationship>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public wp_term_relationship(){
             _db=new WP.wekeroadDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public wp_term_relationship(Expression<Func<wp_term_relationship, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<wp_term_relationship> GetRepo(string connectionString, string providerName){
            WP.wekeroadDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WP.wekeroadDB();
            }else{
                db=new WP.wekeroadDB(connectionString, providerName);
            }
            IRepository<wp_term_relationship> _repo;
            
            if(db.TestMode){
                wp_term_relationship.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_term_relationship>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<wp_term_relationship> GetRepo(){
            return GetRepo("","");
        }
        
        public static wp_term_relationship SingleOrDefault(Expression<Func<wp_term_relationship, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            wp_term_relationship single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static wp_term_relationship SingleOrDefault(Expression<Func<wp_term_relationship, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            wp_term_relationship single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<wp_term_relationship, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<wp_term_relationship, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<wp_term_relationship> Find(Expression<Func<wp_term_relationship, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<wp_term_relationship> Find(Expression<Func<wp_term_relationship, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<wp_term_relationship> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<wp_term_relationship> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<wp_term_relationship> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<wp_term_relationship> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<wp_term_relationship> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<wp_term_relationship> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "object_id";
        }

        public object KeyValue()
        {
            return this.object_id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<ulong>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.term_taxonomy_id.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(wp_term_relationship)){
                wp_term_relationship compare=(wp_term_relationship)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.term_taxonomy_id.ToString();
        }

        public string DescriptorColumn() {
            return "term_taxonomy_id";
        }
        public static string GetKeyColumn()
        {
            return "object_id";
        }        
        public static string GetDescriptorColumn()
        {
            return "term_taxonomy_id";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        ulong _object_id;
        public ulong object_id
        {
            get { return _object_id; }
            set
            {
                if(_object_id!=value){
                    _object_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="object_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        ulong _term_taxonomy_id;
        public ulong term_taxonomy_id
        {
            get { return _term_taxonomy_id; }
            set
            {
                if(_term_taxonomy_id!=value){
                    _term_taxonomy_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="term_taxonomy_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _term_order;
        public int term_order
        {
            get { return _term_order; }
            set
            {
                if(_term_order!=value){
                    _term_order=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="term_order");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<wp_term_relationship, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the wp_term_taxonomy table in the wekeroad Database.
    /// </summary>
    public partial class wp_term_taxonomy: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<wp_term_taxonomy> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<wp_term_taxonomy>(new WP.wekeroadDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<wp_term_taxonomy> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(wp_term_taxonomy item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                wp_term_taxonomy item=new wp_term_taxonomy();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<wp_term_taxonomy> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WP.wekeroadDB _db;
        public wp_term_taxonomy(string connectionString, string providerName) {

            _db=new WP.wekeroadDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                wp_term_taxonomy.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_term_taxonomy>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public wp_term_taxonomy(){
             _db=new WP.wekeroadDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public wp_term_taxonomy(Expression<Func<wp_term_taxonomy, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<wp_term_taxonomy> GetRepo(string connectionString, string providerName){
            WP.wekeroadDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WP.wekeroadDB();
            }else{
                db=new WP.wekeroadDB(connectionString, providerName);
            }
            IRepository<wp_term_taxonomy> _repo;
            
            if(db.TestMode){
                wp_term_taxonomy.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_term_taxonomy>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<wp_term_taxonomy> GetRepo(){
            return GetRepo("","");
        }
        
        public static wp_term_taxonomy SingleOrDefault(Expression<Func<wp_term_taxonomy, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            wp_term_taxonomy single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static wp_term_taxonomy SingleOrDefault(Expression<Func<wp_term_taxonomy, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            wp_term_taxonomy single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<wp_term_taxonomy, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<wp_term_taxonomy, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<wp_term_taxonomy> Find(Expression<Func<wp_term_taxonomy, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<wp_term_taxonomy> Find(Expression<Func<wp_term_taxonomy, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<wp_term_taxonomy> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<wp_term_taxonomy> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<wp_term_taxonomy> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<wp_term_taxonomy> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<wp_term_taxonomy> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<wp_term_taxonomy> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "term_taxonomy_id";
        }

        public object KeyValue()
        {
            return this.term_taxonomy_id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<ulong>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.taxonomy.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(wp_term_taxonomy)){
                wp_term_taxonomy compare=(wp_term_taxonomy)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.taxonomy.ToString();
        }

        public string DescriptorColumn() {
            return "taxonomy";
        }
        public static string GetKeyColumn()
        {
            return "term_taxonomy_id";
        }        
        public static string GetDescriptorColumn()
        {
            return "taxonomy";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        ulong _term_taxonomy_id;
        public ulong term_taxonomy_id
        {
            get { return _term_taxonomy_id; }
            set
            {
                if(_term_taxonomy_id!=value){
                    _term_taxonomy_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="term_taxonomy_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        ulong _term_id;
        public ulong term_id
        {
            get { return _term_id; }
            set
            {
                if(_term_id!=value){
                    _term_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="term_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _taxonomy;
        public string taxonomy
        {
            get { return _taxonomy; }
            set
            {
                if(_taxonomy!=value){
                    _taxonomy=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="taxonomy");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _description;
        public string description
        {
            get { return _description; }
            set
            {
                if(_description!=value){
                    _description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        ulong _parent;
        public ulong parent
        {
            get { return _parent; }
            set
            {
                if(_parent!=value){
                    _parent=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="parent");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        long _count;
        public long count
        {
            get { return _count; }
            set
            {
                if(_count!=value){
                    _count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<wp_term_taxonomy, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the wp_terms table in the wekeroad Database.
    /// </summary>
    public partial class wp_term: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<wp_term> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<wp_term>(new WP.wekeroadDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<wp_term> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(wp_term item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                wp_term item=new wp_term();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<wp_term> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WP.wekeroadDB _db;
        public wp_term(string connectionString, string providerName) {

            _db=new WP.wekeroadDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                wp_term.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_term>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public wp_term(){
             _db=new WP.wekeroadDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public wp_term(Expression<Func<wp_term, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<wp_term> GetRepo(string connectionString, string providerName){
            WP.wekeroadDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WP.wekeroadDB();
            }else{
                db=new WP.wekeroadDB(connectionString, providerName);
            }
            IRepository<wp_term> _repo;
            
            if(db.TestMode){
                wp_term.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_term>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<wp_term> GetRepo(){
            return GetRepo("","");
        }
        
        public static wp_term SingleOrDefault(Expression<Func<wp_term, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            wp_term single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static wp_term SingleOrDefault(Expression<Func<wp_term, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            wp_term single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<wp_term, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<wp_term, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<wp_term> Find(Expression<Func<wp_term, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<wp_term> Find(Expression<Func<wp_term, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<wp_term> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<wp_term> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<wp_term> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<wp_term> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<wp_term> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<wp_term> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "term_id";
        }

        public object KeyValue()
        {
            return this.term_id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<ulong>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.name.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(wp_term)){
                wp_term compare=(wp_term)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.name.ToString();
        }

        public string DescriptorColumn() {
            return "name";
        }
        public static string GetKeyColumn()
        {
            return "term_id";
        }        
        public static string GetDescriptorColumn()
        {
            return "name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        ulong _term_id;
        public ulong term_id
        {
            get { return _term_id; }
            set
            {
                if(_term_id!=value){
                    _term_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="term_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _name;
        public string name
        {
            get { return _name; }
            set
            {
                if(_name!=value){
                    _name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _slug;
        public string slug
        {
            get { return _slug; }
            set
            {
                if(_slug!=value){
                    _slug=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="slug");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        long _term_group;
        public long term_group
        {
            get { return _term_group; }
            set
            {
                if(_term_group!=value){
                    _term_group=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="term_group");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<wp_term, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the wp_usermeta table in the wekeroad Database.
    /// </summary>
    public partial class wp_usermetum: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<wp_usermetum> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<wp_usermetum>(new WP.wekeroadDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<wp_usermetum> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(wp_usermetum item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                wp_usermetum item=new wp_usermetum();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<wp_usermetum> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WP.wekeroadDB _db;
        public wp_usermetum(string connectionString, string providerName) {

            _db=new WP.wekeroadDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                wp_usermetum.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_usermetum>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public wp_usermetum(){
             _db=new WP.wekeroadDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public wp_usermetum(Expression<Func<wp_usermetum, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<wp_usermetum> GetRepo(string connectionString, string providerName){
            WP.wekeroadDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WP.wekeroadDB();
            }else{
                db=new WP.wekeroadDB(connectionString, providerName);
            }
            IRepository<wp_usermetum> _repo;
            
            if(db.TestMode){
                wp_usermetum.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_usermetum>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<wp_usermetum> GetRepo(){
            return GetRepo("","");
        }
        
        public static wp_usermetum SingleOrDefault(Expression<Func<wp_usermetum, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            wp_usermetum single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static wp_usermetum SingleOrDefault(Expression<Func<wp_usermetum, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            wp_usermetum single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<wp_usermetum, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<wp_usermetum, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<wp_usermetum> Find(Expression<Func<wp_usermetum, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<wp_usermetum> Find(Expression<Func<wp_usermetum, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<wp_usermetum> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<wp_usermetum> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<wp_usermetum> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<wp_usermetum> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<wp_usermetum> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<wp_usermetum> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "umeta_id";
        }

        public object KeyValue()
        {
            return this.umeta_id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<ulong>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.meta_key.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(wp_usermetum)){
                wp_usermetum compare=(wp_usermetum)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.meta_key.ToString();
        }

        public string DescriptorColumn() {
            return "meta_key";
        }
        public static string GetKeyColumn()
        {
            return "umeta_id";
        }        
        public static string GetDescriptorColumn()
        {
            return "meta_key";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        ulong _umeta_id;
        public ulong umeta_id
        {
            get { return _umeta_id; }
            set
            {
                if(_umeta_id!=value){
                    _umeta_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="umeta_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        ulong _user_id;
        public ulong user_id
        {
            get { return _user_id; }
            set
            {
                if(_user_id!=value){
                    _user_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="user_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _meta_key;
        public string meta_key
        {
            get { return _meta_key; }
            set
            {
                if(_meta_key!=value){
                    _meta_key=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="meta_key");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _meta_value;
        public string meta_value
        {
            get { return _meta_value; }
            set
            {
                if(_meta_value!=value){
                    _meta_value=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="meta_value");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<wp_usermetum, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the wp_users table in the wekeroad Database.
    /// </summary>
    public partial class wp_user: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<wp_user> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<wp_user>(new WP.wekeroadDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<wp_user> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(wp_user item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                wp_user item=new wp_user();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<wp_user> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WP.wekeroadDB _db;
        public wp_user(string connectionString, string providerName) {

            _db=new WP.wekeroadDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                wp_user.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_user>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public wp_user(){
             _db=new WP.wekeroadDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public wp_user(Expression<Func<wp_user, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<wp_user> GetRepo(string connectionString, string providerName){
            WP.wekeroadDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WP.wekeroadDB();
            }else{
                db=new WP.wekeroadDB(connectionString, providerName);
            }
            IRepository<wp_user> _repo;
            
            if(db.TestMode){
                wp_user.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<wp_user>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<wp_user> GetRepo(){
            return GetRepo("","");
        }
        
        public static wp_user SingleOrDefault(Expression<Func<wp_user, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            wp_user single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static wp_user SingleOrDefault(Expression<Func<wp_user, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            wp_user single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<wp_user, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<wp_user, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<wp_user> Find(Expression<Func<wp_user, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<wp_user> Find(Expression<Func<wp_user, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<wp_user> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<wp_user> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<wp_user> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<wp_user> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<wp_user> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<wp_user> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<ulong>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.user_login.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(wp_user)){
                wp_user compare=(wp_user)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.user_login.ToString();
        }

        public string DescriptorColumn() {
            return "user_login";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "user_login";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        ulong _ID;
        public ulong ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _user_login;
        public string user_login
        {
            get { return _user_login; }
            set
            {
                if(_user_login!=value){
                    _user_login=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="user_login");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _user_pass;
        public string user_pass
        {
            get { return _user_pass; }
            set
            {
                if(_user_pass!=value){
                    _user_pass=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="user_pass");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _user_nicename;
        public string user_nicename
        {
            get { return _user_nicename; }
            set
            {
                if(_user_nicename!=value){
                    _user_nicename=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="user_nicename");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _user_email;
        public string user_email
        {
            get { return _user_email; }
            set
            {
                if(_user_email!=value){
                    _user_email=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="user_email");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _user_url;
        public string user_url
        {
            get { return _user_url; }
            set
            {
                if(_user_url!=value){
                    _user_url=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="user_url");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _user_registered;
        public DateTime user_registered
        {
            get { return _user_registered; }
            set
            {
                if(_user_registered!=value){
                    _user_registered=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="user_registered");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _user_activation_key;
        public string user_activation_key
        {
            get { return _user_activation_key; }
            set
            {
                if(_user_activation_key!=value){
                    _user_activation_key=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="user_activation_key");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _user_status;
        public int user_status
        {
            get { return _user_status; }
            set
            {
                if(_user_status!=value){
                    _user_status=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="user_status");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _display_name;
        public string display_name
        {
            get { return _display_name; }
            set
            {
                if(_display_name!=value){
                    _display_name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="display_name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<wp_user, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}
