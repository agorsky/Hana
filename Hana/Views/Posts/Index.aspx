<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Rob Conery: Lorem ipsum dolor sit amet
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="column span-16 colborder">

    <h2>Lorem ipsum dolor sit amet</h2>
     <p>
    <b>Oct 01, 2008</b> - Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ut mauris nec ipsum volutpat hendrerit. Etiam mollis ultrices enim nec pulvinar. Vestibulum vitae eros ligula, eu aliquet lorem. Proin quis turpis vitae mauris feugiat pretium. Maecenas vestibulum blandit est ac faucibus. Duis diam nulla, eleifend id aliquet porttitor, aliquet et diam. Nunc lorem dui, dictum non commodo ut, luctus sit amet elit. Nulla malesuada, dolor eu feugiat viverra, ipsum nisl iaculis sapien, vel hendrerit lectus est eget nulla. Sed laoreet ultrices lacus, in porta ligula facilisis eget. Integer interdum euismod ante eu iaculis. Curabitur nec arcu vel nulla molestie elementum. Curabitur vitae pharetra diam. Ut fringilla tortor sed lectus ultricies non sagittis libero posuere. Fusce quis malesuada lorem. Integer vulputate sodales elit vitae tempus.
    </p>
    <p>
    Suspendisse justo erat, vulputate a consectetur in, sodales vel diam. Vivamus volutpat ipsum elit, at vestibulum nibh. Morbi aliquam ante at massa venenatis in consequat nunc ultricies. Nulla rhoncus justo a arcu mattis eu sodales tellus aliquet. Morbi ligula odio, dictum quis bibendum quis, dignissim nec lectus. Duis semper, mauris id luctus convallis, lectus ligula mattis augue, at aliquet purus orci nec metus. Suspendisse mollis scelerisque dolor ut placerat. Vivamus elementum posuere lectus nec vehicula. Fusce non mi et est mollis semper. Nulla hendrerit tortor ut ipsum mattis vel aliquet lectus sagittis. Cras accumsan elementum massa, eu condimentum nunc volutpat sit amet. Duis cursus venenatis ante pulvinar dignissim. Proin bibendum volutpat nisi, eu vestibulum mi tincidunt sit amet. Mauris laoreet magna nec elit scelerisque ac dignissim risus sagittis. Ut tempor, felis ut bibendum placerat, lectus orci semper eros, nec aliquam mi enim at dui. Pellentesque eu condimentum ligula. Duis eget tellus odio, sit amet suscipit felis. Aenean nisl arcu, mattis ut suscipit ac, faucibus quis lorem. Proin tempus lectus non tortor aliquet convallis. Cras consequat ante at neque consectetur et fringilla neque aliquam.
     </p>
     <p>
    Donec convallis, nunc faucibus tempus vestibulum, lacus lorem pulvinar mi, tempor sagittis leo urna et enim. Quisque luctus hendrerit lobortis. Pellentesque nisi ligula, consequat sit amet convallis et, iaculis ac orci. Cras dapibus, urna at consequat porta, magna leo lacinia nibh, et auctor sapien tellus vitae lacus. Cras eu leo lectus. Pellentesque iaculis feugiat sem, in vehicula sapien venenatis sed. Vestibulum augue justo, ullamcorper eget luctus quis, blandit sit amet sem. Curabitur sed mauris sit amet dolor adipiscing condimentum. Sed scelerisque viverra congue. Curabitur vitae nisi tortor, non aliquet diam. Praesent eget nibh felis, a tristique orci. Praesent molestie quam a eros tincidunt faucibus. Duis a justo nec nisl dictum molestie non sit amet ante. Nulla sollicitudin enim nec mauris cursus at lobortis purus fringilla. Quisque non aliquet turpis. Duis eget justo ante. Sed hendrerit tempor ultricies.
    </p>

</div>
<div class="column span-7 last">
    <p>
    <div id="adzerk">
        <div id="adzerk_ad_div">
            <script type="text/javascript" src="http://engine.theloungenet.com/Server/DOTNET/RCONERY/VERT"></script>
        </div>
        <p id="adzerk_by">
            <a href='http://theloungenet.com'>Ads by The Lounge</a>
        </p>
    </div>
    </p>
    <p>
    <h3>Related</h3>
     <p>
        <ul>
        <li>Lorem ipsum dolor sit amet</li>
        <li>Lorem ipsum dolor sit amet</li>
        <li>Lorem ipsum dolor sit amet</li>
        <li>Lorem ipsum dolor sit amet</li>
        </ul>
     </p>
    
</div>

<hr />

<div id="comments" class="column span-24 last">

<%for (int i = 0; i <= 10; i++) { %>
 <div class="column comment">
    <div class="column  span-5" style="text-align:center">
        <div>
            Gravatar
        </div>
    </div>
    <div class="column span-13 append-2">
         Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ut mauris nec ipsum volutpat hendrerit. Etiam mollis ultrices enim nec pulvinar. Vestibulum vitae eros ligula, eu aliquet lorem. Proin quis turpis vitae mauris feugiat pretium. Maecenas vestibulum blandit est ac faucibus
    </div>
</div>
<%} %>
<div class="column last"></div>
</div>

    <div class="column prepend-1 span-15">
        <h2 id="respond">Tell 'em</h2>
        <form action="# method="post" id="commentform">
        <p>
            <input type="text" name="author" id="author" value="" size="22" tabindex="1" />
            <label for="author">
                <small>Name (required)</small></label></p>
        <p>
            <input type="text" name="email" id="email" value="" size="22" tabindex="2" />
            <label for="email">
                <small>Email (will not be published) (required)</small></label></p>
        <p>
            <input type="text" name="url" id="url" value="" size="22" tabindex="3" />
            <label for="url">
                <small>Website</small></label></p>
        <!--<p><small><strong>XHTML:</strong> You can use these tags: <code>&lt;a href=&quot;&quot; title=&quot;&quot;&gt; &lt;abbr title=&quot;&quot;&gt; &lt;acronym title=&quot;&quot;&gt; &lt;b&gt; &lt;blockquote cite=&quot;&quot;&gt; &lt;cite&gt; &lt;code&gt; &lt;del datetime=&quot;&quot;&gt; &lt;em&gt; &lt;i&gt; &lt;q cite=&quot;&quot;&gt; &lt;strike&gt; &lt;strong&gt; </code></small></p>-->
        <p>
            <textarea name="comment" id="comment" cols="10" rows="20" tabindex="4"></textarea></p>
        <p>
            <input name="submit" type="submit" id="submit" tabindex="5" value="Submit Comment" />
            <input type="hidden" name="comment_post_ID" value="1" />
        </p>
        </form>
    </div>



</asp:Content>
