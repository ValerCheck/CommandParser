<h2>CommandParser by Valerii Kolesnik</h2>
<p>This is simple console application which can run such commands: HELP, PRINT TABLE, PRINT MESSAGE, PING</p>
<hr/>
<h3>How to build</h3>
<p>
  There are few options to build the application:
  <ol>
    <li>Run .sln file in Visual Studio and choose BUILD => Build solution (press F6)</li>
    Executable file will be created in <em>..\CommandParser\bin\Debug</em> folder. Or ..\Release :).
    <li>
      Do it manually through a command prompt:
      <ol>
        <li>Open <b>Start</b> menu and find <b>Developer Command Prompt for VS%version%</b></li>
        or
        <li>Open your favourite command-line builds. But first you need to setup your <a href="https://msdn.microsoft.com/en-us/library/1700bbwd.aspx">Environmental Variables</a></li>
      </ol>
      Then navigate to CommandParser folder with source-code files and run next command:
      <pre><code>
        csc /out:CommandParser.exe /recurse:*.cs
      </code></pre>
      In the same folder you'll get your executable file.
    </li>
  </ol>
</p>
<hr/>
<h3>How to use</h3>
For now application supports next commands:
<ul>
  <li><code>/help,/?,-help</code> - Showing help for the application and a set of commands.</li>
  <li><code>-print &ltmessage&gt</code> - Prints the &ltmessage&gt to the screen.</li>
  <li><code>-k key1 value1 key2 value2</code> - Prints the key-value pair table</li>
  <li><code>-ping</code> - Just makes a beep sound and prints "Pinging..." message.</li>
</ul>
<h4><b>Example:</h4>
<pre><code>
  CommandParser.exe &ltcommand&gt &ltarg1&gt &ltarg2&gt &lt...&gt
  
</code></pre>
