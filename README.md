<h1>Read Later</h1>
<p> I Have finnished the assignment. Some of the things are not working property because I don't have no more time to debug it.</p>
<p> I want to mention that I don't have experience with Razor pages so I did not create views for booking part. If thats the job requirement I will master it in very short time</p>
<p>I want to mention that for the past 3 years I have been working with Angular 70% of the time and on the backend I have been working 30% but in my free time I watch courese for .Net and I would like to work with .net from now on</p>
<p> For the optional tasks I have choose to do the first one and I will explain in this file how I can achieve the second and the third one.</p>
<h2>Create Web Widget</h2>
<ol>
  <li>Create javascript file. In the file we can set HTML elements and we will do an API call to retrieve Bookmarks.</li>
  <li>We need to set CORS policy to 'AllowAll'.</li>
  <li>We need to deploy the API and the javascript file.</li>
    <li>When those are deployed then we have a link that navigates to the javascript file.</li>
    <li>For usage we will use IFrame for example (<iframe src="https://linktothewidged">)</li>
    <li>If someone wants to use the widget they just simply needs to add the Iframe tag in their frontend app.</li>
</ol>
<h2>Tracking and reporting</h2>
Because I have no experience with Razor app I am not familiar if there are any nuget packages that can automatically make this processes. So I will explain it in two different ways.</p>
<h2>First way</h2>
<ol>
  <li>Crete multiple API endpoints that accepts calls when some of the bookmark is saved, get shortened url, get statisctis.</li>
  <li>Create a model with following variables: User,Bookmark,ClickLog,ShortUrl</li>
  <li>Create service ShortenUrl which it will provide short urls.</li>
  <li>In order for the statistics to be shown I will use 'Database Query' for 'Chart Data' in razor page.</li>
</ol>
<h2>Second way</h2>
<ol>
  <li>I will use third party services for this kind of requirement.</li>
  <li>Set up Google Analytics account and add tracking rules.</li>
  <li>Access the Google Data API programmatically.</li>
  <li>I will show the data with help of "Chart data" in razor page.</li>
</ol>
