


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace WP {
	
        /// <summary>
        /// Table: wp_comments
        /// Primary Key: comment_ID
        /// </summary>

        public class wp_commentsTable: DatabaseTable {
            
            public wp_commentsTable(IDataProvider provider):base("wp_comments",provider){
                ClassName = "wp_comment";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("comment_ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("comment_post_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("comment_author", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("comment_author_email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 33
                });

                Columns.Add(new DatabaseColumn("comment_author_url", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 66
                });

                Columns.Add(new DatabaseColumn("comment_author_IP", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 33
                });

                Columns.Add(new DatabaseColumn("comment_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("comment_date_gmt", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("comment_content", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });

                Columns.Add(new DatabaseColumn("comment_karma", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("comment_approved", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6
                });

                Columns.Add(new DatabaseColumn("comment_agent", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 85
                });

                Columns.Add(new DatabaseColumn("comment_type", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6
                });

                Columns.Add(new DatabaseColumn("comment_parent", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("user_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("comment_reply_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn comment_ID{
                get{
                    return this.GetColumn("comment_ID");
                }
            }
            				
   			public static string comment_IDColumn{
			      get{
        			return "comment_ID";
      			}
		    }
           
            public IColumn comment_post_ID{
                get{
                    return this.GetColumn("comment_post_ID");
                }
            }
            				
   			public static string comment_post_IDColumn{
			      get{
        			return "comment_post_ID";
      			}
		    }
           
            public IColumn comment_author{
                get{
                    return this.GetColumn("comment_author");
                }
            }
            				
   			public static string comment_authorColumn{
			      get{
        			return "comment_author";
      			}
		    }
           
            public IColumn comment_author_email{
                get{
                    return this.GetColumn("comment_author_email");
                }
            }
            				
   			public static string comment_author_emailColumn{
			      get{
        			return "comment_author_email";
      			}
		    }
           
            public IColumn comment_author_url{
                get{
                    return this.GetColumn("comment_author_url");
                }
            }
            				
   			public static string comment_author_urlColumn{
			      get{
        			return "comment_author_url";
      			}
		    }
           
            public IColumn comment_author_IP{
                get{
                    return this.GetColumn("comment_author_IP");
                }
            }
            				
   			public static string comment_author_IPColumn{
			      get{
        			return "comment_author_IP";
      			}
		    }
           
            public IColumn comment_date{
                get{
                    return this.GetColumn("comment_date");
                }
            }
            				
   			public static string comment_dateColumn{
			      get{
        			return "comment_date";
      			}
		    }
           
            public IColumn comment_date_gmt{
                get{
                    return this.GetColumn("comment_date_gmt");
                }
            }
            				
   			public static string comment_date_gmtColumn{
			      get{
        			return "comment_date_gmt";
      			}
		    }
           
            public IColumn comment_content{
                get{
                    return this.GetColumn("comment_content");
                }
            }
            				
   			public static string comment_contentColumn{
			      get{
        			return "comment_content";
      			}
		    }
           
            public IColumn comment_karma{
                get{
                    return this.GetColumn("comment_karma");
                }
            }
            				
   			public static string comment_karmaColumn{
			      get{
        			return "comment_karma";
      			}
		    }
           
            public IColumn comment_approved{
                get{
                    return this.GetColumn("comment_approved");
                }
            }
            				
   			public static string comment_approvedColumn{
			      get{
        			return "comment_approved";
      			}
		    }
           
            public IColumn comment_agent{
                get{
                    return this.GetColumn("comment_agent");
                }
            }
            				
   			public static string comment_agentColumn{
			      get{
        			return "comment_agent";
      			}
		    }
           
            public IColumn comment_type{
                get{
                    return this.GetColumn("comment_type");
                }
            }
            				
   			public static string comment_typeColumn{
			      get{
        			return "comment_type";
      			}
		    }
           
            public IColumn comment_parent{
                get{
                    return this.GetColumn("comment_parent");
                }
            }
            				
   			public static string comment_parentColumn{
			      get{
        			return "comment_parent";
      			}
		    }
           
            public IColumn user_id{
                get{
                    return this.GetColumn("user_id");
                }
            }
            				
   			public static string user_idColumn{
			      get{
        			return "user_id";
      			}
		    }
           
            public IColumn comment_reply_ID{
                get{
                    return this.GetColumn("comment_reply_ID");
                }
            }
            				
   			public static string comment_reply_IDColumn{
			      get{
        			return "comment_reply_ID";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: wp_links
        /// Primary Key: link_id
        /// </summary>

        public class wp_linksTable: DatabaseTable {
            
            public wp_linksTable(IDataProvider provider):base("wp_links",provider){
                ClassName = "wp_link";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("link_id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("link_url", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 85
                });

                Columns.Add(new DatabaseColumn("link_name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 85
                });

                Columns.Add(new DatabaseColumn("link_image", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 85
                });

                Columns.Add(new DatabaseColumn("link_target", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8
                });

                Columns.Add(new DatabaseColumn("link_category", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("link_description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 85
                });

                Columns.Add(new DatabaseColumn("link_visible", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6
                });

                Columns.Add(new DatabaseColumn("link_owner", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("link_rating", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("link_updated", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("link_rel", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 85
                });

                Columns.Add(new DatabaseColumn("link_notes", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16777215
                });

                Columns.Add(new DatabaseColumn("link_rss", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 85
                });
                    
                
                
            }
            
            public IColumn link_id{
                get{
                    return this.GetColumn("link_id");
                }
            }
            				
   			public static string link_idColumn{
			      get{
        			return "link_id";
      			}
		    }
           
            public IColumn link_url{
                get{
                    return this.GetColumn("link_url");
                }
            }
            				
   			public static string link_urlColumn{
			      get{
        			return "link_url";
      			}
		    }
           
            public IColumn link_name{
                get{
                    return this.GetColumn("link_name");
                }
            }
            				
   			public static string link_nameColumn{
			      get{
        			return "link_name";
      			}
		    }
           
            public IColumn link_image{
                get{
                    return this.GetColumn("link_image");
                }
            }
            				
   			public static string link_imageColumn{
			      get{
        			return "link_image";
      			}
		    }
           
            public IColumn link_target{
                get{
                    return this.GetColumn("link_target");
                }
            }
            				
   			public static string link_targetColumn{
			      get{
        			return "link_target";
      			}
		    }
           
            public IColumn link_category{
                get{
                    return this.GetColumn("link_category");
                }
            }
            				
   			public static string link_categoryColumn{
			      get{
        			return "link_category";
      			}
		    }
           
            public IColumn link_description{
                get{
                    return this.GetColumn("link_description");
                }
            }
            				
   			public static string link_descriptionColumn{
			      get{
        			return "link_description";
      			}
		    }
           
            public IColumn link_visible{
                get{
                    return this.GetColumn("link_visible");
                }
            }
            				
   			public static string link_visibleColumn{
			      get{
        			return "link_visible";
      			}
		    }
           
            public IColumn link_owner{
                get{
                    return this.GetColumn("link_owner");
                }
            }
            				
   			public static string link_ownerColumn{
			      get{
        			return "link_owner";
      			}
		    }
           
            public IColumn link_rating{
                get{
                    return this.GetColumn("link_rating");
                }
            }
            				
   			public static string link_ratingColumn{
			      get{
        			return "link_rating";
      			}
		    }
           
            public IColumn link_updated{
                get{
                    return this.GetColumn("link_updated");
                }
            }
            				
   			public static string link_updatedColumn{
			      get{
        			return "link_updated";
      			}
		    }
           
            public IColumn link_rel{
                get{
                    return this.GetColumn("link_rel");
                }
            }
            				
   			public static string link_relColumn{
			      get{
        			return "link_rel";
      			}
		    }
           
            public IColumn link_notes{
                get{
                    return this.GetColumn("link_notes");
                }
            }
            				
   			public static string link_notesColumn{
			      get{
        			return "link_notes";
      			}
		    }
           
            public IColumn link_rss{
                get{
                    return this.GetColumn("link_rss");
                }
            }
            				
   			public static string link_rssColumn{
			      get{
        			return "link_rss";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: wp_options
        /// Primary Key: option_name
        /// </summary>

        public class wp_optionsTable: DatabaseTable {
            
            public wp_optionsTable(IDataProvider provider):base("wp_options",provider){
                ClassName = "wp_option";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("option_id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("blog_id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("option_name", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 21
                });

                Columns.Add(new DatabaseColumn("option_value", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("autoload", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6
                });
                    
                
                
            }
            
            public IColumn option_id{
                get{
                    return this.GetColumn("option_id");
                }
            }
            				
   			public static string option_idColumn{
			      get{
        			return "option_id";
      			}
		    }
           
            public IColumn blog_id{
                get{
                    return this.GetColumn("blog_id");
                }
            }
            				
   			public static string blog_idColumn{
			      get{
        			return "blog_id";
      			}
		    }
           
            public IColumn option_name{
                get{
                    return this.GetColumn("option_name");
                }
            }
            				
   			public static string option_nameColumn{
			      get{
        			return "option_name";
      			}
		    }
           
            public IColumn option_value{
                get{
                    return this.GetColumn("option_value");
                }
            }
            				
   			public static string option_valueColumn{
			      get{
        			return "option_value";
      			}
		    }
           
            public IColumn autoload{
                get{
                    return this.GetColumn("autoload");
                }
            }
            				
   			public static string autoloadColumn{
			      get{
        			return "autoload";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: wp_postmeta
        /// Primary Key: meta_id
        /// </summary>

        public class wp_postmetaTable: DatabaseTable {
            
            public wp_postmetaTable(IDataProvider provider):base("wp_postmeta",provider){
                ClassName = "wp_postmetum";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("meta_id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("post_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("meta_key", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 85
                });

                Columns.Add(new DatabaseColumn("meta_value", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn meta_id{
                get{
                    return this.GetColumn("meta_id");
                }
            }
            				
   			public static string meta_idColumn{
			      get{
        			return "meta_id";
      			}
		    }
           
            public IColumn post_id{
                get{
                    return this.GetColumn("post_id");
                }
            }
            				
   			public static string post_idColumn{
			      get{
        			return "post_id";
      			}
		    }
           
            public IColumn meta_key{
                get{
                    return this.GetColumn("meta_key");
                }
            }
            				
   			public static string meta_keyColumn{
			      get{
        			return "meta_key";
      			}
		    }
           
            public IColumn meta_value{
                get{
                    return this.GetColumn("meta_value");
                }
            }
            				
   			public static string meta_valueColumn{
			      get{
        			return "meta_value";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: wp_posts
        /// Primary Key: ID
        /// </summary>

        public class wp_postsTable: DatabaseTable {
            
            public wp_postsTable(IDataProvider provider):base("wp_posts",provider){
                ClassName = "wp_post";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("post_author", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("post_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("post_date_gmt", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("post_content", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("post_title", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });

                Columns.Add(new DatabaseColumn("post_category", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("post_excerpt", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });

                Columns.Add(new DatabaseColumn("post_status", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6
                });

                Columns.Add(new DatabaseColumn("comment_status", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6
                });

                Columns.Add(new DatabaseColumn("ping_status", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6
                });

                Columns.Add(new DatabaseColumn("post_password", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6
                });

                Columns.Add(new DatabaseColumn("post_name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 66
                });

                Columns.Add(new DatabaseColumn("to_ping", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });

                Columns.Add(new DatabaseColumn("pinged", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });

                Columns.Add(new DatabaseColumn("post_modified", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("post_modified_gmt", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("post_content_filtered", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });

                Columns.Add(new DatabaseColumn("post_parent", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("guid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 85
                });

                Columns.Add(new DatabaseColumn("menu_order", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("post_type", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6
                });

                Columns.Add(new DatabaseColumn("post_mime_type", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 33
                });

                Columns.Add(new DatabaseColumn("comment_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn ID{
                get{
                    return this.GetColumn("ID");
                }
            }
            				
   			public static string IDColumn{
			      get{
        			return "ID";
      			}
		    }
           
            public IColumn post_author{
                get{
                    return this.GetColumn("post_author");
                }
            }
            				
   			public static string post_authorColumn{
			      get{
        			return "post_author";
      			}
		    }
           
            public IColumn post_date{
                get{
                    return this.GetColumn("post_date");
                }
            }
            				
   			public static string post_dateColumn{
			      get{
        			return "post_date";
      			}
		    }
           
            public IColumn post_date_gmt{
                get{
                    return this.GetColumn("post_date_gmt");
                }
            }
            				
   			public static string post_date_gmtColumn{
			      get{
        			return "post_date_gmt";
      			}
		    }
           
            public IColumn post_content{
                get{
                    return this.GetColumn("post_content");
                }
            }
            				
   			public static string post_contentColumn{
			      get{
        			return "post_content";
      			}
		    }
           
            public IColumn post_title{
                get{
                    return this.GetColumn("post_title");
                }
            }
            				
   			public static string post_titleColumn{
			      get{
        			return "post_title";
      			}
		    }
           
            public IColumn post_category{
                get{
                    return this.GetColumn("post_category");
                }
            }
            				
   			public static string post_categoryColumn{
			      get{
        			return "post_category";
      			}
		    }
           
            public IColumn post_excerpt{
                get{
                    return this.GetColumn("post_excerpt");
                }
            }
            				
   			public static string post_excerptColumn{
			      get{
        			return "post_excerpt";
      			}
		    }
           
            public IColumn post_status{
                get{
                    return this.GetColumn("post_status");
                }
            }
            				
   			public static string post_statusColumn{
			      get{
        			return "post_status";
      			}
		    }
           
            public IColumn comment_status{
                get{
                    return this.GetColumn("comment_status");
                }
            }
            				
   			public static string comment_statusColumn{
			      get{
        			return "comment_status";
      			}
		    }
           
            public IColumn ping_status{
                get{
                    return this.GetColumn("ping_status");
                }
            }
            				
   			public static string ping_statusColumn{
			      get{
        			return "ping_status";
      			}
		    }
           
            public IColumn post_password{
                get{
                    return this.GetColumn("post_password");
                }
            }
            				
   			public static string post_passwordColumn{
			      get{
        			return "post_password";
      			}
		    }
           
            public IColumn post_name{
                get{
                    return this.GetColumn("post_name");
                }
            }
            				
   			public static string post_nameColumn{
			      get{
        			return "post_name";
      			}
		    }
           
            public IColumn to_ping{
                get{
                    return this.GetColumn("to_ping");
                }
            }
            				
   			public static string to_pingColumn{
			      get{
        			return "to_ping";
      			}
		    }
           
            public IColumn pinged{
                get{
                    return this.GetColumn("pinged");
                }
            }
            				
   			public static string pingedColumn{
			      get{
        			return "pinged";
      			}
		    }
           
            public IColumn post_modified{
                get{
                    return this.GetColumn("post_modified");
                }
            }
            				
   			public static string post_modifiedColumn{
			      get{
        			return "post_modified";
      			}
		    }
           
            public IColumn post_modified_gmt{
                get{
                    return this.GetColumn("post_modified_gmt");
                }
            }
            				
   			public static string post_modified_gmtColumn{
			      get{
        			return "post_modified_gmt";
      			}
		    }
           
            public IColumn post_content_filtered{
                get{
                    return this.GetColumn("post_content_filtered");
                }
            }
            				
   			public static string post_content_filteredColumn{
			      get{
        			return "post_content_filtered";
      			}
		    }
           
            public IColumn post_parent{
                get{
                    return this.GetColumn("post_parent");
                }
            }
            				
   			public static string post_parentColumn{
			      get{
        			return "post_parent";
      			}
		    }
           
            public IColumn guid{
                get{
                    return this.GetColumn("guid");
                }
            }
            				
   			public static string guidColumn{
			      get{
        			return "guid";
      			}
		    }
           
            public IColumn menu_order{
                get{
                    return this.GetColumn("menu_order");
                }
            }
            				
   			public static string menu_orderColumn{
			      get{
        			return "menu_order";
      			}
		    }
           
            public IColumn post_type{
                get{
                    return this.GetColumn("post_type");
                }
            }
            				
   			public static string post_typeColumn{
			      get{
        			return "post_type";
      			}
		    }
           
            public IColumn post_mime_type{
                get{
                    return this.GetColumn("post_mime_type");
                }
            }
            				
   			public static string post_mime_typeColumn{
			      get{
        			return "post_mime_type";
      			}
		    }
           
            public IColumn comment_count{
                get{
                    return this.GetColumn("comment_count");
                }
            }
            				
   			public static string comment_countColumn{
			      get{
        			return "comment_count";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: wp_term_relationships
        /// Primary Key: term_taxonomy_id
        /// </summary>

        public class wp_term_relationshipsTable: DatabaseTable {
            
            public wp_term_relationshipsTable(IDataProvider provider):base("wp_term_relationships",provider){
                ClassName = "wp_term_relationship";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("object_id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("term_taxonomy_id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("term_order", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn object_id{
                get{
                    return this.GetColumn("object_id");
                }
            }
            				
   			public static string object_idColumn{
			      get{
        			return "object_id";
      			}
		    }
           
            public IColumn term_taxonomy_id{
                get{
                    return this.GetColumn("term_taxonomy_id");
                }
            }
            				
   			public static string term_taxonomy_idColumn{
			      get{
        			return "term_taxonomy_id";
      			}
		    }
           
            public IColumn term_order{
                get{
                    return this.GetColumn("term_order");
                }
            }
            				
   			public static string term_orderColumn{
			      get{
        			return "term_order";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: wp_term_taxonomy
        /// Primary Key: term_taxonomy_id
        /// </summary>

        public class wp_term_taxonomyTable: DatabaseTable {
            
            public wp_term_taxonomyTable(IDataProvider provider):base("wp_term_taxonomy",provider){
                ClassName = "wp_term_taxonomy";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("term_taxonomy_id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("term_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("taxonomy", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("parent", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn term_taxonomy_id{
                get{
                    return this.GetColumn("term_taxonomy_id");
                }
            }
            				
   			public static string term_taxonomy_idColumn{
			      get{
        			return "term_taxonomy_id";
      			}
		    }
           
            public IColumn term_id{
                get{
                    return this.GetColumn("term_id");
                }
            }
            				
   			public static string term_idColumn{
			      get{
        			return "term_id";
      			}
		    }
           
            public IColumn taxonomy{
                get{
                    return this.GetColumn("taxonomy");
                }
            }
            				
   			public static string taxonomyColumn{
			      get{
        			return "taxonomy";
      			}
		    }
           
            public IColumn description{
                get{
                    return this.GetColumn("description");
                }
            }
            				
   			public static string descriptionColumn{
			      get{
        			return "description";
      			}
		    }
           
            public IColumn parent{
                get{
                    return this.GetColumn("parent");
                }
            }
            				
   			public static string parentColumn{
			      get{
        			return "parent";
      			}
		    }
           
            public IColumn count{
                get{
                    return this.GetColumn("count");
                }
            }
            				
   			public static string countColumn{
			      get{
        			return "count";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: wp_terms
        /// Primary Key: term_id
        /// </summary>

        public class wp_termsTable: DatabaseTable {
            
            public wp_termsTable(IDataProvider provider):base("wp_terms",provider){
                ClassName = "wp_term";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("term_id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 66
                });

                Columns.Add(new DatabaseColumn("slug", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 66
                });

                Columns.Add(new DatabaseColumn("term_group", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn term_id{
                get{
                    return this.GetColumn("term_id");
                }
            }
            				
   			public static string term_idColumn{
			      get{
        			return "term_id";
      			}
		    }
           
            public IColumn name{
                get{
                    return this.GetColumn("name");
                }
            }
            				
   			public static string nameColumn{
			      get{
        			return "name";
      			}
		    }
           
            public IColumn slug{
                get{
                    return this.GetColumn("slug");
                }
            }
            				
   			public static string slugColumn{
			      get{
        			return "slug";
      			}
		    }
           
            public IColumn term_group{
                get{
                    return this.GetColumn("term_group");
                }
            }
            				
   			public static string term_groupColumn{
			      get{
        			return "term_group";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: wp_usermeta
        /// Primary Key: umeta_id
        /// </summary>

        public class wp_usermetaTable: DatabaseTable {
            
            public wp_usermetaTable(IDataProvider provider):base("wp_usermeta",provider){
                ClassName = "wp_usermetum";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("umeta_id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("user_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("meta_key", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 85
                });

                Columns.Add(new DatabaseColumn("meta_value", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn umeta_id{
                get{
                    return this.GetColumn("umeta_id");
                }
            }
            				
   			public static string umeta_idColumn{
			      get{
        			return "umeta_id";
      			}
		    }
           
            public IColumn user_id{
                get{
                    return this.GetColumn("user_id");
                }
            }
            				
   			public static string user_idColumn{
			      get{
        			return "user_id";
      			}
		    }
           
            public IColumn meta_key{
                get{
                    return this.GetColumn("meta_key");
                }
            }
            				
   			public static string meta_keyColumn{
			      get{
        			return "meta_key";
      			}
		    }
           
            public IColumn meta_value{
                get{
                    return this.GetColumn("meta_value");
                }
            }
            				
   			public static string meta_valueColumn{
			      get{
        			return "meta_value";
      			}
		    }
           
                    
        }
        
        /// <summary>
        /// Table: wp_users
        /// Primary Key: ID
        /// </summary>

        public class wp_usersTable: DatabaseTable {
            
            public wp_usersTable(IDataProvider provider):base("wp_users",provider){
                ClassName = "wp_user";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.UInt64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("user_login", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("user_pass", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 21
                });

                Columns.Add(new DatabaseColumn("user_nicename", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16
                });

                Columns.Add(new DatabaseColumn("user_email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 33
                });

                Columns.Add(new DatabaseColumn("user_url", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 33
                });

                Columns.Add(new DatabaseColumn("user_registered", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("user_activation_key", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("user_status", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("display_name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 83
                });
                    
                
                
            }
            
            public IColumn ID{
                get{
                    return this.GetColumn("ID");
                }
            }
            				
   			public static string IDColumn{
			      get{
        			return "ID";
      			}
		    }
           
            public IColumn user_login{
                get{
                    return this.GetColumn("user_login");
                }
            }
            				
   			public static string user_loginColumn{
			      get{
        			return "user_login";
      			}
		    }
           
            public IColumn user_pass{
                get{
                    return this.GetColumn("user_pass");
                }
            }
            				
   			public static string user_passColumn{
			      get{
        			return "user_pass";
      			}
		    }
           
            public IColumn user_nicename{
                get{
                    return this.GetColumn("user_nicename");
                }
            }
            				
   			public static string user_nicenameColumn{
			      get{
        			return "user_nicename";
      			}
		    }
           
            public IColumn user_email{
                get{
                    return this.GetColumn("user_email");
                }
            }
            				
   			public static string user_emailColumn{
			      get{
        			return "user_email";
      			}
		    }
           
            public IColumn user_url{
                get{
                    return this.GetColumn("user_url");
                }
            }
            				
   			public static string user_urlColumn{
			      get{
        			return "user_url";
      			}
		    }
           
            public IColumn user_registered{
                get{
                    return this.GetColumn("user_registered");
                }
            }
            				
   			public static string user_registeredColumn{
			      get{
        			return "user_registered";
      			}
		    }
           
            public IColumn user_activation_key{
                get{
                    return this.GetColumn("user_activation_key");
                }
            }
            				
   			public static string user_activation_keyColumn{
			      get{
        			return "user_activation_key";
      			}
		    }
           
            public IColumn user_status{
                get{
                    return this.GetColumn("user_status");
                }
            }
            				
   			public static string user_statusColumn{
			      get{
        			return "user_status";
      			}
		    }
           
            public IColumn display_name{
                get{
                    return this.GetColumn("display_name");
                }
            }
            				
   			public static string display_nameColumn{
			      get{
        			return "display_name";
      			}
		    }
           
                    
        }
        
}