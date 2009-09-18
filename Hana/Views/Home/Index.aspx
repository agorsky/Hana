<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="http://www.google.com/jsapi?key=ABQIAAAAXDxCekvc3BRLZSw2AaTpVhRk2KHjkhDr-AinWwGiTLTg4BpP1RQkA87A7cGo2bXtxIFVC9ui4LIlSw"></script>
  <script src="http://www.google.com/uds/solutions/dynamicfeed/gfdynamicfeedcontrol.js"
    type="text/javascript"></script>
  <style type="text/css">
    @import url("/content/css/newsfeed.css");
  </style>
  <script type="text/javascript">
      function LoadDynamicFeedControl() {
          var feeds = [
	        { title: 'Twitter',
	            url: 'http://twitter.com/statuses/user_timeline/5721912.rss'
	        }
            ];
          var options = {
 
              stacked: true,
              horizontal: false,
              numResults: 5
          }
          new GFdynamicFeedControl(feeds, 'twitter', options);
      }
      // Load the feeds API and set the onload callback.
      google.load('feeds', '1');
      google.setOnLoadCallback(LoadDynamicFeedControl);
  </script>

    <!--START LEFT SIDE-->
    <script type="text/javascript" src="http://v6.flickrshow.com/scripts/"></script>
    <div id="feature" class="column span-15 colborder">
        <!--BEGIN FEATURED POST-->
        <h1>
            <a href="http://localhost/boppy/?p=1" rel="bookmark" title="Permanent Link to Hello world!"
                class="title">Lorem ipsum dolor sit amet</a></h1>
        <p>
            <b>Oct 05, 2008</b> - Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi aliquam imperdiet ligula. Mauris interdum tincidunt gravida. Pellentesque elementum massa sit amet diam ultricies bibendum. Nulla commodo, purus fringilla dictum laoreet, tellus neque tincidunt libero, sit amet fermentum velit enim a nulla. Maecenas id enim sem. Nunc at tellus et sem bibendum convallis ac nec lorem. Suspendisse potenti. Phasellus non urna nec augue malesuada interdum vitae sed nibh. </p>
    
            <p class="postmetadata"> <a href="http://graphpaperpress.com/demo/modularity/category/arts/" title="View all posts in Arts" rel="category tag">Arts</a>,  <a href="http://graphpaperpress.com/demo/modularity/category/culture/" title="View all posts in Culture" rel="category tag">Culture</a>  | <a href="http://graphpaperpress.com/demo/modularity/2008/10/05/eighth-test-post/#respond" title="Comment on Eighth Test Post">Leave A Comment &#187;</a>  </p> 

        <h1>
            <a href="http://localhost/boppy/?p=1" rel="bookmark" title="Permanent Link to Hello world!"
                class="title">Morbi aliquam imperdiet ligula</a></h1>
        <p>
            <b>Oct 01, 2008</b> - Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi aliquam imperdiet ligula. Mauris interdum tincidunt gravida. Pellentesque elementum massa sit amet diam ultricies bibendum. Nulla commodo, purus fringilla dictum laoreet, tellus neque tincidunt libero, sit amet fermentum velit enim a nulla. Maecenas id enim sem. Nunc at tellus et sem bibendum convallis ac nec lorem. Suspendisse potenti. Phasellus non urna nec augue malesuada interdum vitae sed nibh. </p>
    
            <p class="postmetadata"> <a href="http://graphpaperpress.com/demo/modularity/category/arts/" title="View all posts in Arts" rel="category tag">Arts</a>,  <a href="http://graphpaperpress.com/demo/modularity/category/culture/" title="View all posts in Culture" rel="category tag">Culture</a>  | <a href="http://graphpaperpress.com/demo/modularity/2008/10/05/eighth-test-post/#respond" title="Comment on Eighth Test Post">Leave A Comment &#187;</a>  </p> 


    
    </div>
    
    <!-- BEGIN THREE AT RIGHT -->
    <div class="column span-8 last">
        <div id="home_right">
            <h3>Twitter</h3>
            <div id="twitter" name="twitter"></div>
           <h3>Pix</h3>
           <iframe align="center" src="http://www.flickr.com/slideShow/index.gne?user_id=91469966@N00&" frameBorder="0" width="300" scrolling="no" height="250"></iframe>
       </div>
    </div>
    
    <hr></hr>
    
    <!-- BOTTOM LEFT FOUR CATEGORY LISTINGS -->
    <div class="column span-7 colborder">
        <div class="five_posts">
                <h3><a href="http://localhost/boppy/?cat=7">&raquo; SubSonic</a></h3>
               <h6><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/eighth-test-post/" rel="bookmark" title="Permanent Link to Eighth Test Post">Eighth Test Post</a></h6> 
                <p class="byline">Oct 05, 2008 | <a href="http://graphpaperpress.com/demo/modularity/2008/10/05/eighth-test-post/#respond" title="Comment on Eighth Test Post">Discuss</a></p> 
                <p>Mauris tristique egestas metus. Etiam interdum. Maecenas pharetra scelerisque nibh! Aliquam erat vol</p> 
                <h6><a href="http://graphpaperpress.com/demo/modularity/category/arts/">More SubSonic</a></h6> 
                <ul> 
                <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/sixth-test-post/" rel="bookmark" title="Permanent Link to Sixth Test Post" class="title">Sixth Test Post</a></li> 
                <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/fifth-test-post/" rel="bookmark" title="Permanent Link to Fifth Test Post" class="title">Fifth Test Post</a></li> 
                <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/fourth-test-post/" rel="bookmark" title="Permanent Link to Fourth Test Post" class="title">Fourth Test Post</a></li> 
                <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/third-test-post/" rel="bookmark" title="Permanent Link to Third Test Post" class="title">Third Test Post</a></li> 
                <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/second-test-post/" rel="bookmark" title="Permanent Link to Second Test Post" class="title">Second Test Post</a></li> 
            </ul> 
                
        </div>
    </div>
    <div class="column span-7 colborder">
        <div class="five_posts">
                   <h3><a href="http://localhost/boppy/?cat=7">&raquo; Opinions</a></h3>

                    			
                    <h6><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/tenth-test-post/" rel="bookmark" title="Permanent Link to Tenth Test Post">Tenth Test Post</a></h6> 
                    <p class="byline">Oct 05, 2008 | <a href="http://graphpaperpress.com/demo/modularity/2008/10/05/tenth-test-post/#comments" title="Comment on Tenth Test Post">4 Comments</a></p> 
                    <p>Nulla faucibus erat non pede. Pellentesque imperdiet, diam ut elementum aliquet, mi felis placerat r</p> 
                    <h6><a href="http://graphpaperpress.com/demo/modularity/category/culture/">More Opinions</a></h6> 
                    <ul> 
                    <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/ninth-test-post/" rel="bookmark" title="Permanent Link to Ninth Test Post" class="title">Ninth Test Post</a></li> 
                    <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/eighth-test-post/" rel="bookmark" title="Permanent Link to Eighth Test Post" class="title">Eighth Test Post</a></li> 
                    <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/seventh-test-post/" rel="bookmark" title="Permanent Link to Seventh Test Post" class="title">Seventh Test Post</a></li> 
                    <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/sixth-test-post/" rel="bookmark" title="Permanent Link to Sixth Test Post" class="title">Sixth Test Post</a></li> 
                    <li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/fifth-test-post/" rel="bookmark" title="Permanent Link to Fifth Test Post" class="title">Fifth Test Post</a></li> 
                    </ul> 



        </div>
    </div>
    
    <!-- LAST CATEGORY LISTING - NEEDED TO END CSS COLUMNS -->
    <div class="column span-7 last">
        <div class="five_posts">
                   <h3><a href="http://localhost/boppy/?cat=7">&raquo; Favorites</a></h3>
