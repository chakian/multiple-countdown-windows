## Windows Desktop Application of Multiple Countdown

### Last things first

This application is close to be done. I don't think I'll make too much further development for this application after the open issues are closed.

I will then start working on a web application that uses the same database for the second platform support of the countdown application.
Well, if I live that long, after the web app, I may start working on an Android app too. Who knows.

### What is this app about?

I have tried several countdown applications (web and desktop) but I was never satisfied with what they were offering. I wanted something simple, something that only counts down. Afterwards I started wanting to have this count down data to be kept online so I could access it whenever I want (not only from the computer I started the countdown)

I had a very simple countdown application for myself but then I wanted to be able to have more than 1 countdown at once. That's how I started on this project.

After a while, I thought that maybe someone else could want to have this kind of application, so I put it here on GitHub (I was using a private svn repository before)

### Architecture

I believe (hope) that the code is self-explanatory. There are only 3 projects in the solution and 1 of them is the database.

Business project handles mostly the database operations and data manipulation (I didn't think that a new project for data layer was necessary, but maybe I'll do it some time)

WinUI project, well, has all the Windows UI things.

### Application Interface

Interface is quite simple actually. There is a main window that shows the current countdowns and allows to add new countdowns. This main window has a panel; and this panel contains a list of countdown user controls.

Actual counting down is done by the user control.

### Synchronization

I worked quite a bit on this part of the application. I knew that synchronization would be difficult to handle (I adore those huge cloud offering companies that do an awesome job at this). And it was difficult. I think that it works without any bugs now.

I'm not sure if I can ping the app from the server (from the db itself actually) when there's a change in the database; therefore, the sync is currently being initiated every 3 minutes... or 5. I forgot the value I wrote there.

`//TODO: I forgot to put that sync interval into the config. I should do that.`

Also there's a menu item that triggers sync when clicked. Pretty simple :)

#### Well that's about it. Have fun.
