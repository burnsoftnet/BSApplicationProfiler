# BSApplicationProfiler
<br/><br/>
<center>
<img src="https://github.com/burnsoftnet/BSApplicationProfiler/blob/master/screen_shots/Project_Lists.png?raw=true"></center><br/><br/>
The BurnSoft Application Profiler was created to help automate performance and log gathering from applications that you create and use.  Most of the time when you create an application, you have to spend time testing it out before sending it to others to test.  While you are testing you application you may or may not be concerned on the amount of cpu is being used, the memory usage, handles and threads, even then, there is also if your application dumped anything into the log files.  
<br/>
<center>
<img src="https://github.com/burnsoftnet/BSApplicationProfiler/blob/master/screen_shots/Session_Lists.png?raw=true"></center><br/><br/>
<center>
<img src="https://github.com/burnsoftnet/BSApplicationProfiler/blob/master/screen_shots/View_Session_in_progress.png?raw=true"></center><br/><br/>
<center>
<img src="https://github.com/burnsoftnet/BSApplicationProfiler/blob/master/screen_shots/View_Session_Details_with_Logs.png?raw=true"></center><br/>

<br/>
This application will help gather all that information while you are using it normally and dump the information in a database.  It is designed to run as a service and look for any of the projects applications running in task manager, once it see’s the process in task manager it will start collection data on the application.  When the application ends, it will check to see if there are any logs, dump the results in the database and clear the log file, this way you can just go back and view the sessions to see the performance of the application and the details that where dumped in the log file.  
<br/>
<br/>
Worried about not being able to gather this information when you are using  your application while disconnected from the office?  Don’t be, the agent will see that it cannot connect to the main database and it will continue on using the local database the dump the data in there, once you are able to connect to the office and the agent can connect to the main database, it will dump the information that is the local database to the main database. 
<br/>
<br/>
<b>UPDATES:</b> <br/>
<ul>
<li>3/10/2017 - Updated Web Interface to be able to view the session details by session.</li>
<li>3/8/2017 - Working on Web Interface to read the data.</li>
<li>2/15/2017 - Agent functions are up and running</li>
</ul>
<br/>
