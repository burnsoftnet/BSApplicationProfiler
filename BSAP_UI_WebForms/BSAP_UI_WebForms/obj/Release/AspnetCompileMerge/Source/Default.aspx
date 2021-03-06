﻿<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="BSAP_UI_WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>About</h1>
        <p class="lead">The BurnSoft Application Profiler was created to help automate performance and log gathering from applications that you create and use.  Most of the time when you create an application, you have to spend time testing it out before sending it to others to test.  While you are testing you application you may or may not be concerned on the amount of cpu is being used, the memory usage, handles and threads, even then, there is also if your application dumped anything into the log files. </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            This application will help gather all that information while you are using it normally and dump the information in a database.  It is designed to run as a service and look for any of the projects applications running in task manager, once it see’s the process in task manager it will start collection data on the application.  When the application ends, it will check to see if there are any logs, dump the results in the database and clear the log file, this way you can just go back and view the sessions to see the performance of the application and the details that where dumped in the log file.  
        </div>
        <div class="col-md-4">
            Worried about not being able to gather this information when you are using  your application while disconnected from the office?  Don’t be, the agent will see that it cannot connect to the main database and it will continue on using the local database the dump the data in there, once you are able to connect to the office and the agent can connect to the main database, it will dump the information that is the local database to the main database. 
        </div>
        <div class="col-md-4">
            <h2>UPDATES</h2>
            <ul>
                <li>4-24-2017 - Added the ability to capture the application version in the app monitor.  Update the database monitoring_session table with field appversion, appcomany, applastaccess, applastwrite, and createddatetime, updated the same table in the local SQLITE DB and added the details in the DataDump Project for the session details and updated the web ui to be able to view these changes. Created sp_updateSessionEnded to update anything that was unable to update the session end due to reboot, service stop while monitoring, etc.</li>
                <li>3/16/2017 - Updated Web UI with additional information to make the site more functional and improve stats.</li>
                <li>3/10/2017 - Updated Web Interface to be able to view the session details by session.</li>
                <li>3/8/2017 - Working on Web Interface to read the data.</li>
                <li>2/15/2017 - Agent functions are up and running</li>
                </ul>
        </div>
    </div>

</asp:Content>
