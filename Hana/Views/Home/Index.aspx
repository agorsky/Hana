<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--START LEFT SIDE-->
    
    <div id="feature" class="column span-15 colborder">
        <!--BEGIN FEATURED POST-->
        <h3>
            <a href="http://localhost/boppy/?p=1" rel="bookmark" title="Permanent Link to Hello world!"
                class="title">Hello world!</a><span class="meta_align_right">Aug 23, 2009 | by <a
                    href="http://localhost/boppy/?author=1" title="Posts by admin">admin</a> | <a href="http://localhost/boppy/?p=1"
                        title="Hello world!">Read</a> | <a href="http://localhost/boppy/?p=1#comments" title="Comment on Hello world!">
                            2 Comments</a></span></h3>
        <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi aliquam imperdiet ligula. Mauris interdum tincidunt gravida. Pellentesque elementum massa sit amet diam ultricies bibendum. Nulla commodo, purus fringilla dictum laoreet, tellus neque tincidunt libero, sit amet fermentum velit enim a nulla. Maecenas id enim sem. Nunc at tellus et sem bibendum convallis ac nec lorem. Suspendisse potenti. Phasellus non urna nec augue malesuada interdum vitae sed nibh. </p>
    </div>
    <!--END FEATURED POST-->
    
    <!-- BEGIN THREE AT RIGHT -->
    <div class="column span-8 last">
        <div id="home_right">
            <h3>Previously Featured</h3>
                <!--END THREE POSTS AT RIGHT-->
                <!-- ABOUT BOX -->
            <div class="box">
                <h6>
                    About
                </h6>
                <p class="small">
                </p>
            </div>
            <!-- EXTRA BOX -->
            <div class="box">
                <h6>
                    Advertise with
                </h6>
                <h1>ADVERTISE</h1>
            </div>
        </div>
    </div>
    
    <hr></hr>
    
    <!-- BOTTOM LEFT FOUR CATEGORY LISTINGS -->
    <div class="column span-4 colborder">
        <div class="five_posts">
            <h3>
                <a href="http://localhost/boppy/?cat=3">&raquo;</a></h3>
            <hr></hr>
        </div>
    </div>
    <div class="column span-4 colborder">
        <div class="five_posts">
            <h3>
                <a href="http://localhost/boppy/?cat=4">&raquo;</a></h3>
            <hr></hr>
        </div>
    </div>
    <div class="column span-4 colborder">
        <div class="five_posts">
            <h3>
                <a href="http://localhost/boppy/?cat=5">&raquo;</a></h3>
            <hr></hr>
        </div>
    </div>
    <div class="column span-4 colborder">
        <div class="five_posts">
            <h3>
                <a href="http://localhost/boppy/?cat=6">&raquo;</a></h3>
            <hr></hr>
        </div>
    </div>
    
    <!-- LAST CATEGORY LISTING - NEEDED TO END CSS COLUMNS -->
    <div class="column span-4 last">
        <div class="five_posts">
            <h3>
                <a href="http://localhost/boppy/?cat=7">&raquo;</a></h3>
            <hr></hr>
        </div>
    </div>
    
    <hr></hr>
    <div class="column span-7 colborder">
    </div>
    <div class="column span-7 colborder">
    </div>
    <div class="column span-8 last">
    </div>
</asp:Content>