<h6><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/sixth-test-post/" rel="bookmark" title="Permanent Link to Sixth Test Post">Sixth Test Post</a></h6> 
<p class="byline">Oct 05, 2008 | <a href="http://graphpaperpress.com/demo/modularity/2008/10/05/sixth-test-post/#respond" title="Comment on Sixth Test Post">Discuss</a></p> 
<p>Nulla faucibus erat non pede. Pellentesque imperdiet, diam ut elementum aliquet, mi felis placerat r</p> 
<h6><a href="http://graphpaperpress.com/demo/modularity/category/music/">More Favorites</a></h6> 
<ul> 
<li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/fifth-test-post/" rel="bookmark" title="Permanent Link to Fifth Test Post" class="title">Fifth Test Post</a></li> 
<li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/fourth-test-post/" rel="bookmark" title="Permanent Link to Fourth Test Post" class="title">Fourth Test Post</a></li> 
<li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/third-test-post/" rel="bookmark" title="Permanent Link to Third Test Post" class="title">Third Test Post</a></li> 
<li><a href="http://graphpaperpress.com/demo/modularity/2008/10/05/second-test-post/" rel="bookmark" title="Permanent Link to Second Test Post" class="title">Second Test Post</a></li> 
<li><a href="http://graphpaperpress.com/demo/modularity/2008/10/03/first-test-pos/" rel="bookmark" title="Permanent Link to First Test Post" class="title">First Test Post</a></li> 
</ul>      
            
        </div>
    </div>
</asp:Content>
